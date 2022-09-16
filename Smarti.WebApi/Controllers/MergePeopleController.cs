using Microsoft.AspNetCore.Mvc;
using Smarti.Common.Services;
using Smarti.Presentation.Models.Requests;
using System.Collections.Generic;

namespace Smarti.WebApi.Controllers
{
    public class MergePeopleController : SmartiControllerBase
    {
        public MergePeopleController(IServiceResolver serviceResolver)
            : base(serviceResolver)
        {
        }

        /// <summary>
        /// Merge people data endpoint
        /// </summary>
        /// <param name="people">A collection of data to be merged</param>
        /// <returns>Merged person</returns>
        [HttpPost]
        public IActionResult Post(IEnumerable<MergePersonsRequestData> people)
        {
            var response = this.Handle(people);
            return response;
        }
    }
}
