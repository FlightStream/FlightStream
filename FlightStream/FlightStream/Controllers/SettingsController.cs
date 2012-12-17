using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightStream.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeEmail(string newEmail)
        {
            //todo: validate new Email address
            //todo: update DB
            return View("Index");
        }
    }
}
