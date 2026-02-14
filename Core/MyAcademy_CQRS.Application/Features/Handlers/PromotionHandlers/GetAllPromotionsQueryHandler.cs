using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.PromotionQueries;
using MyAcademyCQRS.Core.Application.Features.Results.PromotionResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.PromotionHandlers
{
    public class GetAllPromotionsQueryHandler(
        IRepository<Promotion> repository,
        IMapper mapper)
        : IRequestHandler<GetAllPromotionsQuery, IList<GetAllPromotionsQueryResult>>
    {
        public async Task<IList<GetAllPromotionsQueryResult>> Handle(
            GetAllPromotionsQuery request,
            CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();

            return mapper.Map<IList<GetAllPromotionsQueryResult>>(data);
        }
    }
}