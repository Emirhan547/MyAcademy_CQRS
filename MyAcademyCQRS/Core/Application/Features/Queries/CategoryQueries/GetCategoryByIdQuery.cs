using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.CategoryResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
