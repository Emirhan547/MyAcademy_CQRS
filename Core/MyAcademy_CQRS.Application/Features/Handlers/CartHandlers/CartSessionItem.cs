using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers
{
    internal sealed class CartSessionItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
