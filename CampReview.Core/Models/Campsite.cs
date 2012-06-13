namespace CampReview.Core.Models
{
    public class Campsite
    {
        public string CampsiteId { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public Review Review { get; set; }
    }
}