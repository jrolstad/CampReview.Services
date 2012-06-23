using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Core.Commands
{
    public class GetCampsiteCommand:ICommand<string, Campsite>
    {
        private readonly IRepository _repository;

        public GetCampsiteCommand(IRepository repository)
        {
            _repository = repository;
        }

        public Campsite Execute(string request)
        {
            var campsite = _repository.Get<Campsite>(request);

            return campsite;
        }
    }
}