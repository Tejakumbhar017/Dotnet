using CustomerAPI.Repositories;
using CustomerAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();


var app = builder.Build();

app.MapControllers();

app.Run();
