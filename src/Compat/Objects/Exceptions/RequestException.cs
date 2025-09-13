using System.Net;

namespace ValNet.Objects.Exceptions;

public class RequestException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string Content { get; }

    public RequestException(string message, HttpStatusCode statusCode, string content) : base(message)
    {
        StatusCode = statusCode;
        Content = content;
    }
}

