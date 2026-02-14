

using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.SliderHandlers
{
    public class RemoveSliderCommandHandler(IRepository<Slider> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveSliderCommand, Result>
    {
        public async Task<Result> Handle(RemoveSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _repository.GetByIdAsync(request.Id);
            if (slider is null)
                return Result.Failure("Slider bulunamadı");

            slider.IsActive = false;
            _repository.Update(slider);

            var saved = await _unitOfWork.SaveChangesAsync();

            return saved
                ? Result.SuccessResult("Slider pasife alındı")
                : Result.Failure("İşlem başarısız");
        }
    }
}
