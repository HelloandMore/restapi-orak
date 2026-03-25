using Microsoft.EntityFrameworkCore;
using StarWarsDatabase;

var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=StarWarsDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
