using Smarti.Presentation.Models.Responses;

namespace Smarti.Presentation.Services
{
    /// <summary>
    /// Represents application response builder
    /// </summary>
    public interface IApplicationResponseBuilder
    {
        /// <summary>
        /// Builds an instance of the <see cref="IApplicationResponse"/>
        /// </summary>
        /// <param name="responseBody">A response body data</param>
        /// <returns>An instance of the <see cref="IApplicationResponse"/></returns>
        IApplicationResponse Build(object responseBody);
    }
}
