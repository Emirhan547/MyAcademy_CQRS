using Microsoft.AspNetCore.Http;
using MyAcademy_CQRS.Application.Contracts.Identities;
using System.Security.Claims;

namespace MyAcademy_CQRS.Infrastructure.Services;

public sealed class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public string? GetUserId()
    {
        return httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}