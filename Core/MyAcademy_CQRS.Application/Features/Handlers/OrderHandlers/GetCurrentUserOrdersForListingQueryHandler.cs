using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademy_CQRS.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;
using MyAcademyCQRS.Core.Application.Features.Results.OrderResults;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OrderHandlers;

public class GetCurrentUserOrdersForListingQueryHandler(
    IMediator mediator,
    IActivityLogService activityLogService,
    IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetCurrentUserOrdersForListingQuery, IList<GetCurrentUserOrdersQueryResult>>
{
    public async Task<IList<GetCurrentUserOrdersQueryResult>> Handle(GetCurrentUserOrdersForListingQuery request, CancellationToken cancellationToken)
    {
        var orders = await mediator.Send(new GetCurrentUserOrdersQuery(), cancellationToken);

        await activityLogService.LogAsync(
            ActivityLogCategory.Order,
            "Siparişlerim görüntülendi",
            $"Kullanıcı sipariş listesi sayfasını açtı. Sipariş sayısı: {orders.Count}",
            ipAddress: httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString());

        return orders;
    }
}