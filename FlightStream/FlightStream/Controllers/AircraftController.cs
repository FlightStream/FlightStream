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
        private FlightStreamContext context = new FlightStreamContext();

        //
        // GET: /Aircraft/

        public ViewResult Index()
        {
            return View(context.AircraftModels.ToList());
        }

        //
        // GET: /Aircraft/Details/5

        public ViewResult Details(int id)
        {
            AircraftModel aircraftmodel = context.AircraftModels.Single(x => x.Id == id);
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
                context.AircraftModels.Add(aircraftmodel);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(aircraftmodel);
        }
        
        //
        // GET: /Aircraft/Edit/5
 
        public ActionResult Edit(int id)
        {
            AircraftModel aircraftmodel = context.AircraftModels.Single(x => x.Id == id);
            return View(aircraftmodel);
        }

        //
        // POST: /Aircraft/Edit/5

        [HttpPost]
        public ActionResult Edit(AircraftModel aircraftmodel)
        {
            if (ModelState.IsValid)
            {
                context.Entry(aircraftmodel).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aircraftmodel);
        }

        //
        // GET: /Aircraft/Delete/5
 
        public ActionResult Delete(int id)
        {
            AircraftModel aircraftmodel = context.AircraftModels.Single(x => x.Id == id);
            return View(aircraftmodel);
        }

        //
        // POST: /Aircraft/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AircraftModel aircraftmodel = context.AircraftModels.Single(x => x.Id == id);
            context.AircraftModels.Remove(aircraftmodel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}