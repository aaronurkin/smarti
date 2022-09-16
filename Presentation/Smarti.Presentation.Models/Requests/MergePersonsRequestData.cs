using Smarti.Presentation.Models.Enums;

namespace Smarti.Presentation.Models.Requests
{
    /// <summary>
    /// Merge persons flow request data
    /// </summary>
    public class MergePersonsRequestData
    {
        /// <summary>
        /// Person entity
        /// </summary>
        public PersonRequestData Entity { get; set; }

        /// <summary>
        /// Data source
        /// </summary>
        public PersonRequestDataSource Source { get; set; }
    }
}
