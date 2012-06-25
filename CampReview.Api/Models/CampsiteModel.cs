using CampReview.Core.Models;

namespace CampReview.Api.Models
{
    public class CampsiteModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal[] Location { get; set; }

        public int Rating { get; set; }

        public string CampgroundId { get; set; }
    }
}