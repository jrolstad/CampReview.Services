using System.Configuration;
using MongoDB.Driver;
using Ninject.Modules;

namespace CampReview.Data.MongoDb
{
    public class MongoDbModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<MongoDbRepository>();
            Bind<MongoDatabase>().ToMethod(context =>
                                               {
                                                   var connectionString =ConfigurationManager.AppSettings["MONGOHQ_URL"];
                                                   var server = MongoServer.Create(connectionString);
 
                                                   var db = server.GetDatabase("a040dd40_78f4_4e51_a7da_8c22d37b18d2");

                                                   return db;
                                               });
        }
    }
}