using System.Linq;
using Raven.Client;
using Raven.Client.Document;

namespace CampReview.Core.Data
{
    /// <summary>
    /// Repository around RavenDB
    /// </summary>
    public class RavenDbRepository:IRepository
    {
        private readonly DocumentStore _documentStore;

        public RavenDbRepository(DocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public IQueryable<T> Find<T>() where T : class
        {
            var session = GetSession();

            return session.Query<T>();
        }

        public T Get<T>( object key ) where T : class
        {
            var session = GetSession();

            var keyAsString = key.ToString();
            return session.Load<T>(keyAsString);
        }

        public void Save<T>( T value )
        {
            var session = GetSession();
            session.Store(value);
            session.SaveChanges();
        }

        public void Delete<T>( T value )
        {
            var session = GetSession();
            session.Delete(value);
        }

        private IDocumentSession _session;
        private IDocumentSession GetSession()
        {
            if (_session == null)
                _session = _documentStore.OpenSession();

            return _session;
        }
    }
}