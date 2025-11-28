using Lab1_TranNguyenDat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1_TranNguyenDat.Controllers
{
    public class HangHoaController : Controller
    {
        QLBHContext db=new QLBHContext();
        public IActionResult Index()
        {
            ViewBag.hh = db.Hanghoas;
            return View();
        }
        [HttpGet]
        public ActionResult themHH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themHH(Hanghoa hh)
        {
            if (ModelState.IsValid)
            {
                db.Hanghoas.Add(hh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult suaHH(string id)
        {
            Hanghoa hh = db.Hanghoas.Find(id);
            return View(hh);
        }
        [HttpPost]
        public ActionResult suaHH(Hanghoa hh)
        {
            if (ModelState.IsValid)
            {
                Hanghoa n = db.Hanghoas.Find(hh.Mahang);
                n.Tenhang = hh.Tenhang;
                n.Donvitinh = hh.Donvitinh;
                n.Dongia = hh.Dongia;
                n.Hinh = hh.Hinh;
                n.Maloai = hh.Maloai;
                n.Mansx = hh.Mansx;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

   
    }
}
