using Smarti.Application.Models;

namespace Smarti.Application.Services
{
    /// <summary>
    /// Represents a business logic producer
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IApplicationManager<in TModel>
    {
        /// <summary>
        /// Produces a business logic using a model recieved
        /// </summary>
        /// <param name="model">A model received</param>
        /// <returns>A result of an operation</returns>
        IApplicationManagerResult Produce(TModel model);
    }
}
