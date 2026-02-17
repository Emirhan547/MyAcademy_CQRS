using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Results.DashboardResults
{
    public class DashboardDailyRevenueResult
    {
        public string DayLabel { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
    }
}
