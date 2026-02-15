using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Contracts.Sessions
{
    public interface ICartSessionService
    {
        IList<CartSessionItemDto> GetItems();
        void SaveItems(IList<CartSessionItemDto> items);
        void Clear();
    }
}
