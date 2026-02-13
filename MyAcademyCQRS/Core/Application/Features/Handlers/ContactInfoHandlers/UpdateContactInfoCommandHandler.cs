using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactInfoHandlers
{
    public class UpdateContactInfoCommandHandler(IRepository<ContactInfo> repository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateContactInfoCommand> validator) : IRequestHandler<UpdateContactInfoCommand, Result>
    {
        public async Task<Result> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid) return Result.Failure(vr.Errors.First().ErrorMessage);
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null) return Result.Failure("İletişim bilgisi bulunamadı");
            mapper.Map(request, entity);
            repository.Update(entity);
            return await unitOfWork.SaveChangesAsync() ? Result.SuccessResult("İletişim bilgisi güncellendi") : Result.Failure("İletişim bilgisi güncellenemedi");
        }
    }
}