using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.PromotionQueries;
using MyAcademyCQRS.Core.Application.Features.Results.PromotionResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.PromotionHandlers
{
    public class GetPromotionByIdQueryHandler(
        IRepository<Promotion> _repository,
        IMapper _mapper)
        : IRequestHandler<GetPromotionByIdQuery, GetPromotionByIdQueryResult>
    {
        public async Task<GetPromotionByIdQueryResult> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            return entity is null
                ? null
                : _mapper.Map<GetPromotionByIdQueryResult>(entity);
        }
    }
}