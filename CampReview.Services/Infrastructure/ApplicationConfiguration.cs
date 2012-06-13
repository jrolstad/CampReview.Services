using CampReview.Services.Infrastructure.DependencyInjection;
using Ninject;
using Ninject.Modules;

namespace CampReview.Services.Infrastructure
{
    public static class ApplicationConfiguration
    {
        public static void Configure(IKernel kernel)
        {
            ConfigureIoC(kernel);
        }

        private static void ConfigureIoC(IKernel kernel)
        {
            var modulesToLoad = new NinjectModule[]
                                    {
                                        new CommandModule(),
                                        new DataModule(),
                                        new MapperModule()
                                    };

            kernel.Load(modulesToLoad);
        }
    }
}