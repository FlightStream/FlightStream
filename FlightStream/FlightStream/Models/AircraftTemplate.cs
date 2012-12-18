using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightStream.Models {
    public class AircraftTemplate {
        public int Id { get; set; }
//        public string TailNumber { get; set; }
        public string Airframe { get; set; }
        public int EngineCount { get; set; }
        public int FuelTankCount { get; set; }
        public int SeatCount { get; set; }
        public int CargoHoldCount { get; set; }
        public int BasicOpWeight { get; set; }
        public int MaxOpWeight { get; set; }
        public int MaxTakeoffWeight { get; set; }
        public int MaxRampWeight { get; set; }
        public int MaxZeroFuelWeight { get; set; }
        public int MaxFuelCapacity { get; set; }
        public int EmptyWeight { get; set; }
        public int EmptyWeightCg { get; set; }
        public int EmptyWeightMoment { get; set; }
        public int MaxLandingWeight { get; set; }

    }
}