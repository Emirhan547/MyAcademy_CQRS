using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Contracts.Sessions
{
    public class CartSessionItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
