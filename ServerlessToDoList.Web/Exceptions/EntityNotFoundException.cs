using System.Net;

namespace ServerlessToDoList.Web.Exceptions;

public class EntityNotFoundException : ApplicationException
{
    public EntityNotFoundException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}