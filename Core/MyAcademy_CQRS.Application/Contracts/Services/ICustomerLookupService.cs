using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Contracts.Services
{
    public interface ICustomerLookupService
    {
        Task<IReadOnlyDictionary<string, string>> GetDisplayNamesAsync(IReadOnlyCollection<string> userIds, CancellationToken cancellationToken = default);
        Task<IReadOnlyDictionary<string, CustomerSummaryDto>> GetCustomerSummariesAsync(IReadOnlyCollection<string> userIds, CancellationToken cancellationToken = default);
    }

    public sealed class CustomerSummaryDto
    {
        public string DisplayName { get; set; } = string.Empty;
        public string Email { get; set; } = "-";
    }
}
