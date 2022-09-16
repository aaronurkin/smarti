using Smarti.Application.Models;
using Smarti.Application.Models.Enums;
using Smarti.Common.Services;
using Smarti.Presentation.Models.Requests;
using System.Collections.Generic;

namespace Smarti.Presentation.Infrastructure.Mappers
{
    /// <summary>
    /// A C2 request data mapper
    /// </summary>
    public class C2DataSourcePersonModelKeyValuePairMapper : IDataMapper<MergePersonsRequestData, KeyValuePair<DataSource, PersonModel>>
    {
        private readonly IDataMapper<AddressRequestData, AddressModel> _addressMapper;

        public C2DataSourcePersonModelKeyValuePairMapper(IDataMapper<AddressRequestData, AddressModel> addressMapper)
        {
            _addressMapper = addressMapper ?? throw new System.ArgumentNullException(nameof(addressMapper));
        }

        /// <summary>
        /// Maps a <see cref="MergePersonsRequestData"/> item into the C2 <see cref="KeyValuePair{DataSource, PersonModel}"/> pair
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
            var pair = new KeyValuePair<DataSource, PersonModel>(DataSource.C2, model);

            return pair;
        }
    }
}
