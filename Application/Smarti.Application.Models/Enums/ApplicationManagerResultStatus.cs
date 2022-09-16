namespace Smarti.Application.Models.Enums
{
    /// <summary>
    /// An application manager result possible values
    /// </summary>
    public enum ApplicationManagerResultStatus
    {
        /// <summary>
        /// Operation failed
        /// </summary>
        Failed = 0,
        /// <summary>
        /// Operation succeeded
        /// </summary>
        Succeeded = 1,
        /// <summary>
        /// A data passed is invalid
        /// </summary>
        InvalidInput = 2,
        /// <summary>
        /// Resource does not exist
        /// </summary>
        NotExists = 3,
        /// <summary>
        /// Resource already exists
        /// </summary>
        AlreadyExists = 4,
    }
}
