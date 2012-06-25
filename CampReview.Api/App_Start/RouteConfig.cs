using System.Web.Mvc;
using System.Web.Routing;

namespace CampReview.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Default",url: "",defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            CreateRegionsMap(routes);

            CreateCampgroundsMap(routes);

            CreateCampsitesMap(routes);
        }

        private static void CreateCampsitesMap(RouteCollection routes)
        {
            routes.MapRoute(name: "CampsitesGet",
                            url: "Campsites/{campsiteId}",
                            defaults: new {controller = "Campsites", action = "Get"});
            routes.MapRoute(name: "CampsitesGetByCamground",
                            url: "Campgrounds/{campgroundId}/Campsites",
                            defaults: new {controller = "Campsites", action = "GetByCampground"});
            routes.MapRoute(name: "CampsitesCreate",
                            url: "Campsites/Create",
                            defaults: new {controller = "Campsites", action = "Create"});
            routes.MapRoute(name: "CampsitesReview",
                            url: "Campsites/Review",
                            defaults: new {controller = "Campsites", action = "CreateReview"});
        }

        private static void CreateCampgroundsMap(RouteCollection routes)
        {
            routes.MapRoute(name: "CampgroundGet",
                            url: "Campgrounds/{campgroundId}",
                            defaults: new {controller = "Campgrounds", action = "Get"});
            routes.MapRoute(name: "CampgroundsGetByRegion",
                            url: "Regions/{regionId}/Campgrounds",
                            defaults: new {controller = "Campgrounds", action = "GetByRegion"});
            routes.MapRoute(name: "CampgroundCreate",
                            url: "Campgrounds/Create",
                            defaults: new {controller = "Campgrounds", action = "Create"});
        }

        private static void CreateRegionsMap(RouteCollection routes)
        {
            routes.MapRoute(name: "RegionsGetAll",
                            url: "Regions/",
                            defaults: new {controller = "Regions", action = "GetAll"});
            routes.MapRoute(name: "RegionGet",
                            url: "Regions/{regionId}",
                            defaults: new {controller = "Regions", action = "Get"});
        }
    }
}