using MediatR;
using Serilog;

namespace Ryder.Infrastructure.Common.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                Log.Logger.Error(ex, $"Unhandled Exception for Request {requestName} {request}");
                throw;
            }
        }
    }
}