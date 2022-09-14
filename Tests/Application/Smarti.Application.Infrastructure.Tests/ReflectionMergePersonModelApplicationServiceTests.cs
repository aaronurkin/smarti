using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Smarti.Application.Models;
using Smarti.Application.Models.Configurations;
using Smarti.Application.Models.Dto;
using Smarti.Application.Models.Enums;
using Smarti.Application.Services;

namespace Smarti.Application.Infrastructure.Tests
{
    [TestClass]
    public class ReflectionMergePersonModelApplicationServiceTests
    {
        private IMergeModelApplicationService<AddressModel> _addresMergeService;
        public ReflectionMergePersonModelApplicationServiceTests()
        {
            _addresMergeService = Substitute
                .For<ReflectionMergeAddressModelApplicationService>(new ModelMergeConfigurationDictionary
                {
                    { "city", DataSource.C2 },
                    { "region", DataSource.Webint },
                });

            _addresMergeService.Merge(default)
                .ReturnsForAnyArgs(new AddressModel { City = "Tel Aviv", Region = "Tel Aviv" });
        }

        [TestMethod]
        [DataRow(
            "Moshe",
            60,
            "IST",
            "Moshe",
            50,
            "EST",
            "Gal",
            60,
            "IST",
            DataSource.C2,
            DataSource.Webint,
            DataSource.Webint
        )]
        public void Merge_WebintAndC2Models_Returns_CorrectPersonModel(
            string expectedName,
            int expectedAge,
            string expectedTimeZone,
            string c2Name,
            int c2Age,
            string c2TimeZone,
            string webintName,
            int webintAge,
            string webintTimeZone,

            DataSource configurationName,
            DataSource configurationAge,
            DataSource configurationTimeZone
        )
        {
            var expected = new PersonModel
            {
                Age = expectedAge,
                Name = expectedName,
                Tz = expectedTimeZone
            };

            var c2PersonModel = new PersonModel
            {
                Age = c2Age,
                Name = c2Name,
                Tz = c2TimeZone
            };

            var webintPersonModel = new PersonModel
            {
                Age = webintAge,
                Name = webintName,
                Tz = webintTimeZone
            };

            var configuration = new ModelMergeConfigurationDictionary
            {
                { "tz", configurationTimeZone },
                { "name", configurationName },
                { "age", configurationAge },
            };

            var models = new DataSourceModelsDictionary<PersonModel>
            {
                { DataSource.C2, c2PersonModel },
                { DataSource.Webint, webintPersonModel },
            };

            var target = new ReflectionMergePersonModelApplicationService(configuration, _addresMergeService);
            var actual = target.Merge(models);

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Address);
            Assert.AreEqual(expected.Tz, actual.Tz);
            Assert.AreEqual(expected.Age, actual.Age);
            Assert.AreEqual(expected.Name, actual.Name);
        }
    }
}
