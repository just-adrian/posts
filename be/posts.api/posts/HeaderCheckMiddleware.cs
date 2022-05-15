using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace posts.api
{
    public class HeaderCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Settings _settings;

        public HeaderCheckMiddleware(RequestDelegate next, IOptions<Settings> options)
        {
            _next = next;
            _settings = options.Value;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.ContainsKey("api-key") && httpContext.Request.Headers["api-key"] == _settings.ApiKey)
            {
                return _next(httpContext);
            }

            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            httpContext.Response.ContentType = "text/plain";
            return httpContext.Response.WriteAsync("Wrong api-key");
        }
    }

    public static class HeaderCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseHeaderCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeaderCheckMiddleware>();
        }
    }
}
