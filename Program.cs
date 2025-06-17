using final_project.Migrations;
using final_project.Repositories;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Unable to load connection string");
builder.Services.AddDbContext<AruchaDb>(options => {
    options.UseSqlite(connectionString);
});

// try {
    builder.Services.AddScoped<IUserRepository, UserRepository>();
// } catch {
//     throw new Exception("Unable to register user repository");
// }

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();