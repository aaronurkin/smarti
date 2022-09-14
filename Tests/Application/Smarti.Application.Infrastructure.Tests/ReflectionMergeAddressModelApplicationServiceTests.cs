using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smarti.Application.Models;
using Smarti.Application.Models.Configurations;
using Smarti.Application.Models.Dto;
using Smarti.Application.Models.Enums;

namespace Smarti.Application.Infrastructure.Tests
{
    [TestClass]
    public class ReflectionMergeAddressModelApplicationServiceTests
    {
        [TestMethod]
        [DataRow(
            "Tel Aviv",
            "Haifa",
            "Tel Aviv",
            "Tel Aviv",
            "Hadera",
            "Haifa",
            DataSource.C2,
            DataSource.Webint
        )]
        [DataRow(
            "Haifa",
            "Tel Aviv",
            "Tel Aviv",
            "Tel Aviv",
            "Haifa",
            "Hadera",
            DataSource.Webint,
            DataSource.C2
        )]
        public void Merge_WebintAndC2Models_Returns_CorrectAddressModel(
            string expectedCity,
            string expectedRegion,
            string c2City,
            string c2Region,
            string webintCity,
            string webintRegion,
            DataSource configurationCity,
            DataSource configurationRegion
        )
        {
            var expected = new AddressModel
            {
                City = expectedCity,
                Region = expectedRegion
            };

            var c2AddressModel = new AddressModel
            {
                City = c2City,
                Region = c2Region
            };

            var webintAddressModel = new AddressModel
            {
                City = webintCity,
                Region = webintRegion
            };

            var configuration = new ModelMergeConfigurationDictionary
            {
                { "city", configurationCity },
                { "region", configurationRegion },
            };

            var models = new DataSourceModelsDictionary<AddressModel>
            {
                { DataSource.C2, c2AddressModel },
                { DataSource.Webint, webintAddressModel },
            };

            var target = new ReflectionMergeAddressModelApplicationService(configuration);
            var actual = target.Merge(models);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.City, actual.City);
            Assert.AreEqual(expected.Region, actual.Region);
        }
    }
}
