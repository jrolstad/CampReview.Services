using CampReview.Api.Models;
using CampReview.Core.Conversions;
using CampReview.Core.Models;

namespace CampReview.Api.Conversions
{
    public class CampsiteMapper:IMapper<Campsite,CampsiteModel>
    {
        public CampsiteModel Map(Campsite source)
        {
            var result = new CampsiteModel
                             {
                                 Id = source.Id,
                                 Name = source.Name,
                                 Location = source.Location == null ? null : new[]{source.Location.Latitude,source.Location.Longitude},
                                 Rating = source.Review == null ? 0 : source.Review.Rating
                             };

            return result;
        }
    }
}