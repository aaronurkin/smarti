namespace Smarti.Presentation.Models.Responses
{
    /// <summary>
    /// Represents application response with HTTP status code and a response body
    /// </summary>
    public class DefaultApplicationResponse : IApplicationResponse
    {
        public DefaultApplicationResponse(int statusCode)
        {
            StatusCode = statusCode;
        }

        public DefaultApplicationResponse(int statusCode, object body)
            : this(statusCode)
        {
            Body = body;
        }

        /// <summary>
        /// Response status code
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Response body of any type
        /// </summary>
        public object Body { get; }
    }
}
