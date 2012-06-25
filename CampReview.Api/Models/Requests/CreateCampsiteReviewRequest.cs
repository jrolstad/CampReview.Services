namespace CampReview.Api.Models.Requests
{
    public class CreateCampsiteReviewRequest
    {
        public string CampsiteId { get; set; }

        public int Rating { get; set; }
    }
}