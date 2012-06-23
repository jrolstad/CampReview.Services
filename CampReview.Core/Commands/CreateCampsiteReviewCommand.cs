using CampReview.Core.Commands.Requests;
using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Core.Commands
{
    public class CreateCampsiteReviewCommand:ICommand<CreateCampsiteReviewRequest,Review>
    {
        private readonly IRepository _repository;

        public CreateCampsiteReviewCommand(IRepository repository)
        {
            _repository = repository;
        }

        public Review Execute(CreateCampsiteReviewRequest request)
        {
            var campsite = _repository.Get<Campsite>(request.CampsiteId);

            campsite.Review = new Review {Rating = request.Rating};

            _repository.Save(campsite);

            return campsite.Review;
        }
    }
}