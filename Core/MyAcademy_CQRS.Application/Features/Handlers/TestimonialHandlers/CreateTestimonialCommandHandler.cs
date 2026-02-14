using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.TestimonialCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler(IRepository<Testimonial> _repository, IUnitOfWork _unitOfWork, IMapper _mapper, IValidator<CreateTestimonialCommand> _validator) : IRequestHandler<CreateTestimonialCommand, Result>
    {
        public async Task<Result> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = _mapper.Map<Testimonial>(request);
            await _repository.CreateAsync(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Testimonial eklendi")
                : Result.Failure("İşlem başarısız");
        }
    }
}
