using System.Collections.Generic;
using CampReview.Core.Conversions;
using CampReview.Core.Models;
using CampReview.Services.Models;
using Ninject.Modules;

namespace CampReview.Services.Infrastructure.DependencyInjection
{
    public class MapperModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper<IEnumerable<Region>, IEnumerable<RegionResponseModel>>>().To<AutoMapperMapper<IEnumerable<Region>, IEnumerable<RegionResponseModel>>>();
        }
    }
}