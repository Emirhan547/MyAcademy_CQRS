using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Contracts.Identities
{
    public interface ICurrentUserService
    {
        string? GetUserId();
    }
}
