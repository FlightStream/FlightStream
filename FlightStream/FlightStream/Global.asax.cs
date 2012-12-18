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
            Database.SetInitializer(new FlightStreamInitializer());
        }
    }

    public class FlightStreamInitializer : DropCreateDatabaseAlways<FlightStreamContext>
    {
        protected override void Seed(FlightStreamContext context)
        {
//            context.AircraftModels.Add(new AircraftModel { Id = 1, Name = "Plane1" });
//            context.AircraftModels.Add(new AircraftModel { Id = 1, Name = "Plane2" });
            context.AircraftModels.Add(new AircraftModel {
                Id = 1,
                Airframe = "Airframe1",
                TailNumber = "TailNumber1",
                EngineCount = 1,
                FuelTankCount = 2,
                SeatCount = 3,
                CargoHoldCount = 4,
                BasicOpWeight = 5,
                MaxOpWeight = 6,
                MaxTakeoffWeight = 7,
                MaxRampWeight = 8,
                MaxZeroFuelWeight = 9,
                MaxFuelCapacity = 10,
                EmptyWeight = 11,
                EmptyWeightCg = 12,
                EmptyWeightMoment = 13,
                MaxLandingWeight = 14,
            });
            context.AircraftModels.Add(new AircraftModel {
                Id = 2,
                Airframe = "Airframe2",
                TailNumber = "TailNumber2",
                EngineCount = 1,
                FuelTankCount = 2,
                SeatCount = 3,
                CargoHoldCount = 4,
                BasicOpWeight = 5,
                MaxOpWeight = 6,
                MaxTakeoffWeight = 7,
                MaxRampWeight = 8,
                MaxZeroFuelWeight = 9,
                MaxFuelCapacity = 10,
                EmptyWeight = 11,
                EmptyWeightCg = 12,
                EmptyWeightMoment = 13,
                MaxLandingWeight = 14,
            });
            context.ClientModels.Add(new ClientModel { Id = 1, FirstName = "First", LastName = "Person" });
            context.ClientModels.Add(new ClientModel { Id = 1, FirstName = "Second", LastName = "Person" });

            context.AircraftTemplates.Add(new AircraftTemplate
                {
                    Id = 1,
                    Airframe = "Airframe1",
                    EngineCount = 1,
                    FuelTankCount = 2,
                    SeatCount = 3,
                    CargoHoldCount = 4,
                    BasicOpWeight = 5,
                    MaxOpWeight = 6,
                    MaxTakeoffWeight = 7,
                    MaxRampWeight = 8,
                    MaxZeroFuelWeight = 9,
                    MaxFuelCapacity = 10,
                    EmptyWeight = 11,
                    EmptyWeightCg = 12,
                    EmptyWeightMoment = 13,
                    MaxLandingWeight = 14,
                });
            context.AircraftTemplates.Add(new AircraftTemplate {
                Id = 2,
                Airframe = "Airframe2",
                EngineCount = 1,
                FuelTankCount = 2,
                SeatCount = 3,
                CargoHoldCount = 4,
                BasicOpWeight = 5,
                MaxOpWeight = 6,
                MaxTakeoffWeight = 7,
                MaxRampWeight = 8,
                MaxZeroFuelWeight = 9,
                MaxFuelCapacity = 10,
                EmptyWeight = 11,
                EmptyWeightCg = 12,
                EmptyWeightMoment = 13,
                MaxLandingWeight = 14,
            });
        }
    }
    
}