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
    public class PersonnelController : Controller
    {
        private FlightStreamContext db = new FlightStreamContext();

        //
        // GET: /Personnel/

        public ViewResult Index()
        {
            return View(db.Persons.ToList());
        }

        //
        // GET: /Personnel/Details/5

        public ViewResult Details(int id)
        {
            Person personmodel = db.Persons.Find(id);
            return View(personmodel);
        }

        //
        // GET: /Personnel/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Personnel/Create

        [HttpPost]
        public ActionResult Create(Person personmodel)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(personmodel);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(personmodel);
        }
        
        //
        // GET: /Personnel/Edit/5
 
        public ActionResult Edit(int id)
        {
            Person personmodel = db.Persons.Find(id);
            return View(personmodel);
        }

        //
        // POST: /Personnel/Edit/5

        [HttpPost]
        public ActionResult Edit(Person personmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personmodel);
        }

        //
        // GET: /Personnel/Delete/5
 
        public ActionResult Delete(int id)
        {
            Person personmodel = db.Persons.Find(id);
            return View(personmodel);
        }

        //
        // POST: /Personnel/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Person personmodel = db.Persons.Find(id);
            db.Persons.Remove(personmodel);
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