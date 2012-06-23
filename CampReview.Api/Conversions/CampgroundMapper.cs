using CampReview.Api.Models;
using CampReview.Core.Conversions;
using CampReview.Core.Models;

namespace CampReview.Api.Conversions
{
    public class CampgroundMapper:IMapper<Campground,CampgroundModel>
    {
        public CampgroundModel Map(Campground source)
        {
            var result = new CampgroundModel
                             {
                                 Id = source.Id,
                                 Name = source.Name,
                                 Location = new[]{source.Location.Latitude,source.Location.Longitude}
                             };

            return result;
        }
    }
}