using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.TestimonialCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler(
        IRepository<Testimonial> _repository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<RemoveTestimonialCommand, Result>
    {
        public async Task<Result> Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Testimonial bulunamadı");

            entity.IsActive = false;
            _repository.Update(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Testimonial pasife alındı")
                : Result.Failure("İşlem başarısız");
        }
    }
}
