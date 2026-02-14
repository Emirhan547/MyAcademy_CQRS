

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers
{
    internal sealed class SessionCartStore(IHttpContextAccessor httpContextAccessor)
    {
        private const string SessionKey = "MyAcademy.Cart";

        public IList<CartSessionItem> Get()
        {
            var session = httpContextAccessor.HttpContext?.Session;
            if (session is null)
            {
                return [];
            }

            var json = session.GetString(SessionKey);
            return string.IsNullOrWhiteSpace(json)
                ? []
                : JsonSerializer.Deserialize<List<CartSessionItem>>(json) ?? [];
        }

        public void Save(IList<CartSessionItem> items)
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
}
