using ShopSmartPhone.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSmartPhone.Areas.Admin.Controllers
{
    public class AdmCategogyController : Controller
    {
        // GET: Admin/AdmCategogy
        public ActionResult Index()
        {
            return View(CategogyBus.getListCategogy());
        }

        // GET: Admin/AdmCategogy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AdmCategogy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdmCategogy/Create
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

        // GET: Admin/AdmCategogy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/AdmCategogy/Edit/5
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

        // GET: Admin/AdmCategogy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AdmCategogy/Delete/5
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
