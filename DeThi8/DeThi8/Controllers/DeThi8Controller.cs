using DeThi8.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeThi8.Controllers
{
    public class DeThi8Controller : Controller
    {
        ChauCanh db = new ChauCanh();
        // GET: DeThi8
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RenderByMenu()
        {
            List<PhanLoaiPhu> listplp = db.PhanLoaiPhus.ToList();
            return PartialView("_Menu", listplp);
        }
        public ActionResult RenderByProduct()
        {
            List<SanPham> listsp = db.SanPhams.ToList();
            return PartialView("Product", listsp);
        }
        public ActionResult RenderProductByMenu(int maloai)
        {
            List<SanPham> listSPByMenu = db.SanPhams.Where(x => x.MaPhanLoaiPhu == maloai).ToList();
            return PartialView("Product", listSPByMenu);
        }
        public ActionResult DetailProduct(int id)
        {
            List<SanPham> listSP = db.SanPhams.Where(a => a.MaSanPham.Equals(id)).ToList();
            return PartialView(listSP);
        }
        //delete
        /* public ActionResult DeletedConfirm(int id)
         {
             var product = db.SanPhams.Find(id);
             if (product == null)
             {
                 return RedirectToAction("Index", "Home");
             }
             return View(product);
         }

         [HttpPost]
         public ActionResult DeletedConfirm(SanPham id)
         {
             var product = db.SanPhams.Find(id.MaSanPham);
             if (product != null)
             {
                 try
                 {
                     db.SanPhams.Remove(product);
                     db.SaveChanges();
                 }
                 catch (Exception ex)
                 {
                     // Xử lý lỗi (ví dụ: ghi log, hiển thị thông báo lỗi, vv.)
                     // Ví dụ:
                     ModelState.AddModelError("", "Đã xảy ra lỗi khi xóa sản phẩm.");
                     return View("DeletedConfirm", product);
                 }

             }
             db.SaveChanges();
             return RedirectToAction("Index");
         }*/
        // GET: Delete Product
        public ActionResult DeletedProduct(int id)
        {
            var product = db.SanPhams.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "DeThi8");
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult DeletedConfirm(int id)
        {
            var product = db.SanPhams.Find(id);
            var listSpTheoMau = db.SPTheoMaus.Where(x =>x.MaSanPham == id);
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