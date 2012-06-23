using System;
using System.Linq;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Core.Commands
{
    public class CreateCampgroundCommand:ICommand<CreateCampgroundRequest,Campground>
    {
        private readonly IRepository _repository;

        public CreateCampgroundCommand(IRepository repository)
        {
            _repository = repository;
        }

        public Campground Execute(CreateCampgroundRequest request)
        {
            var existingCampground = _repository.Find<Campground>()
                .Where(c => c.RegionId == request.RegionId)
                .Where(c => c.Name == request.Name)
                .FirstOrDefault();

            var campground = existingCampground ?? new Campground
                                                       {
                                                           Id = Guid.NewGuid().ToString(),
                                                           Name = request.Name,
                                                           RegionId = request.RegionId,
                                                       };

            campground.Location = new Location { Latitude = request.Location[0], Longitude = request.Location[1] };  

            _repository.Save(campground);

            return campground;
        }
    }
}