using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.SliderResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.SliderQueries
{
    public class GetSliderByIdQuery : IRequest<GetSliderByIdQueryResult>
    {
        public int Id { get; set; }
    }
}