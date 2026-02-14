using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactMessages;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Events.ContactMessageEvents;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactMessageHandlers
{
    public class UpdateContactCommandHandler(
        IRepository<ContactMessage> repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<UpdateContactCommand> validator,
        IDomainEventPublisher domainEventPublisher)
        : IRequestHandler<UpdateContactCommand, Result>
    {
        public async Task<Result> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
            {
                return Result.Failure(vr.Errors.First().ErrorMessage);
            }

            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null)
            {
                return Result.Failure("Mesaj bulunamadı");
            }

            mapper.Map(request, entity);
            repository.Update(entity);

            var saved = await unitOfWork.SaveChangesAsync();
            if (!saved)
            {
                return Result.Failure("Mesaj güncellenemedi");
            }

            await domainEventPublisher.PublishAsync(
                new ContactMessageUpdatedEvent(entity.Id, entity.FullName, entity.Email, entity.Subject, entity.IsActive),
                cancellationToken);

            return Result.SuccessResult("Mesaj güncellendi");
        }
    }
}