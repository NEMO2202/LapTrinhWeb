using DeThi2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeThi2.Controllers
{
    public class DeThi2Controller : Controller
    {
        // GET: DeThi2
        QLBanQuanAo db = new QLBanQuanAo();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RenderMenu()
        {
            List<PhanLoaiPhu> listplp = db.PhanLoaiPhus.ToList();
            return PartialView("Menu", listplp);
        }
        public ActionResult RenderProduct()
        {
            List<SanPham> listsp = db.SanPhams.ToList();
            return PartialView("Product", listsp);
        }
        public ActionResult RenderProductByMenu(int maloai)
        {
            List<SanPham> list = db.SanPhams.Where(x => x.MaPhanLoai ==  maloai).ToList();
            return PartialView("Product", list);
        }
        public ActionResult EditProduct(int Id)
        {
            var SPmodel = db.SanPhams.Find(Id);
            ViewBag.MaPhanLoai = db.PhanLoais.ToList();
            ViewBag.MaPhanLoaiPhu = db.PhanLoaiPhus.ToList();
            return View(SPmodel);

        }
        [HttpPost]
        public ActionResult EditProduct(Models.Entities.SanPham sp)
        {
            var update = db.SanPhams.Find(sp.MaSanPham);
            if (sp.MaSanPham > 0)
            {
                update.TenSanPham = sp.TenSanPham;
                update.MaPhanLoai = sp.MaPhanLoai;
                update.GiaNhap = sp.GiaNhap;
                update.DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat;
                update.DonGiaBanLonNhat = sp.DonGiaBanLonNhat;
                update.TrangThai = sp.TrangThai;
                update.MoTaNgan = sp.MoTaNgan;
                update.AnhDaiDien = sp.AnhDaiDien;
                update.NoiBat = sp.NoiBat;
                update.MaPhanLoaiPhu = sp.MaPhanLoaiPhu;
                // db.SanPhams.Add(sp);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    ViewBag.MaPhanLoai = db.PhanLoais.ToList();
                    ViewBag.MaPhanLoaiPhu = db.PhanLoaiPhus.ToList();
                    return View(sp);
                    //var errorMessages = ex.EntityValidationErrors
                    //        .SelectMany(x => x.ValidationErrors)
                    //        .Select(x => x.ErrorMessage);
                    //var fullErrorMessage = string.Join("; ", errorMessages);
                    //var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                    //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
              
                db.Dispose();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Khong luu vao duoc db");

                return View(sp);
            }
        }

    }
}