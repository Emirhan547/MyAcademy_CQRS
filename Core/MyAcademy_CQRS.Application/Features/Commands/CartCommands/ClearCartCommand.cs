using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Commands.CartCommands
{
    public class ClearCartCommand : IRequest<Result>
    {
   
    }
}