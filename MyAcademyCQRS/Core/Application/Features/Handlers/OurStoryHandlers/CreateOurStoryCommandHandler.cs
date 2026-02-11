using AutoMapper;
using FluentValidation;
using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Commands.OurStoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.OurStoryHandlers
{
    public class CreateOurStoryCommandHandler(
         IRepository<OurStory> _repository,
         IUnitOfWork _unitOfWork,
         IMapper _mapper,
         IValidator<CreateOurStoryCommand> _validator)
         : IRequestHandler<CreateOurStoryCommand, Result>
    {
        public async Task<Result> Handle(CreateOurStoryCommand request, CancellationToken cancellationToken)
        {
            var vr = await _validator.ValidateAsync(request, cancellationToken);
            if (!vr.IsValid)
                return Result.Failure(vr.Errors.First().ErrorMessage);

            var entity = _mapper.Map<OurStory>(request);
            await _repository.CreateAsync(entity);

            return await _unitOfWork.SaveChangesAsync()
                ? Result.SuccessResult("OurStory eklendi")
                : Result.Failure("İşlem başarısız");
        }
    }
}
