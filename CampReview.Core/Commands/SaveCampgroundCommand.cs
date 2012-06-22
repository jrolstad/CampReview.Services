using CampReview.Core.Commands.Responses;
using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Core.Commands
{
    public class SaveCampgroundCommand:ICommand<Campground,Response>
    {
        private readonly IRepository _repository;

        public SaveCampgroundCommand(IRepository repository)
        {
            _repository = repository;
        }

        public Response Execute(Campground request)
        {
            _repository.Save(request);

            return Defaults.DefaultResponse;
        }
    }
}