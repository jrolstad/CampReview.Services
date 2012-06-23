using System;
using System.Linq;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Core.Commands
{
    public class CreateCampsiteCommand:ICommand<CreateCampsiteRequest,Campsite>
    {
        private readonly IRepository _repository;

        public CreateCampsiteCommand(IRepository repository)
        {
            _repository = repository;
        }

        public Campsite Execute(CreateCampsiteRequest request)
        {
            var existingCampsite = _repository.Find<Campsite>()
                .Where(c => c.CampgroundId == request.CampgroundId)
                .Where(c => c.Name == request.Name)
                .FirstOrDefault();

            var campsite = existingCampsite ?? new Campsite()
                                                       {
                                                           Id = Guid.NewGuid().ToString(),
                                                           Name = request.Name,
                                                           CampgroundId = request.CampgroundId,
                                                           };
            campsite.Location = new Location {Latitude = request.Location[0], Longitude = request.Location[1]};                     

            _repository.Save(campsite);

            return campsite;
        }
    }
}