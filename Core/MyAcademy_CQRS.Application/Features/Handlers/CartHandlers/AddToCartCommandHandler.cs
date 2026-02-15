using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.Sessions;
using MyAcademy_CQRS.Application.Features.Commands.CartCommands;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers
{
    public class AddToCartCommandHandler(
     IRepository<Product> productRepository,
     ICartSessionService cartSessionService,
     IValidator<AddToCartCommand> validator)
     : IRequestHandler<AddToCartCommand, Result>
    {
        public async Task<Result> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors.First().ErrorMessage);
            }

            var product = await productRepository.GetByIdAsync(request.ProductId);
            if (product is null || !product.IsActive)
            {
                return Result.Failure("Ürün bulunamadı veya satışta değil.");
            }

            var items = cartSessionService.GetItems();
            var existing = items.FirstOrDefault(x => x.ProductId == request.ProductId);

            if (existing is null)
            {
                items.Add(new CartSessionItemDto { ProductId = request.ProductId, Quantity = request.Quantity });
            }
            else
            {
                existing.Quantity += request.Quantity;
            }
            cartSessionService.SaveItems(items);
            return Result.SuccessResult("Ürün sepete eklendi.");
        }
    }
}