using Smarti.Application.Models.Enums;

namespace Smarti.Application.Models
{
    /// <summary>
    /// Represents an application manager result
    /// </summary>
    public class ApplicationManagerResult : IApplicationManagerResult
    {
        /// <summary>
        /// Initializes status
        /// </summary>
        /// <param name="status">The status of operation</param>
        public ApplicationManagerResult(ApplicationManagerResultStatus status)
            : this(status, default(object)) { }

        /// <summary>
        /// Initializes status and data
        /// </summary>
        /// <param name="status">The status of operation</param>
        /// <param name="data">The data</param>
        public ApplicationManagerResult(ApplicationManagerResultStatus status, object data)
        {
            Data = data;
            Status = status;
        }

        /// <summary>
        /// Operation result data
        /// </summary>
        public virtual object Data { get; }

        /// <summary>
        /// Status of an operation produces
        /// </summary>
        public virtual ApplicationManagerResultStatus Status { get; }
    }

    /// <summary>
    /// Represents an application manager result with strongly typed data
    /// </summary>
    public class ApplicationManagerResult<TData> : ApplicationManagerResult
    {
        public ApplicationManagerResult(ApplicationManagerResultStatus status)
            : base(status)
        {
        }

        public ApplicationManagerResult(ApplicationManagerResultStatus status, TData data)
            : base(status, data)
        {
        }
    }
}
