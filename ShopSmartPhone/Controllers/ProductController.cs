using ShopSmartPhone.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSmartPhone.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Detail(int id)
        {
            return View(ProductBus.getDetailProduct(id));
        }

        public ActionResult ProductToCate(int id, int page = 1)
        {
            return View(ProductBus.getListProductFollowCate(page, 8, id));
        }

        public ActionResult ProductToManu(int id, int page = 1)
        {
            return View(ProductBus.getListProductFollowManu(page, 8, id));
        }
    }
}