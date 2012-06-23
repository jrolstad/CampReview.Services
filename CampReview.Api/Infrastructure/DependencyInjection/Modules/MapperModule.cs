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

            Bind<IMapper<Campground, CampgroundModel>>().To<CampgroundMapper>();
            Bind<IMapper<CampgroundModel, Campground>>().To<AutoMapperMapper<CampgroundModel, Campground>>();
        }
    }
}