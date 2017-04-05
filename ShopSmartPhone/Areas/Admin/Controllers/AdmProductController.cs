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
            var lstSanPham = ProductBus.DanhSach();
            return View(lstSanPham);
        }

        // GET: QuanLySanPham/Details/5
        public ActionResult Details(int id)
        {
            DetailProduct sp = ProductBus.ChiTietSanPham(id);
            return View(sp);
        }

        // GET: QuanLySanPham/Create
        public ActionResult Create()
        {
            ViewBag.LoaiSanPham = new SelectList(ProductBus.GetListLoaiSanPham(), "ID", "TenLoai");
            ViewBag.HangSanXuat = new SelectList(ProductBus.GetListHangSanXuat(), "ID", "TenHang");

            return View();
        }

        // POST: QuanLySanPham/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(SanPham sp, HttpPostedFileBase HinhAnh)
        {
            //Kiểm tra hình ảnh
            if (HinhAnh.ContentLength > 0)
            {
                var fileName = Path.GetFileName(HinhAnh.FileName);
                var path = Path.Combine(Server.MapPath("~/Image"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hinh đã tồn tại";
                    return View();
                }
                else
                {
                    HinhAnh.SaveAs(path);
                    sp.HinhAnh = fileName;
                }

            }
            ProductBus.Insert(sp);
            return RedirectToAction("Index");
        }



        // GET: QuanLySanPham/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            var sp = ProductBus.GetSanPham(id);
            if (sp == null)
            {
                HttpNotFound();
            }
            ViewBag.LoaiSanPham = new SelectList(ProductBus.GetListLoaiSanPham(), "ID", "TenLoai", sp.LoaiSanPham);
            ViewBag.HangSanXuat = new SelectList(ProductBus.GetListHangSanXuat(), "ID", "TenHang", sp.HangSanXuat);
            ViewBag.ThongBao = "";
            return View(sp);
        }

        // POST: QuanLySanPham/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, SanPham sp, HttpPostedFileBase HinhAnh)
        {

            // TODO: Add update logic here
            if (HinhAnh != null)
            {
                var fileName = Path.GetFileName(HinhAnh.FileName);
                var path = Path.Combine(Server.MapPath("~/Image"), fileName);
                if (System.IO.File.Exists(path))
                {
                    sp.HinhAnh = fileName;
                }
                else
                {
                    HinhAnh.SaveAs(path);
                    sp.HinhAnh = fileName;
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

        // GET: QuanLySanPham/Delete/5
        public ActionResult Delete(int id)
        {
            var sp = ProductBus.ChiTietSanPham(id);
            if (sp == null)
            {
                HttpNotFound();
            }
            ViewBag.LoaiSanPham = new SelectList(ProductBus.GetListLoaiSanPham(), "ID", "TenLoai", sp.LoaiSanPham);
            ViewBag.HangSanXuat = new SelectList(ProductBus.GetListHangSanXuat(), "ID", "TenHang", sp.HangSanXuat);
            return View(sp);
        }

        // POST: QuanLySanPham/Delete/5
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
