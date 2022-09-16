using Microsoft.AspNetCore.Http;
using Smarti.Presentation.Models.Responses;
using Smarti.Presentation.Services;

namespace Smarti.Presentation.Infrastructure.ApplicationResponseBuilders
{
    /// <summary>
    /// Application response builder for aplication processes that didn't find a requested data
    /// </summary>
    public class NotFoundResponseBuilder : IApplicationResponseBuilder
    {
        /// <summary>
        /// Build application response with the status code 404
        /// </summary>
        /// <param name="responseBody">Response body</param>
        /// <returns>An instance of the <see cref="DefaultApplicationResponse"/> with the status code 404</returns>
        public IApplicationResponse Build(object responseBody)
        {
            var response = new DefaultApplicationResponse(StatusCodes.Status404NotFound, responseBody);
            return response;
        }
    }
}
