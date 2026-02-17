using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Features.Results.AdminResults;
using MyAcademyCQRS.Core.Application.Features.Queries.AdminQueries;

using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.AdminHandlers;

public class GetActivityLogListQueryHandler(IRepository<ActivityLog> repository)
    : IRequestHandler<GetActivityLogListQuery, GetActivityLogListQueryResult>
{
    public async Task<GetActivityLogListQueryResult> Handle(GetActivityLogListQuery request, CancellationToken cancellationToken)
    {
        var logs = await repository.GetAllAsync();

        var query = logs.Where(x => x.IsActive);

        if (request.Category.HasValue)
        {
            query = query.Where(x => x.Category == request.Category.Value);
        }

        return new GetActivityLogListQueryResult
        {
            SelectedCategory = request.Category,
            Logs = query
                .OrderByDescending(x => x.CreatedDate)
                .Take(500)
                .Select(x => new ActivityLogListItemResult
                {
                    CreatedDate = x.CreatedDate,
                    Category = x.Category,
                    Action = x.Action,
                    Description = x.Description,
                    UserEmail = x.UserEmail
                })
                .ToList()
        };
    }
}