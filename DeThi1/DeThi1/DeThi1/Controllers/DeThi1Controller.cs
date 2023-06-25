using DeThi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DeThi1.Controllers
{
    public class DeThi1Controller : Controller
    {
        BanQuanAo db = new BanQuanAo();

        // GET: DeThi1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RenderMenu()
        {
            List<PhanLoai> listplp = db.PhanLoais.ToList();
            return PartialView("Menu", listplp);
        }
        public ActionResult RenderProduct()
        {
            List<SanPham> listsp = db.SanPhams.ToList();
            return PartialView("Product", listsp);
        }
        public ActionResult RenderProductByMenu(int maloai)
        {
            List<SanPham> list = db.SanPhams.Where(x => x.MaPhanLoai == maloai).ToList();
            return PartialView("Product", list);
        }
        public ActionResult AddProduct()
        {
            var sp = new Models.SanPham();
            return View(sp);
        }
        [HttpPost]
        public ActionResult AddProduct(Models.SanPham sp)
        {
            try
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(sp);
            }
        }
    }
}