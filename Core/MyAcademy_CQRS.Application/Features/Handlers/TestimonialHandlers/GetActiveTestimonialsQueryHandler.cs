using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.TestimonialQueries;
using MyAcademyCQRS.Core.Application.Features.Results.TestimonialResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.TestimonialHandlers
{
    public class GetActiveTestimonialsQueryHandler(
         IRepository<Testimonial> _repository,
         IMapper _mapper)
         : IRequestHandler<GetActiveTestimonialsQuery, IList<GetActiveTestimonialsQueryResult>>
    {
        public async Task<IList<GetActiveTestimonialsQueryResult>> Handle(
            GetActiveTestimonialsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            var active = data.Where(x => x.IsActive).ToList();
            return _mapper.Map<IList<GetActiveTestimonialsQueryResult>>(active);
        }
    }
}