using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(
        IRepository<Category> _repository,
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        IValidator<UpdateCategoryCommand> _validator)
        : IRequestHandler<UpdateCategoryCommand, Result>
    {
        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);

            var category = await _repository.GetByIdAsync(request.Id);
            if (category is null) return Result.Failure("Kategori bulunamadı");

            _mapper.Map(request, category);
            _repository.Update(category);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Kategori güncellendi")
                : Result.Failure("Kategori güncellenemedi");
        }
    }
}
