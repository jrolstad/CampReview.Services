using System.Collections.Generic;
using System.Web.Mvc;
using CampReview.Core.Commands;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Conversions;
using CampReview.Core.Models;
using CampReview.Services.Models;

namespace CampReview.Services.Controllers
{
    public class RegionController : Controller
    {
        private readonly ICommand<GetRegionRequest, ICollection<Region>> _getCommand;
        private readonly IMapper<IEnumerable<Region>, IEnumerable<RegionResponseModel>> _regionMapper;

        public RegionController(ICommand<GetRegionRequest,ICollection<Region>> getCommand,IMapper<IEnumerable<Region>,IEnumerable<RegionResponseModel>> regionMapper)
        {
            _getCommand = getCommand;
            _regionMapper = regionMapper;
        }

        public JsonResult Index(string name)
        {
            var request = new GetRegionRequest {Name = name};
            var commandResult = _getCommand.Execute(request);

            var regions = _regionMapper.Map(commandResult);

            return Json(regions, JsonRequestBehavior.AllowGet);
        }

    }
}
