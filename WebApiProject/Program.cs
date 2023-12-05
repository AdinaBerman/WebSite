using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog.Web;
//using PresidentsApp.Middlewares;
using Repositories;
using Services;
using WebApiProject.middlewere;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IUserService, UserServices>();
        builder.Services.AddTransient<IOrderRepository, OrderRepository>();
        builder.Services.AddTransient<IOrderServices, OrderServices>();
        builder.Services.AddTransient<IProductRepository, ProductRepository>();
        builder.Services.AddTransient<IProductServices, ProductServices>();
        builder.Services.AddTransient<ICategoryReposirory, CategoryReposirory>();
        builder.Services.AddTransient<ICatogoryServices, CatogoryServices>();
        //builder.Services.AddTransient<IRatingService, RatingService>();
        builder.Services.AddTransient<IRatingRepository, RatingRepository>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Host.UseNLog();

        builder.Services.AddDbContext<PruductsDbContext>(option => option.UseSqlServer(builder.Configuration["MyStore"]));

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Configure the HTTP request pipeline.

       // app.UseErrorHandlingMiddleware();

        app.UseRatingMiddleware();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}