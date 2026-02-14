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
    public class UpdatePromotionCommandHandler(
    IRepository<Promotion> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IValidator<UpdatePromotionCommand> validator,
    IDomainEventPublisher domainEventPublisher)
    : IRequestHandler<UpdatePromotionCommand, Result>
    {
        public async Task<Result> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var vr = await validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Promotion bulunamadı");

            mapper.Map(request, entity);
            repository.Update(entity);

            var saved = await unitOfWork.SaveChangesAsync();
            if (!saved)
            {
                return Result.Failure("Güncelleme başarısız");
            }

            await domainEventPublisher.PublishAsync(
                new PromotionUpdatedEvent(entity.Id, entity.Title, entity.DiscountPrice, entity.IsActive),
                cancellationToken);

            return Result.SuccessResult("Promotion güncellendi");
        }
    }

}
