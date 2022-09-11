namespace Smarti.Common.Services
{
    /// <summary>
    /// Represents a service resolving registered services from the DI container
    /// </summary>
    public interface IServiceResolver
    {
        /// <summary>
        /// Resolves an inatance of a provided type from the DI container
        /// </summary>
        /// <typeparam name="TService">A service type to be resolved</typeparam>
        /// <returns></returns>
        TService Resolve<TService>();

        /// <summary>
        /// Resolves an inatance of a provided type by name from the DI container
        /// </summary>
        /// <typeparam name="TService">A service type to be resolved</typeparam>
        /// <param name="name">A named service name</param>
        /// <returns></returns>
        TService ResolveNamed<TService>(string name);

        /// <summary>
        /// Resolves an inatance of a provided type by key from the DI container
        /// </summary>
        /// <typeparam name="TService">A service type to be resolved</typeparam>
        /// <param name="key">A keyed service key</param>
        /// <returns></returns>
        TService ResolveKeyed<TService>(object key);
    }
}
