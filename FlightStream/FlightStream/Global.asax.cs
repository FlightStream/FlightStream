using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FlightStream.Models;

namespace FlightStream {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<FlightStreamContext>(new FlightStreamInitializer());
        }
    }

    public class FlightStreamInitializer : DropCreateDatabaseIfModelChanges<FlightStreamContext>
    {
        protected override void Seed(FlightStreamContext context)
        {
            context.AircraftModels.Add(new AircraftModel { Id = 1, Name = "Plane1" });
            context.AircraftModels.Add(new AircraftModel { Id = 1, Name = "Plane2" });

            context.ClientModels.Add(new ClientModel { Id = 1, FirstName = "First", LastName = "Person" });
            context.ClientModels.Add(new ClientModel { Id = 1, FirstName = "Second", LastName = "Person" });
        }
    }
}