using Smarti.Application.Models;
using Smarti.Application.Models.Dto;
using Smarti.Application.Models.Enums;
using Smarti.Common.Services;
using Smarti.Presentation.Models.Requests;
using System.Collections.Generic;
using System.Linq;

namespace Smarti.Presentation.Infrastructure.Mappers
{
    /// <summary>
    /// Persons request data into application model mapper
    /// </summary>
    public class DataSourcePersonModelsDictionaryMapper : IDataMapper<IEnumerable<MergePersonsRequestData>, DataSourceModelsDictionary<PersonModel>>
    {
        private readonly IDataMapper<MergePersonsRequestData, KeyValuePair<DataSource, PersonModel>> _mapper;

        public DataSourcePersonModelsDictionaryMapper(
            IDataMapper<MergePersonsRequestData, KeyValuePair<DataSource, PersonModel>> mapper
        )
        {
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Maps a <see cref="IEnumerable{MergePersonsRequestData}"/> collection
        /// into a <see cref="DataSourceModelsDictionary{PersonModel}"/> dictionary
        /// </summary>
        /// <param name="source">A <see cref="IEnumerable{MergePersonsRequestData}"/> collection</param>
        /// <returns>A mapped <see cref="DataSourceModelsDictionary{PersonModel}"/></returns>
        public DataSourceModelsDictionary<PersonModel> Map(IEnumerable<MergePersonsRequestData> source)
        {
            var people = source.Select(_mapper.Map);
            var result = new DataSourceModelsDictionary<PersonModel>(people);

            return result;
        }
    }
}
