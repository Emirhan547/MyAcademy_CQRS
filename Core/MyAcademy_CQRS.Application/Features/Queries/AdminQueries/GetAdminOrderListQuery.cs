using MediatR;
using MyAcademy_CQRS.Application.Features.Results.AdminResults;


namespace MyAcademyCQRS.Core.Application.Features.Queries.AdminQueries;

public class GetAdminOrderListQuery : IRequest<GetAdminOrderListQueryResult>
{
    public string? SearchTerm { get; set; }
    public string? Status { get; set; }
}