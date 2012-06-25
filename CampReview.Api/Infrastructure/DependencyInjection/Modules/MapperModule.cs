using CampReview.Api.Conversions;
using CampReview.Api.Models;
using CampReview.Core.Conversions;
using CampReview.Core.Models;
using Ninject.Modules;

namespace CampReview.Api.Infrastructure.DependencyInjection.Modules
{
    public class MapperModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper<Region, RegionModel>>().To<AutoMapperMapper<Region, RegionModel>>();
            Bind<IMapper<RegionModel, Region>>().To<AutoMapperMapper<RegionModel, Region>>();

            Bind<IMapper<Models.Requests.CreateCampgroundRequest, Core.Commands.Requests.CreateCampgroundRequest>>().To<AutoMapperMapper<Models.Requests.CreateCampgroundRequest, Core.Commands.Requests.CreateCampgroundRequest>>();
            Bind<IMapper<Campground, CampgroundModel>>().To<CampgroundMapper>();

            Bind<IMapper<Models.Requests.CreateCampsiteRequest, Core.Commands.Requests.CreateCampsiteRequest>>().To<AutoMapperMapper<Models.Requests.CreateCampsiteRequest, Core.Commands.Requests.CreateCampsiteRequest>>();
            Bind<IMapper<Models.Requests.CreateCampsiteReviewRequest, Core.Commands.Requests.CreateCampsiteReviewRequest>>().To<AutoMapperMapper<Models.Requests.CreateCampsiteReviewRequest, Core.Commands.Requests.CreateCampsiteReviewRequest>>();
            Bind<IMapper<Campsite, CampsiteModel>>().To<CampsiteMapper>();
           
        }
    }
}