using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CampReview.Api.Infrastructure.DependencyInjection;
using CampReview.Api.Models;
using CampReview.Core.Commands;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Conversions;
using CampReview.Core.Models;

namespace CampReview.Api.Controllers
{
    /// <summary>
    /// Api controller wrapping region data
    /// </summary>
    public class RegionsController : ApiController
    {
        private readonly IMapper<Region, RegionModel> _regionMapper;
        private readonly ICommand<Request, IEnumerable<Region>> _getRegionsCommand;
        private readonly ICommand<string, Region> _getRegionCommand;

        public RegionsController()
            : this(
            IoC.Get<IMapper<Region, RegionModel>>(),
            IoC.Get<ICommand<Request,IEnumerable<Region>>>(),
            IoC.Get<ICommand<string,Region>>()
            )
        {
            
        }

        public RegionsController(IMapper<Region, RegionModel> regionMapper, 
            ICommand<Request, IEnumerable<Region>> getRegionsCommand,
            ICommand<string,Region> _getRegionCommand )
        {
            _regionMapper = regionMapper;
            _getRegionsCommand = getRegionsCommand;
            this._getRegionCommand = _getRegionCommand;
        }

        // GET api/regions
        public IQueryable<RegionModel> Get()
        {
            var regions = _getRegionsCommand.Execute(CampReview.Core.Commands.Requests.Request.Empty);

            var regionModels = regions.Select(_regionMapper.Map).AsQueryable();

            return regionModels;
        }

        // GET api/regions/5
        public RegionModel Get(string id)
        {
            var region = _getRegionCommand.Execute(id);

            var regionModel = _regionMapper.Map(region);

            return regionModel;
        }
    }
}
