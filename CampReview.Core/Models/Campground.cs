using CampReview.Data;

namespace CampReview.Core.Models
{
    public class Campground: IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public Review Review { get; set; }

        public string RegionId { get; set; }
    }
}