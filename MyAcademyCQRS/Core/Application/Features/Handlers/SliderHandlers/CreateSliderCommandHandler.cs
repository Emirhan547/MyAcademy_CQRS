using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;
using MyAcademyCQRS.Core.Application.Validators;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.SliderHandlers
{
    public class CreateSliderCommandHandler(IRepository<Slider> _repository, IUnitOfWork _unitOfWork, IMapper _mapper,IValidator<CreateSliderCommand>_validator) : IRequestHandler<CreateSliderCommand, Result>
    {
        public async Task<Result> Handle(
            CreateSliderCommand request,
            CancellationToken cancellationToken)
        {
         
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Failure(
                    validationResult.Errors.First().ErrorMessage);
            }

           
            var slider = _mapper.Map<Slider>(request);

           
            await _repository.CreateAsync(slider);
            var saved = await _unitOfWork.SaveChangesAsync();

            return saved
                ? Result.SuccessResult("Slider başarıyla eklendi")
                : Result.Failure("Slider eklenirken hata oluştu");
        }
    }
}
