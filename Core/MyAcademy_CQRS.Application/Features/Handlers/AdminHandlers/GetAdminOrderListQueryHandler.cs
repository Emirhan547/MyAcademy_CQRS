using MediatR;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademy_CQRS.Application.Features.Results.AdminResults;
using MyAcademyCQRS.Core.Application.Features.Queries.AdminQueries;
using MyAcademyCQRS.Core.Application.Features.Queries.OrderQueries;


namespace MyAcademyCQRS.Core.Application.Features.Handlers.AdminHandlers;

public class GetAdminOrderListQueryHandler(
    IMediator mediator,
    ICustomerLookupService customerLookupService) : IRequestHandler<GetAdminOrderListQuery, GetAdminOrderListQueryResult>
{
    public async Task<GetAdminOrderListQueryResult> Handle(GetAdminOrderListQuery request, CancellationToken cancellationToken)
    {
        var orders = await mediator.Send(new GetAllOrdersQuery(), cancellationToken);

        var userIds = orders
            .Where(x => !string.IsNullOrWhiteSpace(x.UserId))
            .Select(x => x.UserId!)
            .Distinct()
            .ToList();

        var userLookup = await customerLookupService.GetCustomerSummariesAsync(userIds, cancellationToken);

        var query = orders.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(order => order.Status.ToString().Equals(request.Status, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(order =>
                order.OrderNumber.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                ResolveCustomerName(order.UserId, userLookup).Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));
        }

        var filteredOrders = query.OrderByDescending(order => order.CreatedDate).ToList();

        return new GetAdminOrderListQueryResult
        {
            SearchTerm = request.SearchTerm,
            Status = request.Status,
            TotalOrderCount = filteredOrders.Count,
            TotalRevenue = filteredOrders.Sum(order => order.TotalPrice),
            Orders = filteredOrders.Select(order => new AdminOrderListItemResult
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                CustomerName = ResolveCustomerName(order.UserId, userLookup),
                CustomerEmail = ResolveCustomerEmail(order.UserId, userLookup),
                TotalPrice = order.TotalPrice,
                Status = order.Status.ToString(),
                CreatedDate = order.CreatedDate
            }).ToList()
        };
    }

    private static string ResolveCustomerName(string? userId, IReadOnlyDictionary<string, CustomerSummaryDto> userLookup)
    {
        if (string.IsNullOrWhiteSpace(userId) || !userLookup.TryGetValue(userId, out var user))
        {
            return "Misafir";
        }

        return user.DisplayName;
    }

    private static string ResolveCustomerEmail(string? userId, IReadOnlyDictionary<string, CustomerSummaryDto> userLookup)
    {
        if (string.IsNullOrWhiteSpace(userId) || !userLookup.TryGetValue(userId, out var user))
        {
            return "-";
        }

        return user.Email;
    }
}