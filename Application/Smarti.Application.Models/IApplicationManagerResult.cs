using Smarti.Application.Models.Enums;

namespace Smarti.Application.Models
{
    /// <summary>
    /// Represents an application manager result
    /// </summary>
    public interface IApplicationManagerResult
    {
        /// <summary>
        /// Operation result data
        /// </summary>
        object Data { get; }

        /// <summary>
        /// Status of an operation produces
        /// </summary>
        ApplicationManagerResultStatus Status { get; }
    }
}
