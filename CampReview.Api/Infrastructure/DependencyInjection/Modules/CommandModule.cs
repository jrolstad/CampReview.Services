using System.Collections.Generic;
using CampReview.Core.Commands;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Models;
using Ninject.Modules;

namespace CampReview.Api.Infrastructure.DependencyInjection.Modules
{
    public class CommandModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICommand<Request, IEnumerable<Region>>>().To<GetRegionsCommand>();
            Bind<ICommand<string, Region>>().To<GetRegionCommand>();
        }
    }
}