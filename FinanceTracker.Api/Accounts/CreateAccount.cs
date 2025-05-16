using FinanceTracker.Api.Endpoints;
using FluentValidation;

namespace FinanceTracker.Api.Accounts
{
    public class CreateAccount
    {
        public record Request(string Name, string? Description, string Type);
        public record Response(int Id, string Name, string Description, string Type);

        public class  RequestValidator : AbstractValidator<Request>
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

        public sealed class Endpoint : IEndpoint
        {
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
                    if(saveResult == 0)
                    {
                        return Results.Problem("An error occurred while saving the account.");
                    }

                    return Results.Created($"/accounts/{account.Id}", new Response(account.Id, account.Name, account.Description, account.Type));
                });
            }
        }
    }
}