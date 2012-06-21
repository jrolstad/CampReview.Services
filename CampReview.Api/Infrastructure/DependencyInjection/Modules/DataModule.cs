using CampReview.Data;
using CampReview.Data.InMemory;
using Ninject.Modules;

namespace CampReview.Api.Infrastructure.DependencyInjection.Modules
{
    public class DataModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<InMemoryRepository>().InSingletonScope();
        }
    }
}