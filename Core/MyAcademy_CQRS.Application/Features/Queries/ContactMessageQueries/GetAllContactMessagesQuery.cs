using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.ContactMessageResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.ContactMessageQueries
{
    public class GetAllContactMessagesQuery
       : IRequest<IList<GetAllContactMessagesQueryResult>>
    {
    }
}
