using System.Collections.Generic;
using System.Linq;
using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Core.Commands
{
    public class GetCampsitesInCampgroundCommand:ICommand<string, IEnumerable<Campsite>>
    {
        private readonly IRepository _repository;

        public GetCampsitesInCampgroundCommand(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Campsite> Execute(string request)
        {
            return _repository
              .Find<Campsite>()
              .Where(c => c.CampgroundId == request);
        }
    }
}