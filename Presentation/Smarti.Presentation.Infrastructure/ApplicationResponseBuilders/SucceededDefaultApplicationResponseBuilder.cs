using Microsoft.AspNetCore.Http;
using Smarti.Presentation.Models.Responses;
using Smarti.Presentation.Services;

namespace Smarti.Presentation.Infrastructure.ApplicationResponseBuilders
{
    /// <summary>
    /// Application response builder for succeeded aplication processes
    /// </summary>
    public class SucceededDefaultApplicationResponseBuilder : IApplicationResponseBuilder
    {
        /// <summary>
        /// Build application response with the status code 200
        /// </summary>
        /// <param name="responseBody">Response body</param>
        /// <returns>An instance of the <see cref="DefaultApplicationResponse"/> with the status code 200</returns>
        public IApplicationResponse Build(object responseBody)
        {
            var response = new DefaultApplicationResponse(StatusCodes.Status200OK, responseBody);
            return response;
        }
    }
}
