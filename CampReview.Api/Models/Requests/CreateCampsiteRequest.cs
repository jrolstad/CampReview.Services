namespace CampReview.Api.Models.Requests
{
    public class CreateCampsiteRequest
    {
        public string CampgroundId { get; set; }

        public string Name { get; set; }

        public decimal[] Location { get; set; }
    }
}