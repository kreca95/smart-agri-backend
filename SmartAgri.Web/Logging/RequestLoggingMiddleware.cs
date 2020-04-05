using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartAgri.Web.Logging
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly Stopwatch _stopwatch;
        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
            _stopwatch = new Stopwatch();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _stopwatch.Start();
                await _next(context);
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation(
                    "{Date} Request {method} {url} => {statusCode} Response time: {time} ms",
                    DateTime.Now,
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode
                    ,_stopwatch.ElapsedMilliseconds);
                _stopwatch.Reset();
            }
        }
    }
}
