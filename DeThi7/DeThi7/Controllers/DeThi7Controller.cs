using DeThi7.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeThi7.Controllers
{
    public class DeThi7Controller : Controller
    {
        // GET: DeThi7
        ChauCanh db = new ChauCanh();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RenderMenu()
        {
            List<PhanLoai> listpl = db.PhanLoais.ToList();
            return PartialView("_Menu", listpl);
        }
        public ActionResult RenderProduct()
        {
            List<SanPham> listplp = db.SanPhams.ToList();
            return PartialView("_Product", listplp);
        }
        public ActionResult RenderProductByMenu(int maloai)
        {
            List<SanPham> listsp = db.SanPhams.Where(x => x.MaPhanLoai == maloai).ToList();
            return PartialView("_Product", listsp);
        }
        public ActionResult ProductDetail(int id)
        {
            List<SanPham> listsanpham = db.SanPhams.Where(o => o.MaSanPham.Equals(id)).ToList();
            return View(listsanpham);
        }
        public ActionResult UpdateProduct(int id)
        {
            var SPmodel = db.SanPhams.Find(id);
            return View(SPmodel);
        }
        [HttpPost]
        public ActionResult UpdateProduct(SanPham sp)
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
                    Product.MaPhanLoai = sp.MaPhanLoai;
                    Product.GiaNhap = sp.GiaNhap;
                    Product.DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat;
                    Product.DonGiaBanLonNhat = sp.DonGiaBanLonNhat;
                    Product.TrangThai = sp.TrangThai;
                    Product.MoTaNgan = sp.MoTaNgan;
                    Product.AnhDaiDien = sp.AnhDaiDien;
                    Product.NoiBat = sp.NoiBat;
                    Product.MaPhanLoaiPhu = sp.MaPhanLoaiPhu;
                    db.SaveChanges();
                    var ploai = db.PhanLoais.Where(o => o.MaPhanLoai == (int)Product.MaPhanLoai);
                    foreach (var loai in ploai)
                    {
                        loai.MaPhanLoai = (int)sp.MaPhanLoai;
                    }
                    db.SaveChanges();
                    var ploaiphu = db.PhanLoaiPhus.Where(o => o.MaPhanLoaiPhu == (int)Product.MaPhanLoaiPhu);
                    foreach (var loaiphhu in ploaiphu)
                    {
                        loaiphhu.MaPhanLoaiPhu = (int)sp.MaPhanLoaiPhu;
                    }
                    db.SaveChanges();
                    // db.Dispose();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return View(sp);
                }
            }


        }
    }
    }