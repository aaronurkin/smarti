namespace Smarti.Common.Services
{
    /// <summary>
    /// Generic models mapper
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public interface IDataMapper<in TSource, out TDestination>
    {
        /// <summary>
        /// Maps <see cref="TSource"/> instance into the <see cref="TDestination"/> one
        /// </summary>
        /// <param name="source">A <see cref="TSource"/> instance</param>
        /// <returns><see cref="TDestination"/> instance</returns>
        TDestination Map(TSource source);
    }
}
