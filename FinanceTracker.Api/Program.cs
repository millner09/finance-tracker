using FinanceTracker.Api.Accounts;
using FinanceTracker.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpoints();

// TODO: Add this connection string to secrets.
builder.Services.AddDbContextPool<AccountsDb>(opt =>
    opt.UseNpgsql(
        builder.Configuration.GetConnectionString("AccountsDb")));


var app = builder.Build();
app.MapEndpoints();


app.Run();