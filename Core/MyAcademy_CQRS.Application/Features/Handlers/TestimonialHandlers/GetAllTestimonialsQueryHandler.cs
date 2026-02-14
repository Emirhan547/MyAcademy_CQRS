using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.TestimonialQueries;
using MyAcademyCQRS.Core.Application.Features.Results.TestimonialResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.TestimonialHandlers
{
    public class GetAllTestimonialsQueryHandler(
         IRepository<Testimonial> _repository,
         IMapper _mapper)
         : IRequestHandler<GetAllTestimonialsQuery, IList<GetAllTestimonialsQueryResult>>
    {
        public async Task<IList<GetAllTestimonialsQueryResult>> Handle(
            GetAllTestimonialsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<IList<GetAllTestimonialsQueryResult>>(data);
        }
    }
}
