using System.Linq;
using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Api.Infrastructure
{
    public class DataBuilder
    {
        private readonly IRepository _repository;

        public DataBuilder(IRepository repository)
        {
            _repository = repository;
        }

        public void Build()
        {
            BuildRegions();
        }

        private void BuildRegions()
        {
            if (_repository.Find<Region>().Any()) return;

            _repository.Save(new Region{Id = "1",Name = "Washington"});
            _repository.Save(new Region{Id = "2",Name = "Oregon"});
            _repository.Save(new Region{Id = "3",Name = "Idaho"});
        }
}
}