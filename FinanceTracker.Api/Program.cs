using FinanceTracker.Api.Accounts;
using FinanceTracker.Api.Endpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpoints();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddDbContextPool<AccountsDb>(opt =>
    opt.UseNpgsql(
        builder.Configuration.GetConnectionString("AccountsDb")));


var app = builder.Build();
app.MapEndpoints();


app.Run();