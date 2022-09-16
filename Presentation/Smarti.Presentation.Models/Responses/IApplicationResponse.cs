namespace Smarti.Presentation.Models.Responses
{
    /// <summary>
    /// Represents application response with HTTP status code and a response body
    /// </summary>
    public interface IApplicationResponse
    {
        /// <summary>
        /// Response status code
        /// </summary>
        int StatusCode { get; }

        /// <summary>
        /// Response body of any type
        /// </summary>
        object Body { get; }
    }
}
