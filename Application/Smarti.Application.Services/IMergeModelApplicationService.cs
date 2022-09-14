using Smarti.Application.Models.Dto;

namespace Smarti.Application.Services
{
    /// <summary>
    /// The contract of a service that merges models data
    /// </summary>
    /// <typeparam name="TModel">The type of models to be merged</typeparam>
    public interface IMergeModelApplicationService<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// Merges models data
        /// </summary>
        /// <param name="models">An instance of <see cref="DataSourceModelsDictionary{TModel}"/></param>
        /// <returns>A merged <see cref="TModel"/> instance</returns>
        TModel Merge(DataSourceModelsDictionary<TModel> models);
    }
}
