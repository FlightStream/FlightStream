using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightStream.Models;

namespace FlightStream.Controllers
{ 
    public class AircraftController : Controller
    {
        private FlightStreamContext db = new FlightStreamContext();

        //
        // GET: /Aircraft/

        public ViewResult Index()
        {
            return View(db.AircraftModels.ToList());
        }

        //
        // GET: /Aircraft/Details/5

        public ViewResult Details(int id)
        {
            AircraftModel aircraftmodel = db.AircraftModels.Find(id);
            return View(aircraftmodel);
        }

        //
        // GET: /Aircraft/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Aircraft/Create

        [HttpPost]
        public ActionResult Create(AircraftModel aircraftmodel)
        {
            if (ModelState.IsValid)
            {
                db.AircraftModels.Add(aircraftmodel);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(aircraftmodel);
        }
        
        //
        // GET: /Aircraft/Edit/5
 
        public ActionResult Edit(int id)
        {
            AircraftModel aircraftmodel = db.AircraftModels.Find(id);
            return View(aircraftmodel);
        }

        //
        // POST: /Aircraft/Edit/5

        [HttpPost]
        public ActionResult Edit(AircraftModel aircraftmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aircraftmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aircraftmodel);
        }

        //
        // GET: /Aircraft/Delete/5
 
        public ActionResult Delete(int id)
        {
            AircraftModel aircraftmodel = db.AircraftModels.Find(id);
            return View(aircraftmodel);
        }

        //
        // POST: /Aircraft/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            AircraftModel aircraftmodel = db.AircraftModels.Find(id);
            db.AircraftModels.Remove(aircraftmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}