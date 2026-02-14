using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class GetProductsByCategoryQueryHandler
         : IRequestHandler<GetProductsByCategoryQuery, IList<GetProductsByCategoryQueryResult>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductsByCategoryQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<GetProductsByCategoryQueryResult>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            var filtered = products
                .Where(x => x.IsActive && x.CategoryId == request.CategoryId)
                .ToList();

            return _mapper.Map<IList<GetProductsByCategoryQueryResult>>(filtered);
        }
    }
}
