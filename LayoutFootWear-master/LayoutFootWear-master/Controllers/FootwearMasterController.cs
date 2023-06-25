using LayoutFootWear_master.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutFootWear_master.Controllers
{
    public class FootwearMasterController : Controller
    {
        // GET: FootwearMaster
        Shoes db = new Shoes();
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
            List<SanPham> listsp = db.SanPhams.ToList();
            return PartialView("_Product", listsp);
        }
        public ActionResult RenderProductByMenu(int maloai)
        {
            List<SanPham> listspb = db.SanPhams.Where(x => x.MaPhanLoai == maloai).ToList();
            return PartialView("_Product",listspb);
        }
      
        // GET: Delete Product
        public ActionResult DeletedProduct(int id)
        {
            var product = db.SanPhams.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "FootwearMaster");
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
                }
            }
            ;
            return RedirectToAction("Index");
        }
    }
}