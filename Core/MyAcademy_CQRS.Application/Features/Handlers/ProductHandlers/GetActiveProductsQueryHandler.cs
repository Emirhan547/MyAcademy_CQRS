
using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class GetActiveProductsQueryHandler
         : IRequestHandler<GetActiveProductsQuery, IList<GetActiveProductsQueryResult>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetActiveProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<GetActiveProductsQueryResult>> Handle(GetActiveProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            var active = products.Where(x => x.IsActive).ToList();
            return _mapper.Map<IList<GetActiveProductsQueryResult>>(active);
        }
    }
}
