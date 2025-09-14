using System.Net;

using ValNet.Objects;

namespace ValNet.Objects.Exceptions;

public class RequestException : ValNetException
{
    public HttpStatusCode StatusCode { get; }
    public string Content { get; }

    public RequestException(string message, HttpStatusCode statusCode, string content) : base(message, statusCode, content)
    {
        StatusCode = statusCode;
        Content = content;
    }
}
