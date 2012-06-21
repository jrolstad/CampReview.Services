using System.Collections.Generic;
using System.Linq;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Data;
using CampReview.Core.Models;

namespace CampReview.Core.Commands
{
    public class GetRegionsCommand:ICommand<Request, ICollection<Region>>
    {
        private readonly IRepository _repository;

        public GetRegionsCommand(IRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Region> Execute(Request request)
        {
            return _repository.Find<Region>().ToList();
        }
    }
}