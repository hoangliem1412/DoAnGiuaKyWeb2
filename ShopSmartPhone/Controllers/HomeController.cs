using ShopSmartPhone.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSmartPhone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page=1)
        {
            return View(ProductBus.getListProductPage(page, 8));
        }

        public ActionResult MenuPartial()
        {
            ViewBag.ListManu = ManufacturerBus.getListManufacturer();
            return PartialView(CategogyBus.getListCategogy());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}