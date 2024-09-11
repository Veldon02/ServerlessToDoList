using System.Net;

namespace ServerlessToDoList.Web.ApiModels.Error;

public class ErrorResponse
{
    public HttpStatusCode StatusCode { get; set; }

    public string ErrorMessage { get; set; }
}