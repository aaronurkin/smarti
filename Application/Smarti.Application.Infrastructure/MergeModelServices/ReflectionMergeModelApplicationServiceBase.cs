using Smarti.Application.Models.Configurations;
using Smarti.Application.Models.Dto;
using Smarti.Application.Models.Enums;
using Smarti.Application.Services;
using System.Collections.Generic;
using System.Reflection;

namespace Smarti.Application.Infrastructure
{
    /// <summary>
    /// Encapsulates common merge properties logic
    /// </summary>
    /// <typeparam name="TModel">The type of models to be merged</typeparam>
    public abstract class ReflectionMergeModelApplicationServiceBase<TModel> : IMergeModelApplicationService<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// Merges properties values from correct sources according to the <see cref="ModelMergeConfigurationDictionary"/>
        /// </summary>
        /// <param name="properties">A list of properties to be merged</param>
        /// <param name="configuration">A merge configuration</param>
        /// <param name="models">An instance of <see cref="DataSourceModelsDictionary{TModel}"/> containing models to get data from</param>
        /// <returns>An instance of <see cref="TModel"/> merged from the correct sources</returns>
        protected virtual TModel MergeProperties(
            IEnumerable<PropertyInfo> properties,
            ModelMergeConfigurationDictionary configuration,
            DataSourceModelsDictionary<TModel> models
        )
        {
            var result = new TModel();

            foreach (var propertyInfo in properties)
            {
                if (!configuration.TryGetValue(propertyInfo.Name, out DataSource source))
                {
                    // TODO: Log property is not configured
                    continue;
                }

                var value = propertyInfo.GetValue(models[source], null);
                propertyInfo.SetValue(result, value, null);
            }

            return result;
        }

        /// <summary>
        /// Merges models data. Must be implemented in the derived class
        /// </summary>
        /// <param name="models">An instance of <see cref="DataSourceModelsDictionary{TModel}"/></param>
        /// <returns>A merged <see cref="TModel"/> instance</returns>
        public abstract TModel Merge(DataSourceModelsDictionary<TModel> models);
    }
}
