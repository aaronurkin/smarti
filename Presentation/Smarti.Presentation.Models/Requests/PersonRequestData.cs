namespace Smarti.Presentation.Models.Requests
{
    /// <summary>
    /// Person request data
    /// </summary>
    public class PersonRequestData
    {
        /// <summary>
        /// Timezone
        /// </summary>
        public string Tz { get; set; }

        /// <summary>
        /// Person name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Person age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Person address
        /// </summary>
        public AddressRequestData Address { get; set; }
    }
}
