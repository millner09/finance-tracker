using FinanceTracker.Api.Endpoints;

namespace FinanceTracker.Api.Accounts
{
    public class GetAccount
    {
        public record Response(int id, string Name, string Description, string Type);

        public sealed class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapGet("accounts/{id}", (int id, AccountsDb accountsDb) =>
                {
                    var account = accountsDb.Accounts.FirstOrDefault(a => a.Id == id);
                    if (account == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(new Response(account.Id, account.Name, account.Description, account.Type));
                });
            }
        }
    }
}
