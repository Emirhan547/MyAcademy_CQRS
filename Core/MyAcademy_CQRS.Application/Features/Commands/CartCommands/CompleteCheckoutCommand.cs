using MediatR;
using MyAcademy_CQRS.Domain.Enums;
using MyAcademyCQRS.Core.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Commands.CartCommands
{
    public class CompleteCheckoutCommand : IRequest<Result>
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public PaymentMethodType PaymentMethod { get; set; }
        public string CardHolderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string ExpireMonth { get; set; } = string.Empty;
        public string ExpireYear { get; set; } = string.Empty;
        public string Cvv { get; set; } = string.Empty;
        public string Iban { get; set; } = string.Empty;
        public string TransferReference { get; set; } = string.Empty;
    }
}