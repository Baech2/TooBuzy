using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TooBuzyWebClient.TooBuzyServiceReference;

namespace TooBuzyWebClient.Controllers
{
    public class CustomerController : Controller
    {
        private TooBuzyServiceReference.TooBuzyServiceClient proxy = new TooBuzyServiceReference.TooBuzyServiceClient("TooBuzyServies");

        public ActionResult Index()
        {
            return View(proxy.GetAllCustomers().ToList());
        }
        public ActionResult Details(int Id)
        {
            Customer cus = proxy.GetCustomerById(Id);
            if (cus == null)
            {
                return HttpNotFound();
            }
            return View(cus);
        }
        public ActionResult _MenuPartial(int Id)
        {
            Menu menu = proxy.GetMenuById(Id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return PartialView(menu);
        }
    }
}