using CampReview.Core.Data;
using Ninject.Modules;

namespace CampReview.Services.Infrastructure.DependencyInjection
{
    public class DataModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<RavenDbRepository>();
        }
    }
}