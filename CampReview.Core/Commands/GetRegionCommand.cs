using System.Collections.Generic;
using System.Linq;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Models;
using CampReview.Data;

namespace CampReview.Core.Commands
{
    public class GetRegionCommand:ICommand<string, Region>
    {
        private readonly IRepository _repository;

        public GetRegionCommand(IRepository repository)
        {
            _repository = repository;
        }

        public Region Execute(string regionId)
        {
            return _repository.Get<Region>(regionId);
        }
    }
}