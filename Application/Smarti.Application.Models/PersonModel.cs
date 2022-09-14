namespace Smarti.Application.Models
{
    /// <summary>
    /// Application layer Person model
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Person name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Age in years
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Timezone
        /// </summary>
        public string Tz { get; set; }

        /// <summary>
        /// Person's address
        /// </summary>
        public AddressModel Address { get; set; }
    }
}
