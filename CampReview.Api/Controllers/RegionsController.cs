using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public RegionsController()
            : this(
            IoC.Get<IMapper<Region, RegionModel>>(),
            IoC.Get<ICommand<Request,IEnumerable<Region>>>()
            )
        {
            
        }

        public RegionsController(IMapper<Region, RegionModel> regionMapper, ICommand<Request, IEnumerable<Region>> getRegionsCommand)
        {
            _regionMapper = regionMapper;
            _getRegionsCommand = getRegionsCommand;
        }

        // GET api/regions
        public IEnumerable<RegionModel> Get()
        {
            var regions = _getRegionsCommand.Execute(Defaults.DefaultRequest);

            var regionModels = regions.Select(_regionMapper.Map);

            return regionModels;
        }

        // GET api/regions/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/regions
        public void Post(string value)
        {
        }

        // PUT api/regions/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/regions/5
        public void Delete(int id)
        {
        }
    }
}
