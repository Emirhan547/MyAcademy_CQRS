using MediatR;
using MyAcademy_CQRS.Application.Features.Results.AdminResults;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Core.Application.Features.Queries.AdminQueries;

public class GetActivityLogListQuery : IRequest<GetActivityLogListQueryResult>
{
    public ActivityLogCategory? Category { get; set; }
}