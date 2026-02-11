using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactMessages;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactMessageHandlers
{
    public class CreateContactMessageCommandHandler(
         IRepository<ContactMessage> _repository,
         IUnitOfWork _unitOfWork,
         IMapper _mapper,
         IValidator<CreateContactMessageCommand> _validator)
         : IRequestHandler<CreateContactMessageCommand, Result>
    {
        public async Task<Result> Handle(
            CreateContactMessageCommand request,
            CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = _mapper.Map<ContactMessage>(request);

            await _repository.CreateAsync(entity);

            var saved = await _unitOfWork.SaveChangesAsync();

            return saved
                ? Result.SuccessResult("Mesaj başarıyla gönderildi")
                : Result.Failure("İşlem başarısız");
        }
    }
}
