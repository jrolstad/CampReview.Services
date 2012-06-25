using Ninject.Modules;

namespace CampReview.Data.InMemory
{
    public class DataModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<InMemoryRepository>().InSingletonScope();
        }
    }
}