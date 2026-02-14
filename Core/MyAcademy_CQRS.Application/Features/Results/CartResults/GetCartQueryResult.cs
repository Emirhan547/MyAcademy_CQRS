using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Results.CartResults
{
    public class GetCartQueryResult
    {
        public IList<CartItemDto> Items { get; set; } = [];
        public decimal TotalPrice => Items.Sum(x => x.LineTotal);
        public int TotalQuantity => Items.Sum(x => x.Quantity);
    }
}
