using System.Collections.Generic;
using System.Linq;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Data;
using CampReview.Core.Models;

namespace CampReview.Core.Commands
{
    public class GetRegionCommand:ICommand<GetRegionRequest,ICollection<Region>>
    {
        private readonly IRepository _repository;

        public GetRegionCommand(IRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Region> Execute( GetRegionRequest request )
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return _repository.Find<Region>().ToList();
            else
                return _repository
                    .Find<Region>()
                    .Where(r => r.Name == request.Name)
                    .ToList();
        }
    }
}