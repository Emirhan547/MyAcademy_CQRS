using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.GalleryCategoryQueries
{
    public class GetGalleryCategoryByIdQuery
     : IRequest<GetGalleryCategoryByIdQueryResult>
    {
        public int Id { get; set; }
    }

}
