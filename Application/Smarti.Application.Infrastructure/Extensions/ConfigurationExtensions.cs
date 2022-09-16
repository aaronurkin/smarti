using Microsoft.Extensions.Configuration;
using Smarti.Application.Models.Configurations;
using System.Collections.Generic;
using System.Linq;

namespace Smarti.Application.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ModelMergeConfigurationDictionary GetMergeConfiguration(
            this IConfiguration configuration,
            string sectionName
        )
        {
            var priorities = configuration
                .GetSection(sectionName)
                .Get<Dictionary<string, string[]>>()
                .Where(i => i.Value.FirstOrDefault() != null)
                .ToDictionary(i => i.Key, i => i.Value.GetDataSource());
            var mergeConfiguration = new ModelMergeConfigurationDictionary(priorities);

            return mergeConfiguration;
        }
    }
}
