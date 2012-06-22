using System.Collections.Generic;
using System.Linq;
using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Core.Commands
{
    public class GetCampgroundsInRegionCommand:ICommand<string, IEnumerable<Campground>>
    {
       private readonly IRepository _repository;

       public GetCampgroundsInRegionCommand(IRepository repository)
       {
           _repository = repository;
       }

       public IEnumerable<Campground> Execute(string regionId)
       {
           return _repository
               .Find<Campground>()
               .Where(c => c.RegionId == regionId);
       }
    }
}