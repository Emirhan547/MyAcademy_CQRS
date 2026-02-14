using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Events;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.PromotionCommands;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Events.PromotionEvents;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.PromotionHandlers
{
    public class CreatePromotionCommandHandler(
     IRepository<Promotion> repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CreatePromotionCommand> validator,
        IDomainEventPublisher domainEventPublisher)
        : IRequestHandler<CreatePromotionCommand, Result>
    {
        public async Task<Result> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = mapper.Map<Promotion>(request);
            await repository.CreateAsync(entity);

            var saved = await unitOfWork.SaveChangesAsync();
            if (!saved)
            {
                return Result.Failure("İşlem başarısız");
            }

            await domainEventPublisher.PublishAsync(
                new PromotionCreatedEvent(entity.Id, entity.Title, entity.DiscountPrice),
                cancellationToken);

            return Result.SuccessResult("Promotion eklendi");
        }
    }
}
