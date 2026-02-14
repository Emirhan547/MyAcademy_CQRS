using MyAcademy_CQRS.Application.Features.Results.CartResults;
using MyAcademy_CQRS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyAcademyCQRS.Models
{
    public class CheckoutViewModel
    {
        public GetCartQueryResult Cart { get; set; } = new();

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string District { get; set; } = string.Empty;

        [Required]
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