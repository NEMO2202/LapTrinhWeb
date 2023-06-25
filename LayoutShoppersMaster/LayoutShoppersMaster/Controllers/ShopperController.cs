
using LayoutShoppersMaster.Models.Entities;
using LayoutShoppersMaster.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutShoppersMaster.Controllers
{
    public class ShopperController : Controller
    {
        // GET: Shopper
        Model1 db;
        public ShopperController()
        {
            db = new Model1();
        }
        public ActionResult Index()
        {
            var listCategory = db.PhanLoais.ToList();
            var listSanPham = db.SanPhams.ToList();
            var indexViewModel = new IndexViewModel()
            {
                PhanLoais = listCategory,
                SanPhams = listSanPham,
            };
            return View(indexViewModel);
        }

        public ActionResult RenderProductByMenu(int maloai)
        {
            List<SanPham> listSPByMenu = db.SanPhams.Where(x => x.MaPhanLoaiPhu == maloai).ToList();
            return PartialView("_Product", listSPByMenu);
        }
        public ActionResult AddProduct()
        {
            var sp = new Models.Entities.SanPham();
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus, "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            return View(sp);
        }

        [HttpPost]
        public ActionResult AddProduct(Models.Entities.SanPham sp)
        {
            try
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(sp);
            }

        }
        public ActionResult EditProduct(int id)
        {
            var spmodel = db.SanPhams.Find(id);
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus, "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            return View(spmodel);
        }
        [HttpPost]
        public ActionResult EditProduct(SanPham sp)
        {
            var Product = db.SanPhams.Find(sp.MaSanPham);
            if (Product == null)
            {
                return HttpNotFound();
            }
            else
            {
                try
                {
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
                catch (Exception ex)
                {
                    return View(sp);
                }
            }
        }
        public ActionResult DeletedProduct(int id)
        {
            var product = db.SanPhams.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Shopper");
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult DeletedConfirm(int id)
        {
            var product = db.SanPhams.Find(id);
            var listSpTheoMau = db.SPTheoMaus.Where(x => x.MaSanPham == id);
            var maSpTheoMauIds = listSpTheoMau.Select(i => i.MaSPTheoMau).ToArray();


            var listChiTietSpBan = db.ChiTietSPBans.Where(x => maSpTheoMauIds.Contains((int)x.MaSPTheoMau));
            var listAnhChiTietSp = db.AnhChiTietSPs.Where(x => maSpTheoMauIds.Contains((int)x.MaSPTheoMau));
            if (product != null)
            {
                try
                {
                    db.AnhChiTietSPs.RemoveRange(listAnhChiTietSp);
                    db.ChiTietSPBans.RemoveRange(listChiTietSpBan);
                    db.SPTheoMaus.RemoveRange(listSpTheoMau);
                    db.SanPhams.Remove(product);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex) 
                {

                    var errorMessages = ex.EntityValidationErrors
                       .SelectMany(x => x.ValidationErrors)
                       .Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join("; ", errorMessages);
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                    //ModelState.AddModelError("", "Đã xảy ra lỗi khi xóa sản phẩm.");
                    //return View("DeletedProduct", product);
                }
            }
            ;
            return RedirectToAction("Index");
        } 
    }
}