using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using ServerlessToDoList.Web.ApiModels.Error;
using ApplicationException = ServerlessToDoList.Web.Exceptions.ApplicationException;

namespace ServerlessToDoList.Web.Middlewares;

public class ExceptionHandlingMiddleware : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ApplicationException exception)
        {
            await ProcessException(context, exception.StatusCode, exception.Message);
        }
        catch (Exception e)
        {
            await ProcessException(context, HttpStatusCode.InternalServerError, "An unexpected error has occurred");
        }
    }

    private static async Task ProcessException(FunctionContext context, HttpStatusCode statusCode, string message)
    {
        var request = await context.GetHttpRequestDataAsync();
        var response = request!.CreateResponse();

        var error = new ErrorResponse
        {
            StatusCode = statusCode,
            ErrorMessage = message
        };

        await response.WriteAsJsonAsync(error, statusCode);

        context.GetInvocationResult().Value = response;
    }
}