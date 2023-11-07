using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserServices>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PruductsDbContext>(option => option.UseSqlServer("Server=srv2\\pupils;Database=PruductsDB;Trusted_Connection=True;TrustServerCertificate=True"));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
