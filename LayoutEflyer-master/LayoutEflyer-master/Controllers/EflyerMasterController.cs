using LayoutEflyer_master.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutEflyer_master.Controllers
{
    public class EflyerMasterController : Controller
    {
        // GET: EflyerMaster
        Computer db = new Computer();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RenderByMenu()
        {
            List<PhanLoai> listpl = db.PhanLoais.ToList();
            return PartialView("_Menu", listpl);
        }
        public ActionResult RenderByProduct()
        {
            List<SanPham> listsp = db.SanPhams.ToList();
            return PartialView("_Product", listsp);
        }
        //ajax
        public ActionResult RenderProductByMenu(int maloai)
        {
            List<SanPham> listsps = db.SanPhams.Where(x => x.MaPhanLoai == maloai).ToList();
            return PartialView("_Product", listsps);
        }
        public ActionResult CreateProduct()
        {
            var sp = new Models.Entities.SanPham();
            return View(sp);
        }
        [HttpPost]
        public ActionResult CreateProduct(Models.Entities.SanPham sp)
        {
            try
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                return View(sp);
            }

        }
        public ActionResult EditProduct(int id) {
            var spmodel = db.SanPhams.Find(id);
            return View(spmodel);
        }
        [HttpPost]
        public ActionResult EditProduct(SanPham sp)
        {
            var Product = db.SanPhams.Find(sp.MaSanPham);
            if(Product == null)
            {
                return HttpNotFound();
            }
            else
            {
                try {
                    Product.TenSanPham = sp.TenSanPham;
                    Product.MaSanPham = sp.MaSanPham;
                    Product.MaPhanLoaiPhu = sp.MaPhanLoaiPhu;
                    Product.MaPhanLoai = sp.MaPhanLoai;
                    Product.DonGiaBanLonNhat = sp.DonGiaBanLonNhat;
                    Product.DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat;
                    Product.AnhDaiDien = sp.AnhDaiDien;
                    Product.GiaNhap = sp.GiaNhap;
                    Product.NoiBat = sp.NoiBat;
                    Product.TrangThai = sp.TrangThai;
                    Product.MoTaNgan = sp.MoTaNgan;
                    db.SaveChanges();
                    //var ploai = db.PhanLoais.Where(o => o.MaPhanLoai == (int)Product.MaPhanLoai);
                    //foreach(var loai in ploai)
                    //{
                    //    loai.MaPhanLoai = (int)sp.MaPhanLoai;
                    //}
                    //db.SaveChanges();
                    //var ploaip = db.PhanLoaiPhus.Where(n => n.MaPhanLoaiPhu == (int)Product.MaPhanLoaiPhu);
                    //foreach(var loaip in ploaip)
                    //{
                    //    loaip.MaPhanLoaiPhu = (int)sp.MaPhanLoaiPhu;
                    //}
                    //db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch(Exception ex)
                {
                    return View(sp);
                }
            }
        }



    }
}