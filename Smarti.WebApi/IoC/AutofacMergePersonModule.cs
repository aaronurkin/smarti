using Autofac;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Smarti.Application.Infrastructure;
using Smarti.Application.Infrastructure.ApplicationManagers;
using Smarti.Application.Infrastructure.Extensions;
using Smarti.Application.Models;
using Smarti.Application.Models.Configurations;
using Smarti.Application.Models.Dto;
using Smarti.Application.Models.Enums;
using Smarti.Application.Services;
using Smarti.Common.Services;
using Smarti.Presentation.Infrastructure.ApplicationResponseBuilders;
using Smarti.Presentation.Infrastructure.HttpRequestHandlers;
using Smarti.Presentation.Infrastructure.Mappers;
using Smarti.Presentation.Models.Enums;
using Smarti.Presentation.Models.Requests;
using Smarti.Presentation.Services;
using System.Collections.Generic;

namespace Smarti.WebApi
{
    /// <summary>
    /// Registers merge person flow services
    /// </summary>
    public class AutofacMergePersonModule : Module
    {
        private readonly IConfiguration _configuration;

        public AutofacMergePersonModule(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        protected override void Load(ContainerBuilder container)
        {
            var personModelMergeConfiguration = "personModelMergeConfiguration";
            var addressModelMergeConfiguration = "addressModelMergeConfiguration";
            var mergeAddressApplicationService = "mergeAddressApplicationService";

            container
                .Register(context => _configuration.GetMergeConfiguration("MergeConfigurations:person"))
                .Named<ModelMergeConfigurationDictionary>(personModelMergeConfiguration)
                .SingleInstance();

            container
                .Register(context => _configuration.GetMergeConfiguration("MergeConfigurations:person:address"))
                .Named<ModelMergeConfigurationDictionary>(addressModelMergeConfiguration)
                .SingleInstance();

            container
                .RegisterType<ReflectionMergeAddressModelApplicationService>()
                .WithParameter(
                    ResolvedParameter
                        .ForNamed<ModelMergeConfigurationDictionary>(addressModelMergeConfiguration)
                )
                .Named<IMergeModelApplicationService<AddressModel>>(mergeAddressApplicationService);

            container
                .RegisterType<ReflectionMergePersonModelApplicationService>()
                .WithParameters(
                    new[]
                    {
                        ResolvedParameter
                            .ForNamed<ModelMergeConfigurationDictionary>(personModelMergeConfiguration),
                        ResolvedParameter
                            .ForNamed<IMergeModelApplicationService<AddressModel>>(mergeAddressApplicationService)
                    }
                )
            .As<IMergeModelApplicationService<PersonModel>>();

            container
                .RegisterType<AddressRequestDataModelMapper>()
                .As<IDataMapper<AddressRequestData, AddressModel>>()
                .SingleInstance();

            container
                .RegisterType<C2DataSourcePersonModelKeyValuePairMapper>()
                .Keyed<IDataMapper<MergePersonsRequestData, KeyValuePair<DataSource, PersonModel>>>(PersonRequestDataSource.C2)
                .SingleInstance();

            container
                .RegisterType<WebintDataSourcePersonModelKeyValuePairMapper>()
                .Keyed<IDataMapper<MergePersonsRequestData, KeyValuePair<DataSource, PersonModel>>>(PersonRequestDataSource.Webint)
                .SingleInstance();

            container
                .RegisterType<DataSourcePersonModelKeyValuePairMapper>()
                .As<IDataMapper<MergePersonsRequestData, KeyValuePair<DataSource, PersonModel>>>()
                .SingleInstance();

            container
                .RegisterType<DataSourcePersonModelsDictionaryMapper>()
                .As<IDataMapper<IEnumerable<MergePersonsRequestData>, DataSourceModelsDictionary<PersonModel>>>()
                .SingleInstance();

            container
                .RegisterType<InternalServerErrorResponseBuilder>()
                .Keyed<IApplicationResponseBuilder>(ApplicationManagerResultStatus.Failed)
                .SingleInstance();

            container
                .RegisterType<SucceededDefaultApplicationResponseBuilder>()
                .Keyed<IApplicationResponseBuilder>(ApplicationManagerResultStatus.Succeeded)
                .SingleInstance();

            container
                .RegisterType<BadRequestResponseBuilder>()
                .Keyed<IApplicationResponseBuilder>(ApplicationManagerResultStatus.InvalidInput)
                .SingleInstance();

            container
                .RegisterType<BadRequestResponseBuilder>()
                .Keyed<IApplicationResponseBuilder>(ApplicationManagerResultStatus.AlreadyExists)
                .SingleInstance();

            container
                .RegisterType<NotFoundResponseBuilder>()
                .Keyed<IApplicationResponseBuilder>(ApplicationManagerResultStatus.NotExists)
                .SingleInstance();

            container
                .RegisterType<MergePersonsApplicationManager>()
                .As<IApplicationManager<DataSourceModelsDictionary<PersonModel>>>()
                .InstancePerDependency();

            container
                .RegisterType<MergePersonsRequestDataHandler>()
                .As<IRequestDataHandler<IEnumerable<MergePersonsRequestData>>>()
                .InstancePerLifetimeScope();

        }
    }
}
