using System.Linq;

namespace CampReview.Data
{
    public interface IRepository
    {
        IQueryable<T> Find<T>() where T : IEntity;

        T Get<T>(object key) where T : IEntity;

        void Save<T>(T value);

        void Delete<T>(T value);
    }
}