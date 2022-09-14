using Smarti.Application.Models;
using Smarti.Application.Models.Configurations;

namespace Smarti.Application.Infrastructure
{
    /// <summary>
    /// Service merging Address models using Reflection
    /// </summary>
    public class ReflectionMergeAddressModelApplicationService : ReflectionMergeModelApplicationServiceBase<AddressModel>
    {
        private readonly ModelMergeConfigurationDictionary _configuration;

        /// <summary>
        /// Initializes merge configuration
        /// </summary>
        /// <param name="configuration">A <see cref="ModelMergeConfigurationDictionary"/> instance</param>
        /// <exception cref="System.ArgumentNullException">If the configuration provided is null</exception>
        public ReflectionMergeAddressModelApplicationService(ModelMergeConfigurationDictionary configuration)
        {
            _configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Merges Address models data
        /// </summary>
        /// <param name="models">An instance of <see cref="ModelMergeDto{AddressModel}"/></param>
        /// <returns>A merged <see cref="AddressModel"/> instance</returns>
        /// <exception cref="System.ArgumentNullException">If the models parameter is null</exception>
        public override AddressModel Merge(Models.Dto.DataSourceModelsDictionary<AddressModel> models)
        {
            if (models == null)
            {
                throw new System.ArgumentNullException(nameof(models));
            }

            var properties = typeof(AddressModel).GetProperties();
            var result = this.MergeProperties(properties, _configuration, models);

            return result;
        }
    }
}
