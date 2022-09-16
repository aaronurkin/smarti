using Smarti.Application.Models;
using Smarti.Application.Models.Dto;
using Smarti.Application.Services;
using Smarti.Common.Services;
using Smarti.Presentation.Models.Requests;
using Smarti.Presentation.Models.Responses;
using Smarti.Presentation.Services;
using System.Collections.Generic;

namespace Smarti.Presentation.Infrastructure.HttpRequestHandlers
{
    /// <summary>
    /// Merge persons request handler
    /// </summary>
    public class MergePersonsRequestDataHandler : IRequestDataHandler<IEnumerable<MergePersonsRequestData>>
    {
        private readonly IApplicationManager<DataSourceModelsDictionary<PersonModel>> _manager;
        private readonly IDataMapper<IEnumerable<MergePersonsRequestData>, DataSourceModelsDictionary<PersonModel>> _modelMapper;

        protected readonly IServiceResolver _serviceResolver;

        /// <summary>
        /// Initializes the handler dependencies
        /// </summary>
        /// <param name="serviceResolver">Service resolver to resolve services on initialization an at the runtime</param>
        /// <exception cref="System.ArgumentNullException">If the service resolver isn't provided</exception>
        public MergePersonsRequestDataHandler(IServiceResolver serviceResolver)
        {
            _serviceResolver = serviceResolver ?? throw new System.ArgumentNullException(nameof(serviceResolver));

            _manager = serviceResolver.Resolve<IApplicationManager<DataSourceModelsDictionary<PersonModel>>>();
            _modelMapper = serviceResolver.Resolve<IDataMapper<IEnumerable<MergePersonsRequestData>, DataSourceModelsDictionary<PersonModel>>>();
        }

        /// <summary>
        /// Handles people collection data received from a client
        /// </summary>
        /// <param name="people">The people collection</param>
        /// <returns>
        /// An instance of the <see cref="IApplicationResponse"/> with the correct HTTP status code
        /// and merged person as the body if the merge succeeded
        /// </returns>
        public virtual IApplicationResponse Handle(IEnumerable<MergePersonsRequestData> people)
        {
            var model = _modelMapper.Map(people);
            var result = _manager.Produce(model);
            var responseBuilder = _serviceResolver
                .ResolveKeyed<IApplicationResponseBuilder>(result.Status);

            var response = responseBuilder.Build(result.Data);
            return response;
        }
    }
}
