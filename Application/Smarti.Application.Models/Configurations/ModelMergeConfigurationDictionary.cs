using Smarti.Application.Models.Enums;
using System;
using System.Collections.Generic;

namespace Smarti.Application.Models.Configurations
{
    /// <summary>
    /// Merge configuration dictionary returning a data source enum value by property name
    /// </summary>
    public class ModelMergeConfigurationDictionary : Dictionary<string, DataSource>
    {
        /// <summary>
        /// Initializes a case insensitive dictionary
        /// </summary>
        public ModelMergeConfigurationDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// Initializes a case insensitive dictionary and fills it with values
        /// </summary>
        public ModelMergeConfigurationDictionary(IDictionary<string, DataSource> values)
            : base(values, StringComparer.OrdinalIgnoreCase)
        {
        }
    }
}
