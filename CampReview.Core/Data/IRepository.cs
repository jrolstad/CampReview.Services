using System.Linq;

namespace CampReview.Core.Data
{
    public interface IRepository
    {
        IQueryable<T> Find<T>() where T : class;

        T Get<T>(object key) where T : class;

        void Save<T>(T value);

        void Delete<T>(T value);
    }
}