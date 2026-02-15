using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class GetAllProductsQueryHandler
           : IRequestHandler<GetAllProductsQuery, IList<GetAllProductsQueryResult>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IList<GetAllProductsQueryResult>>(products);
        }
    }
}
