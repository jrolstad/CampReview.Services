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
    public class CampsitesController : Controller
    {
        private readonly ICommand<string, IEnumerable<Campsite>> _getCampsitesInRegionCommand;
        private readonly ICommand<string, Campsite> _getCampsiteCommand;
        private readonly IMapper<Campsite, CampsiteModel> _campsiteModelMapper;
        private readonly ICommand<Core.Commands.Requests.CreateCampsiteRequest, Campsite> _createCampsiteCommand;
        private readonly IMapper<CreateCampsiteRequest, Core.Commands.Requests.CreateCampsiteRequest> _createCampsiteRequestMapper;
        private readonly ICommand<Core.Commands.Requests.CreateCampsiteReviewRequest, Campsite> _createReviewCommand;
        private readonly IMapper<CreateCampsiteReviewRequest, Core.Commands.Requests.CreateCampsiteReviewRequest> _createReviewRequestMapper;

        public CampsitesController():
            this(
            IoC.Get<ICommand<string, IEnumerable<Campsite>>>(),
            IoC.Get<ICommand<string, Campsite>>(),
            IoC.Get<IMapper<Campsite, CampsiteModel>>(),

            IoC.Get<ICommand<Core.Commands.Requests.CreateCampsiteRequest, Campsite>>(),
            IoC.Get<IMapper<CreateCampsiteRequest,Core.Commands.Requests.CreateCampsiteRequest>>(),

            IoC.Get<ICommand<Core.Commands.Requests.CreateCampsiteReviewRequest, Campsite>>(),
            IoC.Get<IMapper<CreateCampsiteReviewRequest, Core.Commands.Requests.CreateCampsiteReviewRequest>>()
            )
        {
            
        }

        public CampsitesController(ICommand<string, IEnumerable<Campsite>> getCampsitesInRegionCommand, ICommand<string, Campsite> getCampsiteCommand, IMapper<Campsite, CampsiteModel> campsiteModelMapper, ICommand<Core.Commands.Requests.CreateCampsiteRequest, Campsite> createCampsiteCommand, IMapper<CreateCampsiteRequest, Core.Commands.Requests.CreateCampsiteRequest> createCampsiteRequestMapper, ICommand<Core.Commands.Requests.CreateCampsiteReviewRequest, Campsite> createReviewCommand, IMapper<CreateCampsiteReviewRequest, Core.Commands.Requests.CreateCampsiteReviewRequest> createReviewRequestMapper)
        {
            _getCampsitesInRegionCommand = getCampsitesInRegionCommand;
            _getCampsiteCommand = getCampsiteCommand;
            _campsiteModelMapper = campsiteModelMapper;
            _createCampsiteCommand = createCampsiteCommand;
            _createCampsiteRequestMapper = createCampsiteRequestMapper;
            _createReviewCommand = createReviewCommand;
            _createReviewRequestMapper = createReviewRequestMapper;
        }

        public JsonResult GetByCampground(string campgroundId)
        {
            var campsites = _getCampsitesInRegionCommand.Execute(campgroundId);
            var models = campsites.Select(r => _campsiteModelMapper.Map(r)).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(string campsiteId)
        {
            var campsite = _getCampsiteCommand.Execute(campsiteId);
            var model = _campsiteModelMapper.Map(campsite);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create(CreateCampsiteRequest webRequest)
        {
            var request = _createCampsiteRequestMapper.Map(webRequest);
            var campsite = _createCampsiteCommand.Execute(request);
            var campsiteModel = _campsiteModelMapper.Map(campsite);

            return Json(campsiteModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateReview(CreateCampsiteReviewRequest webRequest)
        {
            var request = _createReviewRequestMapper.Map(webRequest);
            var campsite = _createReviewCommand.Execute(request);
            var campsiteModel = _campsiteModelMapper.Map(campsite);

            return Json(campsiteModel, JsonRequestBehavior.AllowGet);
        }

    }
}