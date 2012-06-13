using System.Collections.Generic;
using CampReview.Core.Commands;
using CampReview.Core.Commands.Requests;
using CampReview.Core.Models;
using Ninject.Modules;

namespace CampReview.Services.Infrastructure.DependencyInjection
{
    public class CommandModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICommand<GetRegionRequest, ICollection<Region>>>().To<GetRegionCommand>();
        }
    }
}