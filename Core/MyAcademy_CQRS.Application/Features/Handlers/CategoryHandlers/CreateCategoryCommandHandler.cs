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
    public class CreateCategoryCommandHandler(
        IRepository<Category> _repository,
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        IValidator<CreateCategoryCommand> _validator)
        : IRequestHandler<CreateCategoryCommand, Result>
    {
        public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);

            var category = _mapper.Map<Category>(request);
            await _repository.CreateAsync(category);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Kategori eklendi")
                : Result.Failure("Kategori eklenemedi");
        }
    }
}
