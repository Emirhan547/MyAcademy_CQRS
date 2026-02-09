using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.SliderHandlers
{
    public class UpdateSliderCommandHandler(IRepository<Slider>_repository,IUnitOfWork _unitOfWork,IMapper _mapper,IValidator<UpdateSliderCommand>_validator) : IRequestHandler<UpdateSliderCommand, Result>
    {
        public async Task<Result> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Failure(
                    validationResult.Errors.First().ErrorMessage);
            }
            var slider = await _repository.GetByIdAsync(request.Id);
            if (slider == null)
                return Result.Failure("Slider bulunamadı");

            // Mapping (mevcut entity üzerine)
            _mapper.Map(request, slider);

            _repository.Update(slider);
            var saved = await _unitOfWork.SaveChangesAsync();

            return saved
                ? Result.SuccessResult("Slider başarıyla güncellendi")
                : Result.Failure("Slider güncellenemedi");
        }
    }
    }

