using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactMessages;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactMessageHandlers
{
    public class CreateContactMessageCommandHandler(
         IRepository<ContactMessage> repository,
         IUnitOfWork unitOfWork,
         IMapper mapper,
         IValidator<CreateContactMessageCommand> validator,
         IDomainEventPublisher domainEventPublisher)
         : IRequestHandler<CreateContactMessageCommand, Result>
    {
        public async Task<Result> Handle(
            CreateContactMessageCommand request,
            CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = mapper.Map<ContactMessage>(request);

            await repository.CreateAsync(entity);

            var saved = await unitOfWork.SaveChangesAsync();

            if (!saved)
            {
                return Result.Failure("İşlem başarısız");
            }

            await domainEventPublisher.PublishAsync(
                new ContactMessageReceivedEvent(entity.Id, entity.FullName, entity.Email, entity.Subject),
                cancellationToken);

            return Result.SuccessResult("Mesaj başarıyla gönderildi");
        }
    }
}
