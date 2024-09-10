using System.Net;

namespace ServerlessToDoList.Web.Exceptions;

public class ApplicationException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    protected ApplicationException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.InternalServerError;
    }
}