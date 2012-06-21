using CampReview.Api.Infrastructure.DependencyInjection.Modules;
using Ninject;
using Ninject.Modules;

namespace CampReview.Api.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Service Locator class
    /// </summary>
    /// <remarks>
    /// Using this anti-pattern until the issues with Ninject.Web.WebApi are worked out
    /// </remarks>
    public static class IoC
    {
        /// <summary>
        /// Ninject kernel to use for resolution
        /// </summary>
        private static IKernel _kernel;

        /// <summary>
        /// Configures the given kernel and uses that kernel for resolution
        /// </summary>
        /// <param name="kernel"></param>
        public static void Configure(IKernel kernel)
        {
            _kernel = kernel;
            var modulesToLoad = new INinjectModule[]
                                    {
                                        new MapperModule() ,
                                        new DataModule(),
                                        new CommandModule()
                                    };
            kernel.Load(modulesToLoad);
        }

        /// <summary>
        /// Obtains an instance of a class
        /// </summary>
        /// <typeparam name="T">Type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
}