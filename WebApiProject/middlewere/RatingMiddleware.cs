using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Repositories;
using System.Threading.Tasks;

namespace WebApiProject.middlewere
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRatingRepository ratingRepository;
        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task<Task> Invoke(HttpContext httpContext, IRatingRepository ratingRepository)
        {
            Rating rating = new Rating();
            rating.Host = httpContext.Request.Host.Value;
            rating.Method = httpContext.Request.Method;
            rating.Path = httpContext.Request.Path;
            rating.RecordDate = DateTime.Now;
            rating.Referer = httpContext.Request.Protocol + httpContext.Request.Host;
            //rating.UserAgent = httpContext.Request.
            await ratingRepository.addRating(rating);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
