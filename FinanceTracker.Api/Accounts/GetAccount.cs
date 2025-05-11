using FinanceTracker.Api.Endpoints;

namespace FinanceTracker.Api.Accounts
{
    public class GetAccount
    {
        public record Response(string message);

        public sealed class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapGet("accounts/{id}", (string id) => $"Hello, {id}");
            }
        }
    }
}
