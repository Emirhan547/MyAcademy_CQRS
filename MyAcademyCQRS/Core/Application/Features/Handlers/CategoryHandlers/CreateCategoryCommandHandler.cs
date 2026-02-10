using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

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
