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
    public class AircraftTemplateController : Controller
    {
        private FlightStreamContext context = new FlightStreamContext();

        //
        // GET: /AircraftTemplate/

        public ViewResult Index()
        {
            return View(context.AircraftTemplates.ToList());
        }

        //
        // GET: /AircraftTemplate/Details/5

        public ViewResult Details(int id)
        {
            AircraftTemplate aircrafttemplate = context.AircraftTemplates.Single(x => x.Id == id);
            return View(aircrafttemplate);
        }

        //
        // GET: /AircraftTemplate/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AircraftTemplate/Create

        [HttpPost]
        public ActionResult Create(AircraftTemplate aircrafttemplate)
        {
            if (ModelState.IsValid)
            {
                context.AircraftTemplates.Add(aircrafttemplate);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(aircrafttemplate);
        }
        
        //
        // GET: /AircraftTemplate/Edit/5
 
        public ActionResult Edit(int id)
        {
            AircraftTemplate aircrafttemplate = context.AircraftTemplates.Single(x => x.Id == id);
            return View(aircrafttemplate);
        }

        //
        // POST: /AircraftTemplate/Edit/5

        [HttpPost]
        public ActionResult Edit(AircraftTemplate aircrafttemplate)
        {
            if (ModelState.IsValid)
            {
                context.Entry(aircrafttemplate).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aircrafttemplate);
        }

        //
        // GET: /AircraftTemplate/Delete/5
 
        public ActionResult Delete(int id)
        {
            AircraftTemplate aircrafttemplate = context.AircraftTemplates.Single(x => x.Id == id);
            return View(aircrafttemplate);
        }

        //
        // POST: /AircraftTemplate/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AircraftTemplate aircrafttemplate = context.AircraftTemplates.Single(x => x.Id == id);
            context.AircraftTemplates.Remove(aircrafttemplate);
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