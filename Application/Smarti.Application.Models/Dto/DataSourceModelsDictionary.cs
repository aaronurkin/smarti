using Smarti.Application.Models.Enums;
using System.Collections.Generic;

namespace Smarti.Application.Models.Dto
{
    /// <summary>
    /// Models dictionary returning a model by data source enum value
    /// </summary>
    /// <typeparam name="TModel">The type of models</typeparam>
    public class DataSourceModelsDictionary<TModel> : Dictionary<DataSource, TModel>
    {
        /// <summary>
        /// Initializes an empty instance of the <see cref="DataSourceModelsDictionary{TModel}"/>
        /// </summary>
        public DataSourceModelsDictionary()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceModelsDictionary{TModel}"/>
        /// that contains elements copied from the specified collection
        /// </summary>
        /// <param name="collection">The <see cref="IEnumerable{KeyValuePair{DataSource, TModel}}"/>
        /// whose items are copied to the <see cref="DataSourceModelsDictionary{TModel}"/>
        /// </param>
        public DataSourceModelsDictionary(IEnumerable<KeyValuePair<DataSource, TModel>> collection)
            : base(collection)
        {
        }
    }
}
