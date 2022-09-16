using Smarti.Application.Models;
using Smarti.Application.Models.Enums;
using Smarti.Common.Services;
using Smarti.Presentation.Models.Requests;
using System.Collections.Generic;

namespace Smarti.Presentation.Infrastructure.Mappers
{
    /// <summary>
    /// A Webint request data mapper
    /// </summary>
    public class WebintDataSourcePersonModelKeyValuePairMapper : IDataMapper<MergePersonsRequestData, KeyValuePair<DataSource, PersonModel>>
    {
        private readonly IDataMapper<AddressRequestData, AddressModel> _addressMapper;

        public WebintDataSourcePersonModelKeyValuePairMapper(IDataMapper<AddressRequestData, AddressModel> addressMapper)
        {
            _addressMapper = addressMapper ?? throw new System.ArgumentNullException(nameof(addressMapper));
        }

        /// <summary>
        /// Maps a <see cref="MergePersonsRequestData"/> item into the Webint <see cref="KeyValuePair{DataSource, PersonModel}"/> pair
        /// </summary>
        /// <param name="requestData">A <see cref="MergePersonsRequestData"/> request data</param>
        /// <returns>A <see cref="DataSource"/>/<see cref="PersonModel"/> key value pair</returns>
        public KeyValuePair<DataSource, PersonModel> Map(MergePersonsRequestData requestData)
        {
            var person = requestData.Entity;
            var model = new PersonModel
            {
                Name = person.Name,
                Age = person.Age,
                Tz = person.Tz,
                Address = _addressMapper.Map(person.Address)
            };
            var pair = new KeyValuePair<DataSource, PersonModel>(DataSource.Webint, model);

            return pair;
        }
    }
}
