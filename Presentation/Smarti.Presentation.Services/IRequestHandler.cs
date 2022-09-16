using Smarti.Presentation.Models.Responses;

namespace Smarti.Presentation.Services
{
    /// <summary>
    /// Generic requests data handler
    /// </summary>
    /// <typeparam name="TRequestData">The type of request data</typeparam>
    public interface IRequestDataHandler<TRequestData>
    {
        /// <summary>
        /// Handles data received from a client
        /// </summary>
        /// <param name="requestData">Data received from a client</param>
        /// <returns>An instance of the <see cref="IApplicationResponse"/></returns>
        IApplicationResponse Handle(TRequestData requestData);
    }
}
