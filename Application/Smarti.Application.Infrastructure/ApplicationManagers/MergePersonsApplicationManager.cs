using Smarti.Application.Models;
using Smarti.Application.Models.Dto;
using Smarti.Application.Models.Enums;
using Smarti.Application.Services;
using System;

namespace Smarti.Application.Infrastructure.ApplicationManagers
{
    /// <summary>
    /// Merge persons flow manager 
    /// </summary>
    public class MergePersonsApplicationManager : IApplicationManager<DataSourceModelsDictionary<PersonModel>>
    {
        private readonly IMergeModelApplicationService<PersonModel> _mergeService;

        /// <summary>
        /// Initializes persons merge service
        /// </summary>
        /// <param name="mergeService">An instance of the <see cref="IMergeModelApplicationService{PersonModel}"/></param>
        /// <exception cref="ArgumentNullException">If the merge service isn't provided</exception>
        public MergePersonsApplicationManager(IMergeModelApplicationService<PersonModel> mergeService)
        {
            _mergeService = mergeService ?? throw new ArgumentNullException(nameof(mergeService));
        }

        /// <summary>
        /// Produces the merge persons flow
        /// </summary>
        /// <param name="model">An instance of the <see cref="DataSourceModelsDictionary{PersonModel}"/> with people to be merged</param>
        /// <returns>An instance of the <see cref="IApplicationManagerResult"/> with a merged person if succeeded</returns>
        public IApplicationManagerResult Produce(DataSourceModelsDictionary<PersonModel> model)
        {
			ApplicationManagerResult result;

            try
			{
                var person = _mergeService.Merge(model);
                result = new ApplicationManagerResult(ApplicationManagerResultStatus.Succeeded, person);
            }
            catch (Exception exception)
			{
				// Log exception
				result = new ApplicationManagerResult(ApplicationManagerResultStatus.Failed);
			}

            return result;
        }
    }
}
