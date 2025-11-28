using Lab1_TranNguyenDat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Lab1_TranNguyenDat.Controllers
{
    public class NhaSanXuatController : Controller
    {
        QLBHContext db=new QLBHContext();
        
        public IActionResult Index()
        {
            ViewBag.nsx = db.Nhasanxuats;
            return View();
        }
        [HttpGet]
        public ActionResult them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult them(Nhasanxuat n)
        {
            db.Nhasanxuats.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult sua(string id)
        {
            Nhasanxuat nsx = db.Nhasanxuats.Find(id); 
            return View(nsx);
        }
        [HttpPost]
        public ActionResult sua(Nhasanxuat n)
        {
            Nhasanxuat nsx = db.Nhasanxuats.Find(n.Mansx);
            nsx.Tennsx = n.Tennsx;
            nsx.Diachi = n.Diachi;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult xoa(string id)
        {
            Nhasanxuat n = db.Nhasanxuats.Find(id);
            return View(n);
        }
        [HttpPost, ActionName("xoa")]
        public ActionResult xoa_Post(string id)
        {
            Nhasanxuat n = db.Nhasanxuats.Find(id);
            if (n != null)
            {
                db.Nhasanxuats.Remove(n);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
