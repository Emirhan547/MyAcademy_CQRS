using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.OurStoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OurStoryHandlers
{
    public class UpdateOurStoryCommandHandler(
    IRepository<OurStory> _repository,
    IUnitOfWork _unitOfWork,
    IMapper _mapper,
    IValidator<UpdateOurStoryCommand> _validator)
    : IRequestHandler<UpdateOurStoryCommand, Result>
    {
        public async Task<Result> Handle(UpdateOurStoryCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                return Result.Failure("Kayıt bulunamadı");

            _mapper.Map(request, entity);
            _repository.Update(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("Güncellendi")
                : Result.Failure("Güncelleme başarısız");
        }
    }
}
