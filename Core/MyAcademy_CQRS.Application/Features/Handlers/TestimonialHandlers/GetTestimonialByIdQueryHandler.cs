using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.TestimonialQueries;
using MyAcademyCQRS.Core.Application.Features.Results.TestimonialResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler(
        IRepository<Testimonial> _repository,
        IMapper _mapper)
        : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            return entity is null
                ? null
                : _mapper.Map<GetTestimonialByIdQueryResult>(entity);
        }
    }
}