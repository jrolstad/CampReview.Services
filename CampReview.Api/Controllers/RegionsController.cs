using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CampReview.Api.Infrastructure.DependencyInjection;
using CampReview.Api.Models;
using CampReview.Core.Commands;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Conversions;
using CampReview.Core.Models;

namespace CampReview.Api.Controllers
{
    public class RegionsController : Controller
    {
        private readonly ICommand<Request, IEnumerable<Region>> _getAllRegionsCommand;
        private readonly ICommand<string, Region> _getRegionCommand;
        private readonly IMapper<Region, RegionModel> _regionModelMapper;

        public RegionsController():
            this(
            IoC.Get<ICommand<Request, IEnumerable<Region>>>(),
            IoC.Get<ICommand<string, Region>>(),
            IoC.Get<IMapper<Region, RegionModel>>()
            )
        {
            
        }

        public RegionsController(ICommand<Request, IEnumerable<Region>> getAllRegionsCommand,
            ICommand<string,Region> _getRegionCommand,
            IMapper<Region,RegionModel> _regionModelMapper 
            )
        {
            _getAllRegionsCommand = getAllRegionsCommand;
            this._getRegionCommand = _getRegionCommand;
            this._regionModelMapper = _regionModelMapper;
        }

        public JsonResult GetAll()
        {
            var regions = _getAllRegionsCommand.Execute(Core.Commands.Requests.Request.Empty);
            var models = regions.Select(r => _regionModelMapper.Map(r)).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(string regionId)
        {
            var region = _getRegionCommand.Execute(regionId);
            var model = _regionModelMapper.Map(region);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
