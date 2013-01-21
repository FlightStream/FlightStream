using System.Data;
using System.Linq;
using System.Web.Mvc;
using FlightStream.Models;

namespace FlightStream.Controllers
{   
    public class AircraftController : Controller
    {
        private readonly FlightStreamContext _context = new FlightStreamContext();

        //
        // GET: /Aircraft/

        public ViewResult Index()
        {
            return View(_context.AircraftModels.ToList());
        }

        //
        // GET: /Aircraft/Details/5

        public ViewResult Details(int id)
        {
            AircraftModel aircraftmodel = _context.AircraftModels.Single(x => x.Id == id);
            return View(aircraftmodel);
        }

        //
        // GET: /Aircraft/Create

        public ActionResult Create()
        {
            var templates = _context.AircraftTemplates.Select(x => new SelectListItem {Text = x.Airframe, Value = x.Id.ToString()});
            var aircraftModel = new AircraftModel {AircraftTemplates = templates};
            return View(aircraftModel);
        }

        // /Aircraft/CreateFrom/5
//        [HttpPost]
//        public ActionResult CreateFrom(AircraftModel model)
//        {
//
//            var aircraftTemplate = _context.AircraftTemplates.Single(x => x.Id == aircraftTemplateId);
//            var aircraftModel = AdaptAircraft(aircraftTemplate);
//            return Create(aircraftModel);
//
//
//        }

        AircraftModel AdaptAircraft(AircraftTemplate t)
        {
            var result = new AircraftModel
                {
                    Airframe = t.Airframe,
                    BasicOpWeight = t.BasicOpWeight,
                    CargoHoldCount = t.CargoHoldCount,
                    EmptyWeight = t.EmptyWeight,
                    EmptyWeightCg = t.EmptyWeightCg,
                    EmptyWeightMoment = t.EmptyWeightMoment,
                    EngineCount = t.EngineCount,
                    FuelTankCount = t.FuelTankCount,
                    MaxFuelCapacity = t.MaxFuelCapacity,
                    SeatCount = t.SeatCount,
                    MaxZeroFuelWeight = t.MaxZeroFuelWeight,
                    MaxLandingWeight = t.MaxLandingWeight,
                    MaxOpWeight = t.MaxOpWeight,
                    MaxRampWeight = t.MaxRampWeight,
                    MaxTakeoffWeight = t.MaxTakeoffWeight,
                };
            return result;
        }

        //
        // POST: /Aircraft/Create

        [HttpPost]
        public ActionResult Create(AircraftModel aircraftmodel)
        {
            if (ModelState.IsValid)
            {
                _context.AircraftModels.Add(aircraftmodel);
                _context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(aircraftmodel);
        }
        
        //
        // GET: /Aircraft/Edit/5
 
        public ActionResult Edit(int id)
        {
            AircraftModel aircraftmodel = _context.AircraftModels.Single(x => x.Id == id);
            return View(aircraftmodel);
        }

        //
        // POST: /Aircraft/Edit/5

        [HttpPost]
        public ActionResult Edit(AircraftModel aircraftmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(aircraftmodel).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aircraftmodel);
        }

        //
        // GET: /Aircraft/Delete/5
 
        public ActionResult Delete(int id)
        {
            AircraftModel aircraftmodel = _context.AircraftModels.Single(x => x.Id == id);
            return View(aircraftmodel);
        }

        //
        // POST: /Aircraft/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AircraftModel aircraftmodel = _context.AircraftModels.Single(x => x.Id == id);
            _context.AircraftModels.Remove(aircraftmodel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
