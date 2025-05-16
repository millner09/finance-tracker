using FinanceTracker.Api.Endpoints;
using FluentValidation;

namespace FinanceTracker.Api.Accounts
{
    /// <summary>
    /// A class that represents a request to create an account.
    /// </summary>
    public class CreateAccount
    {
        /// <summary>
        /// A request to create an account.
        /// </summary>
        /// <param name="Name">The name of the account.</param>
        /// <param name="Description">The description of the account.</param>
        /// <param name="Type">The type of account</param>
        public record Request(string Name, string? Description, string Type);

        /// <summary>
        /// A response to the create account request.
        /// </summary>
        /// <param name="Id">The unique identifier of the newly created account.</param>
        /// <param name="Name">The name of the account.</param>
        /// <param name="Description">The description of the account. This may be an empty string if not provided.</param>
        /// <param name="Type">The type of the account (e.g., "savings", "checking").</param>
        public record Response(int Id, string Name, string Description, string Type);

        /// <summary>
        /// Validator for the create account request.
        /// </summary>
        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required.")
                    .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
                RuleFor(x => x.Description)
                    .MaximumLength(500).WithMessage("Description cannot exceed 250 characters.");
                RuleFor(x => x.Type)
                    .NotEmpty().WithMessage("Type is required.");
            }
        }

        /// <summary>
        /// Endpoint for creating an account.
        /// </summary>
        public sealed class Endpoint : IEndpoint
        {
            /// <summary>
            /// Maps the endpoint to the application.
            /// </summary>
            /// <param name="app"></param>
            public void MapEndpoint(IEndpointRouteBuilder app)
            {
                app.MapPost("accounts", async (Request request, AccountsDb accountsDb, IValidator<Request> validator) =>
                {
                    var validRequest = await validator.ValidateAsync(request);
                    if (!validRequest.IsValid)
                    {
                        return Results.ValidationProblem(validRequest.ToDictionary());
                    }

                    var account = new Account
                    {
                        Name = request.Name,
                        Description = request.Description ?? string.Empty,
                        Type = request.Type
                    };

                    accountsDb.Accounts.Add(account);

                    var saveResult = await accountsDb.SaveChangesAsync();
                    if (saveResult == 0)
                    {
                        return Results.Problem("An error occurred while saving the account.");
                    }

                    return Results.Created($"/accounts/{account.Id}", new Response(account.Id, account.Name, account.Description, account.Type));
                });
            }
        }
    }
}