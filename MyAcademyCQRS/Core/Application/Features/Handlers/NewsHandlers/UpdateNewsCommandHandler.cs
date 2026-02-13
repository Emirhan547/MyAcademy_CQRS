using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.NewsCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.NewsHandlers
{
    public class UpdateNewsCommandHandler(IRepository<News> repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateNewsCommand> validator) : IRequestHandler<UpdateNewsCommand, Result>
    {
        public async Task<Result> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null) return Result.Failure("Haber bulunamadı");
            mapper.Map(request, entity);
            repository.Update(entity);
            return await unitOfWork.SaveChangesAsync() ? Result.SuccessResult("Haber güncellendi") : Result.Failure("Haber güncellenemedi");
        }
    }
}