using FinanceTracker.Api.Endpoints;

namespace FinanceTracker.Api.Accounts
{
    public class CreateAccount
    {
        public record Request(string Name, string? Description, string Type);
        public record Response(int Id, string Name, string Description, string Type);
        public sealed class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapPost("accounts", async (Request request, AccountsDb accountsDb) =>
                {
                    // Simulate account creation
                    var account = new Account
                    {
                        Name = request.Name,
                        Description = request.Description ?? string.Empty,
                        Type = request.Type
                    };

                    accountsDb.Accounts.Add(account);
                    await accountsDb.SaveChangesAsync();

                    return Results.Created($"/accounts/{account.Id}", new Response(account.Id, account.Name, account.Description, account.Type));
                });
            }
        }
    }
}