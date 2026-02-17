
using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademy_CQRS.Persistence.Context;


namespace MyAcademy_CQRS.Infrastructure.Services;

public class CustomerLookupService(AppDbContext context) : ICustomerLookupService
{
    public async Task<IReadOnlyDictionary<string, string>> GetDisplayNamesAsync(IReadOnlyCollection<string> userIds, CancellationToken cancellationToken = default)
    {
        var summaries = await GetCustomerSummariesAsync(userIds, cancellationToken);
        return summaries.ToDictionary(x => x.Key, x => x.Value.DisplayName);
    }

    public async Task<IReadOnlyDictionary<string, CustomerSummaryDto>> GetCustomerSummariesAsync(IReadOnlyCollection<string> userIds, CancellationToken cancellationToken = default)
    {
        if (userIds.Count == 0)
        {
            return new Dictionary<string, CustomerSummaryDto>();
        }

        return await context.Users
            .Where(user => userIds.Contains(user.Id))
            .ToDictionaryAsync(
                user => user.Id,
                user => new CustomerSummaryDto
                {
                    DisplayName = string.IsNullOrWhiteSpace(user.FullName) ? user.UserName ?? "Misafir" : user.FullName,
                    Email = string.IsNullOrWhiteSpace(user.Email) ? "-" : user.Email
                },
                cancellationToken);
    }
}