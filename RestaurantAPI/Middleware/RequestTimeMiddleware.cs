using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace RestaurantAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private Stopwatch _stopWatch;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _stopWatch = new Stopwatch();
            _logger = logger;
        }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            if(_stopWatch.ElapsedMilliseconds > 4000)
            {
                var message = $"Request[{context.Request.Method}] at {context.Request.Path} took {_stopWatch.ElapsedMilliseconds}ms";
                _logger.LogInformation(message);
            }
        }
    }
}
