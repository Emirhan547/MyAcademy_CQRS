using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ContactMessageQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ContactMessageResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactMessageHandlers
{
    public class GetContactMessageByIdQueryHandler(
     IRepository<ContactMessage> _repository,
     IMapper _mapper)
     : IRequestHandler<GetContactMessageByIdQuery, GetContactMessageByIdQueryResult>
    {
        public async Task<GetContactMessageByIdQueryResult> Handle(
            GetContactMessageByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            return entity is null
                ? null
                : _mapper.Map<GetContactMessageByIdQueryResult>(entity);
        }
    }

}
