using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler(
        IRepository<Category> _repository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<RemoveCategoryCommand, Result>

    {
        public async Task<Result> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category is null) return Result.Failure("Kategori bulunamadı");

            category.IsActive = false;
            _repository.Update(category);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Kategori pasife alındı")
                : Result.Failure("İşlem başarısız");
        }
    }
}
