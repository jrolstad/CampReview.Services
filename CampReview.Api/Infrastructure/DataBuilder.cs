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
            BuildCampgrounds();
        }

        private void BuildRegions()
        {
            if (_repository.Find<Region>().Any()) return;

            _repository.Save(new Region{Id = "1",Name = "Washington"});
            _repository.Save(new Region{Id = "2",Name = "Oregon"});
            _repository.Save(new Region{Id = "3",Name = "Idaho"});
        }

        private void BuildCampgrounds()
        {
            if (_repository.Find<Campground>().Any()) return;

            _repository.Save(new Campground{Id="1",Name = "South Beach State Park",RegionId = "2",Location = new Location{Latitude = 1,Longitude = 2}});
            _repository.Save(new Campground{Id="2",Name = "Beverly Beach State Park",RegionId = "2",Location = new Location{Latitude = 1,Longitude = 2}});
            _repository.Save(new Campground{Id="3",Name = "Devil Lake State Park",RegionId = "2",Location = new Location{Latitude = 1,Longitude = 2}});
            _repository.Save(new Campground{Id="4",Name = "Nehalem Bay State Park",RegionId = "2",Location = new Location{Latitude = 1,Longitude = 2}});

        }
}
}