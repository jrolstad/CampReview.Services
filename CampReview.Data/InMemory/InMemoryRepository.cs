using System.Collections.Generic;
using System.Linq;

namespace CampReview.Data.InMemory
{
    public class InMemoryRepository:IRepository
    {
        private readonly List<object> _entities = new List<object>();

        public IQueryable<T> Find<T>() where T : IEntity
        {
            return _entities.OfType<T>().ToList().AsQueryable();
        }

        public T Get<T>(object key) where T : IEntity
        {
            return _entities.OfType<T>().SingleOrDefault(e => e.Id == key.ToString());
        }

        public void Save<T>(T value)
        {
            this.Delete(value);
            _entities.Add(value);
        }

        public void Delete<T>(T value)
        {
            _entities.Remove(value);
        }
    }
}