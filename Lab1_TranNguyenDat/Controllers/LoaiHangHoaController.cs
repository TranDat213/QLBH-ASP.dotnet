using Lab1_TranNguyenDat.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_TranNguyenDat.Controllers
{
    public class LoaiHangHoaController : Controller
    {
        QLBHContext db=new QLBHContext();
        public IActionResult Index()
        {
            return View(db.Loaihanghoas);
        }
        [HttpGet]
        public ActionResult themLoai()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themLoai(Loaihanghoa n)
        {
            db.Loaihanghoas.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult suaLHH(string id)
        {
            Loaihanghoa lhh=db.Loaihanghoas.Find(id);
            return View(lhh);
        }
        [HttpPost]
        public ActionResult suaLHH(Loaihanghoa lhh)
        {
            Loaihanghoa loaihanghoa=db.Loaihanghoas.Find(lhh.Maloai);
            loaihanghoa.Tenloai= lhh.Tenloai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult xoaLHH(string id)
        {
            Loaihanghoa lhh = db.Loaihanghoas.Find(id);
            return View(lhh);
        }
        [HttpPost, ActionName("xoaLHH")]
        public ActionResult xoa(string id)
        {
            Loaihanghoa lhh = db.Loaihanghoas.Find(id);
            if(lhh != null)
            {
                db.Loaihanghoas.Remove(lhh);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
