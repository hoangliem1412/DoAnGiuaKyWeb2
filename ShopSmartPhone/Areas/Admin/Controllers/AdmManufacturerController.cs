using ShopSmartPhone.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSmartPhone.Areas.Admin.Controllers
{
    public class AdmManufacturerController : Controller
    {
        // GET: Admin/AdmManufacturer
        public ActionResult Index()
        {
            return View(ManufacturerBus.getListManufacturer());
        }

        // GET: Admin/AdmManufacturer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AdmManufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdmManufacturer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdmManufacturer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/AdmManufacturer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdmManufacturer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AdmManufacturer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
