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
            return View(_context.Aircrafts.ToList());
        }

        //
        // GET: /Aircraft/Details/5

        public ViewResult Details(int id)
        {
            Aircraft aircraftmodel = _context.Aircrafts.Single(x => x.Id == id);
            return View(aircraftmodel);
        }

        //
        // GET: /Aircraft/Create

        public ActionResult Create()
        {
            var templates = _context.AircraftTemplates.Select(x => new SelectListItem {Text = x.Airframe, Value = x.Id.ToString()});
            var aircraftModel = new Aircraft {AircraftTemplates = templates};
            return View(aircraftModel);
        }

        // /Aircraft/CreateFrom/5
//        [HttpPost]
//        public ActionResult CreateFrom(Aircraft model)
//        {
//
//            var aircraftTemplate = _context.AircraftTemplates.Single(x => x.Id == aircraftTemplateId);
//            var aircraftModel = AdaptAircraft(aircraftTemplate);
//            return Create(aircraftModel);
//
//
//        }

        Aircraft AdaptAircraft(AircraftTemplate t)
        {
            var result = new Aircraft
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
        public ActionResult Create(Aircraft aircraftmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Aircrafts.Add(aircraftmodel);
                _context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(aircraftmodel);
        }
        
        //
        // GET: /Aircraft/Edit/5
 
        public ActionResult Edit(int id)
        {
            Aircraft aircraftmodel = _context.Aircrafts.Single(x => x.Id == id);
            return View(aircraftmodel);
        }

        //
        // POST: /Aircraft/Edit/5

        [HttpPost]
        public ActionResult Edit(Aircraft aircraftmodel)
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
            Aircraft aircraftmodel = _context.Aircrafts.Single(x => x.Id == id);
            return View(aircraftmodel);
        }

        //
        // POST: /Aircraft/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Aircraft aircraftmodel = _context.Aircrafts.Single(x => x.Id == id);
            _context.Aircrafts.Remove(aircraftmodel);
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
