using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CampReview.Api.Infrastructure.DependencyInjection;
using CampReview.Api.Models;
using CampReview.Api.Models.Requests;
using CampReview.Core.Commands;
using CampReview.Core.Conversions;
using CampReview.Core.Models;

namespace CampReview.Api.Controllers
{
    public class CampgroundsController : Controller
    {
        private readonly ICommand<string, IEnumerable<Campground>> _getCampgroundsInRegionCommand;
        private readonly ICommand<string, Campground> _getCampgroundCommand;
        private readonly IMapper<Campground, CampgroundModel> _campgroundModelMapper;
        private readonly ICommand<Core.Commands.Requests.CreateCampgroundRequest, Campground> _createCampgroundCommand;
        private readonly IMapper<CreateCampgroundRequest, Core.Commands.Requests.CreateCampgroundRequest> _createCampgroundRequestMapper;

        public CampgroundsController():
            this(
            IoC.Get<ICommand<string, IEnumerable<Campground>>>(),
            IoC.Get<ICommand<string, Campground>>(),
            IoC.Get<IMapper<Campground, CampgroundModel>>(),
            IoC.Get<ICommand<Core.Commands.Requests.CreateCampgroundRequest, Campground>>(),
            IoC.Get<IMapper<CreateCampgroundRequest,Core.Commands.Requests.CreateCampgroundRequest>>()
            )
        {
            
        }

        public CampgroundsController(ICommand<string, IEnumerable<Campground>> getCampgroundsInRegionCommand, ICommand<string, Campground> getCampgroundCommand, IMapper<Campground, CampgroundModel> campgroundModelMapper, ICommand<Core.Commands.Requests.CreateCampgroundRequest, Campground> createCampgroundCommand, IMapper<CreateCampgroundRequest, Core.Commands.Requests.CreateCampgroundRequest> createCampgroundRequestMapper)
        {
            _getCampgroundsInRegionCommand = getCampgroundsInRegionCommand;
            _getCampgroundCommand = getCampgroundCommand;
            _campgroundModelMapper = campgroundModelMapper;
            _createCampgroundCommand = createCampgroundCommand;
            _createCampgroundRequestMapper = createCampgroundRequestMapper;
        }

        public JsonResult GetByRegion(string regionId)
        {
            var campgrounds = _getCampgroundsInRegionCommand.Execute(regionId);
            var models = campgrounds.Select(r => _campgroundModelMapper.Map(r)).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(string campgroundId)
        {
            var campground = _getCampgroundCommand.Execute(campgroundId);
            var model = _campgroundModelMapper.Map(campground);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(CreateCampgroundRequest webRequest)
        {
            var request = _createCampgroundRequestMapper.Map(webRequest);
            var campground = _createCampgroundCommand.Execute(request);
            var campgroundModel = _campgroundModelMapper.Map(campground);

            return Json(campgroundModel, JsonRequestBehavior.AllowGet);
        }

    }
}
