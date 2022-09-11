using Autofac;
using Smarti.Common.Services;
using System;

namespace Smarti.Common.Infrastructure
{
    /// <summary>
    /// An Autofac implementation of a service resolving registered services from the DI container
    /// </summary>
    public class AutofacServiceResolver : IServiceResolver
    {
        private readonly ILifetimeScope _container;

        /// <summary>
        /// Initializing the resolver dependencies
        /// </summary>
        /// <param name="container">An instance of the <see cref="ILifetimeScope"/> resolving services from Autofac</param>
        /// <exception cref="ArgumentNullException">Throws exception if the <see cref="ILifetimeScope"/> instance isn't provided</exception>
        public AutofacServiceResolver(ILifetimeScope container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <summary>
        /// Resolves a service by provided type
        /// </summary>
        /// <typeparam name="TService">The type of the service being resolved</typeparam>
        /// <returns>A resolved service instance</returns>
        public TService Resolve<TService>()
        {
            TService service = _container.Resolve<TService>();
            return service;
        }

        /// <summary>
        /// Resolves a service by provided type and key
        /// </summary>
        /// <typeparam name="TService">The type of the service being resolved</typeparam>
        /// <param name="key"></param>
        /// <returns>A resolved service instance</returns>
        public TService ResolveKeyed<TService>(object key)
        {
            TService service = _container.ResolveKeyed<TService>(key);
            return service;
        }

        /// <summary>
        /// Resolves a service by provided type and name
        /// </summary>
        /// <typeparam name="TService">The type of the service being resolved</typeparam>
        /// <param name="name"></param>
        /// <returns>A resolved service instance</returns>
        public TService ResolveNamed<TService>(string name)
        {
            TService service = _container.ResolveNamed<TService>(name);
            return service;
        }
    }
}
