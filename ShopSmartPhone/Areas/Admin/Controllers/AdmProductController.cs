using ShopSmartPhone.Areas.Admin.Models;
using ShopSmartPhone.Areas.Admin.ViewModels;
using ShopSmartPhoneConnection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSmartPhone.Areas.Admin.Controllers
{
    public class AdmProductController : Controller
    {
        public ActionResult Index()
        {
            var lstProduct = ProductBus.DanhSach();
            return View(lstProduct);
        }

        // GET: QuanLyProduct/Details/5
        public ActionResult Details(int id)
        {
            DetailProduct sp = ProductBus.DetailProduct(id);
            return View(sp);
        }

        // GET: QuanLyProduct/Create
        public ActionResult Create()
        {
            ViewBag.CategogyID = new SelectList(ProductBus.GetListCategogy(), "ID", "CategogyName");
            ViewBag.ManufacturerID = new SelectList(ProductBus.GetListManufacturer(), "ID", "ManufacturerName");

            return View();
        }

        // POST: QuanLyProduct/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product sp, HttpPostedFileBase Image)
        {
            //Kiểm tra hình ảnh
            if (Image != null)
            {
                var fileName = Path.GetFileName(Image.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Image"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hinh đã tồn tại";
                    return View();
                }
                else
                {
                    Image.SaveAs(path);
                    sp.Image = fileName;
                }

            }
            ProductBus.Insert(sp);
            return RedirectToAction("Index");
        }



        // GET: QuanLyProduct/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            var sp = ProductBus.GetProduct(id);
            if (sp == null)
            {
                HttpNotFound();
            }
            ViewBag.CategogyID = new SelectList(ProductBus.GetListCategogy(), "ID", "CategogyName", sp.CategogyID);
            ViewBag.ManufacturerID = new SelectList(ProductBus.GetListManufacturer(), "ID", "ManufacturerName", sp.ManufacturerID);
            ViewBag.ThongBao = "";
            return View(sp);
        }

        // POST: QuanLyProduct/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, Product sp, HttpPostedFileBase Image)
        {

            // TODO: Add update logic here
            if (Image != null)
            {
                var fileName = Path.GetFileName(Image.FileName);
                var path = Path.Combine(Server.MapPath("~/Image"), fileName);
                if (System.IO.File.Exists(path))
                {
                    sp.Image = fileName;
                }
                else
                {
                    Image.SaveAs(path);
                    sp.Image = fileName;
                }

            }
            else
            {
                ProductBus.UpdateNoImage(id, sp);
                return RedirectToAction("Index");
            }

            ProductBus.Update(id, sp);
            return RedirectToAction("Index");



        }

        // GET: QuanLyProduct/Delete/5
        public ActionResult Delete(int id)
        {
            var sp = ProductBus.DetailProduct(id);
            if (sp == null)
            {
                HttpNotFound();
            }
            ViewBag.CategogyID = new SelectList(ProductBus.GetListCategogy(), "ID", "CategogyName", sp.CategogyID);
            ViewBag.ManufacturerID = new SelectList(ProductBus.GetListManufacturer(), "ID", "ManufacturerName", sp);
            return View(sp);
        }

        // POST: QuanLyProduct/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ProductBus.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
