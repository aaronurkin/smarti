using Smarti.Application.Models;
using Smarti.Application.Models.Configurations;
using Smarti.Application.Models.Dto;
using Smarti.Application.Models.Enums;
using Smarti.Application.Services;
using System.Collections.Generic;
using System.Linq;

namespace Smarti.Application.Infrastructure
{
    /// <summary>
    /// Service merging Person models using Reflection
    /// </summary>
    public class ReflectionMergePersonModelApplicationService : ReflectionMergeModelApplicationServiceBase<PersonModel>
    {
        private readonly ModelMergeConfigurationDictionary _configuration;
        private readonly IMergeModelApplicationService<AddressModel> _mergeAddressService;

        /// <summary>
        /// Initializes the service dependencies
        /// </summary>
        /// <param name="configuration">A <see cref="ModelMergeConfigurationDictionary"/> instance</param>
        /// <param name="mergeAddressService">An <see cref="IMergeModelApplicationService{AddressModel}"/> instance</param>
        /// <exception cref="System.ArgumentNullException">If one of the dependencies provided is null</exception>
        public ReflectionMergePersonModelApplicationService(
            ModelMergeConfigurationDictionary configuration,
            IMergeModelApplicationService<AddressModel> mergeAddressService
        )
        {
            _configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
            _mergeAddressService = mergeAddressService ?? throw new System.ArgumentNullException(nameof(mergeAddressService));
        }

        /// <summary>
        /// Merges Person models data
        /// </summary>
        /// <param name="models">An instance of <see cref="DataSourceModelsDictionary{PersonModel}"/></param>
        /// <returns>A merged <see cref="PersonModel"/> instance</returns>
        /// <exception cref="System.ArgumentNullException">If the models parameter is null</exception>
        public override PersonModel Merge(DataSourceModelsDictionary<PersonModel> models)
        {
            if (models == null)
            {
                throw new System.ArgumentNullException(nameof(models));
            }

            var properties = typeof(PersonModel).GetProperties();
            var result = this.MergeProperties(properties, _configuration, models);

            var addressModels = models.Select(i => new KeyValuePair<DataSource, AddressModel>(i.Key, i.Value.Address));
            result.Address = _mergeAddressService.Merge(new DataSourceModelsDictionary<AddressModel>(addressModels));

            return result;
        }
    }
}
