using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>(
        ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var responseName = typeof(TResponse).Name;

            logger.LogInformation($"[START] Handle Request={requestName} - Response={responseName} - RequestData={request}");

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();
            var timeTaken = timer.Elapsed;

            // if the request is greater than 3 seconds, then log warning
            if (timeTaken.Seconds > 3)
            {
                logger.LogWarning($"[PERFORMANCE] The request {requestName} took {timeTaken.Seconds}");
            }

            logger.LogInformation($"[END] Handled {requestName} with {responseName}");

            return response;
        }
    }
}
