using CampReview.Core.Models;

namespace CampReview.Api.Models
{
    public class CampgroundModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal[] Location { get; set; }

    }
}