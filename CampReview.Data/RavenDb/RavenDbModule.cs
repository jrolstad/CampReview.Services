//using CampReview.Data.InMemory;
//using Ninject.Modules;
//using Raven.Client;
//using Raven.Client.Document;

//namespace CampReview.Data.RavenDb
//{
//    public class RavenDbModule:NinjectModule
//    {
//        public override void Load()
//        {
//            Bind<IRepository>().To<RavenDbRepository>();
//            Bind<IDocumentStore>().ToMethod(context =>
//                                                {
//                                                    var store = new DocumentStore {ConnectionStringName = "RavenDB"};
//                                                    store.Initialize();

//                                                    return store;
//                                                });
//        }
//    }
//}