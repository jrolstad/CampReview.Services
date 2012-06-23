namespace CampReview.Core.Commands.Requests
{
    public class CreateCampgroundRequest
    {
        public string RegionId { get; set; }

        public string Name { get; set; }

        public decimal[] Location { get; set; }
    }
}