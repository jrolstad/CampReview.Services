namespace CampReview.Core.Models
{
    public class Campground
    {
        public string CampgroundId { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public Review Review { get; set; }

        public string RegionId { get; set; }
    }
}