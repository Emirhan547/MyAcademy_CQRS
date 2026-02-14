using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(
            IRepository<Product> _repository,
            IUnitOfWork _unitOfWork)
            : IRequestHandler<RemoveProductCommand, Result>
    {
        public async Task<Result> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product is null) return Result.Failure("Ürün bulunamadı");

            product.IsActive = false;
            _repository.Update(product);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Ürün pasife alındı")
                : Result.Failure("İşlem başarısız");
        }
    }
}
