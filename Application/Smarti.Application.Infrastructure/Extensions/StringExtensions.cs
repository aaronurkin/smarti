using Smarti.Application.Models.Enums;
using System;
using System.Linq;

namespace Smarti.Application.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static DataSource GetDataSource(this string[] values)
        {
            var source = values.First();
            var dataSource = (DataSource)Enum.Parse(typeof(DataSource), source, true);

            return dataSource;
        }
    }
}
