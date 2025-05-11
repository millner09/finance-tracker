using FinanceTracker.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpoints();

var app = builder.Build();
app.MapEndpoints();


app.Run();