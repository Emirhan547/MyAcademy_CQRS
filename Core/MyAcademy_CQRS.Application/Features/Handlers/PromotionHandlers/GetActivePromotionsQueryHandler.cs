using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.PromotionQueries;
using MyAcademyCQRS.Core.Application.Features.Results.PromotionResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.PromotionHandlers
{
    public class GetActivePromotionsQueryHandler(
     IRepository<Promotion> _repository,
     IMapper _mapper)
     : IRequestHandler<GetActivePromotionsQuery, IList<GetActivePromotionsQueryResult>>
    {
        public async Task<IList<GetActivePromotionsQueryResult>> Handle(
            GetActivePromotionsQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();

            var active = data
                .Where(x => x.IsActive && x.ExpireDate > DateTime.Now)
                .ToList();

            return _mapper.Map<IList<GetActivePromotionsQueryResult>>(active);
        }
    }

}
