using CampReview.Data;

namespace CampReview.Core.Models
{
    public class Campsite : IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public Review Review { get; set; }
    }
}