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
    public class ClientsController : Controller
    {
        private FlightStreamContext db = new FlightStreamContext();

        //
        // GET: /Clients/

        public ViewResult Index()
        {
            return View(db.ClientModels.ToList());
        }

        //
        // GET: /Clients/Details/5

        public ViewResult Details(int id)
        {
            ClientModel clientmodel = db.ClientModels.Find(id);
            return View(clientmodel);
        }

        //
        // GET: /Clients/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Clients/Create

        [HttpPost]
        public ActionResult Create(ClientModel clientmodel)
        {
            if (ModelState.IsValid)
            {
                db.ClientModels.Add(clientmodel);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(clientmodel);
        }
        
        //
        // GET: /Clients/Edit/5
 
        public ActionResult Edit(int id)
        {
            ClientModel clientmodel = db.ClientModels.Find(id);
            return View(clientmodel);
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        public ActionResult Edit(ClientModel clientmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientmodel);
        }

        //
        // GET: /Clients/Delete/5
 
        public ActionResult Delete(int id)
        {
            ClientModel clientmodel = db.ClientModels.Find(id);
            return View(clientmodel);
        }

        //
        // POST: /Clients/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ClientModel clientmodel = db.ClientModels.Find(id);
            db.ClientModels.Remove(clientmodel);
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