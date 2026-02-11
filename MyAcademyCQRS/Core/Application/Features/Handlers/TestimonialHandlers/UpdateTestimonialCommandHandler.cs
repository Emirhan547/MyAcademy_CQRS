using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.TestimonialCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler(
        IRepository<Testimonial> _repository,
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        IValidator<UpdateTestimonialCommand> _validator)
        : IRequestHandler<UpdateTestimonialCommand, Result>
    {
        public async Task<Result> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ Validation
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            // 2️⃣ Entity getir
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Testimonial bulunamadı");

            // 3️⃣ Map et
            _mapper.Map(request, entity);

            _repository.Update(entity);

            // 4️⃣ Persist
            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Testimonial güncellendi")
                : Result.Failure("Güncelleme başarısız");
        }
    }
}