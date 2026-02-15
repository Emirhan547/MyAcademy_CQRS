using Microsoft.AspNetCore.Http;
using MyAcademy_CQRS.Application.Contracts.Sessions;

using System.Text.Json;

namespace MyAcademyCQRS.Infrastructure.Services;

public sealed class SessionCartService(IHttpContextAccessor httpContextAccessor) : ICartSessionService
{
    private const string SessionKey = "MyAcademy.Cart";

    public IList<CartSessionItemDto> GetItems()
    {
        var session = httpContextAccessor.HttpContext?.Session;
        if (session is null)
        {
            return [];
        }

        var json = session.GetString(SessionKey);
        return string.IsNullOrWhiteSpace(json)
            ? []
            : JsonSerializer.Deserialize<List<CartSessionItemDto>>(json) ?? [];
    }

    public void SaveItems(IList<CartSessionItemDto> items)
    {
        var session = httpContextAccessor.HttpContext?.Session;
        if (session is null)
        {
            return;
        }

        session.SetString(SessionKey, JsonSerializer.Serialize(items));
    }

    public void Clear()
    {
        httpContextAccessor.HttpContext?.Session?.Remove(SessionKey);
    }
}