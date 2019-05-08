using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TooBuzyWebClient.Controllers
{
    public class HomeController : Controller
    {
       private TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");

        public ActionResult Index()
        {
            
            return View(proxy.GetAllCustomers().ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Om os beskrivelse";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt side";

            return View();
        }
    }
}