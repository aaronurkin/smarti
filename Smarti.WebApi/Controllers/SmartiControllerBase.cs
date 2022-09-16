using Microsoft.AspNetCore.Mvc;
using Smarti.Common.Services;
using Smarti.Presentation.Services;

namespace Smarti.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class SmartiControllerBase : ControllerBase
    {
        protected readonly IServiceResolver _serviceResolver;

        /// <summary>
        /// Base controller for application controllers
        /// </summary>
        /// <param name="serviceResolver">Service resolver to resolve services on initialization an at the runtime</param>
        /// <exception cref="System.ArgumentNullException">If the service resolver isn't provided</exception>
        protected SmartiControllerBase(IServiceResolver serviceResolver)
        {
            _serviceResolver = serviceResolver ?? throw new System.ArgumentNullException(nameof(serviceResolver));
        }

        /// <summary>
        /// Handles data received from a client resolving concrete data handler
        /// </summary>
        /// <typeparam name="TRequestData">The type of a request data</typeparam>
        /// <param name="requestData"></param>
        /// <returns>An instance of the <see cref="IActionResult"/> with correct status and response body</returns>
        protected virtual IActionResult Handle<TRequestData>(TRequestData requestData)
        {
            var manager = _serviceResolver.Resolve<IRequestDataHandler<TRequestData>>();
            var response = manager.Handle(requestData);

            return StatusCode(response.StatusCode, response.Body);
        }
    }
}
