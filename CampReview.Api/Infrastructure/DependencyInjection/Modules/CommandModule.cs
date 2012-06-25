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

            Bind<ICommand<string, IEnumerable<Campground>>>().To<GetCampgroundsInRegionCommand>();
            Bind<ICommand<string, Campground>>().To<GetCampgroundCommand>();
            Bind<ICommand<CreateCampgroundRequest, Campground>>().To<CreateCampgroundCommand>();

            Bind<ICommand<string, IEnumerable<Campsite>>>().To<GetCampsitesInCampgroundCommand>();
            Bind<ICommand<string, Campsite>>().To<GetCampsiteCommand>();
            Bind<ICommand<CreateCampsiteRequest, Campsite>>().To<CreateCampsiteCommand>();
            Bind<ICommand<CreateCampsiteReviewRequest, Campsite>>().To<CreateCampsiteReviewCommand>();


        }
    }
}