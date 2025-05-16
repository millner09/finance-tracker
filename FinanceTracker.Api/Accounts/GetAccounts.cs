using FinanceTracker.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api.Accounts
{
    /// <summary>
    /// A class that represents a request to get all accounts.
    /// </summary>
    public class GetAccounts
    {
        /// <summary>
        /// A request to get all accounts.
        /// </summary>
        /// <param name="Id">The id of the account</param>
        /// <param name="Name">The name of the account</param>
        /// <param name="Description">The description of the account</param>
        /// <param name="Type">The type of account.</param>
        public record Response(int Id, string Name, string Description, string Type);

        /// <summary>
        /// Endpoint for getting all accounts.
        /// </summary>
        public class Endpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapGet("accounts", async (AccountsDb accountsDb) =>
                {
                    var accounts = await accountsDb.Accounts.ToListAsync();
                    return Results.Ok(accounts);
                });
            }
        }
    }
}
