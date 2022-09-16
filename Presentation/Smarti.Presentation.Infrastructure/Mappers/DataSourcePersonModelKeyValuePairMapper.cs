using Smarti.Application.Models;
using Smarti.Application.Models.Enums;
using Smarti.Common.Services;
using Smarti.Presentation.Models.Requests;
using System.Collections.Generic;

namespace Smarti.Presentation.Infrastructure.Mappers
{
    /// <summary>
    /// Person request data item into a <see cref="KeyValuePair{DataSource, PersonModel}"/> item mapper
    /// </summary>
    public class DataSourcePersonModelKeyValuePairMapper : IDataMapper<MergePersonsRequestData, KeyValuePair<DataSource, PersonModel>>
    {
        private readonly IServiceResolver _serviceResolver;

        public DataSourcePersonModelKeyValuePairMapper(IServiceResolver serviceResolver)
        {
            _serviceResolver = serviceResolver ?? throw new System.ArgumentNullException(nameof(serviceResolver));
        }

        /// <summary>
        /// Maps a <see cref="MergePersonsRequestData"/> item into the <see cref="KeyValuePair{DataSource, PersonModel}"/> pair
        /// </summary>
        /// <param name="requestData">A <see cref="MergePersonsRequestData"/> request data</param>
        /// <returns>A <see cref="DataSource"/>/<see cref="PersonModel"/> key value pair</returns>
        public KeyValuePair<DataSource, PersonModel> Map(MergePersonsRequestData requestData)
        {
            var mapper = _serviceResolver
                .ResolveKeyed<IDataMapper<MergePersonsRequestData, KeyValuePair<DataSource, PersonModel>>>(requestData.Source);
            var pair = mapper.Map(requestData);

            return pair;
        }
    }
}
