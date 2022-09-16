using Smarti.Application.Models;
using Smarti.Common.Services;
using Smarti.Presentation.Models.Requests;

namespace Smarti.Presentation.Infrastructure.Mappers
{
    /// <summary>
    /// Address request data mapper
    /// </summary>
    public class AddressRequestDataModelMapper : IDataMapper<AddressRequestData, AddressModel>
    {
        /// <summary>
        /// Mapps a <see cref="AddressRequestData"/> into a <see cref="AddressModel"/>
        /// </summary>
        /// <param name="requestData">An address request data</param>
        /// <returns>An <see cref="AddressModel"/> instance</returns>
        public AddressModel Map(AddressRequestData requestData)
        {
            var address = new AddressModel
            {
                City = requestData.City,
                Region = requestData.Region
            };

            return address;
        }
    }
}
