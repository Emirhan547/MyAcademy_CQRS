using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ContactMessageQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ContactMessageResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactMessageHandlers
{
    public class GetAllContactMessagesQueryHandler(
    IRepository<ContactMessage> _repository,
    IMapper _mapper)
    : IRequestHandler<GetAllContactMessagesQuery, IList<GetAllContactMessagesQueryResult>>
    {
        public async Task<IList<GetAllContactMessagesQueryResult>> Handle(
            GetAllContactMessagesQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();

            return _mapper.Map<IList<GetAllContactMessagesQueryResult>>(data);
        }
    }

}
