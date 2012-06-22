using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Core.Commands
{
    public class GetCampgroundCommand:ICommand<string, Campground>
    {
        private readonly IRepository _repository;

        public GetCampgroundCommand(IRepository repository)
        {
            _repository = repository;
        }

        public Campground Execute(string request)
        {
            return _repository.Get<Campground>(request);
        }
    }
}