using Lab1_TranNguyenDat.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_TranNguyenDat.Controllers
{
    public class NhanVienController : Controller
    {
        QLBHContext db = new QLBHContext();
        public IActionResult Index()
        {
            
            return View(db.Nhanviens);
        }
        [HttpGet]
        public ActionResult themNV()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themNV(Nhanvien n)
        {
            db.Nhanviens.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult suaNV(string id)
        {
            Nhanvien nv = db.Nhanviens.Find(id);
            return View(nv);
        }
        [HttpPost]
        public ActionResult suaNV(Nhanvien nv)
        {
            Nhanvien n = db.Nhanviens.Find(nv.Manv);
            n.Tennv = nv.Tennv;
            n.Ngaysinh=nv.Ngaysinh;
            n.Phai = nv.Phai;
            n.Diachi=nv.Diachi;
            n.Password = nv.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult xoaNV(string id)
        {
            Nhanvien nv = db.Nhanviens.Find(id);
            return  View(nv);
        }
        [HttpPost, ActionName("xoaNV")]
        public ActionResult xoa(string id)
        {
            Nhanvien nv = db.Nhanviens.Find(id);
            if (nv != null)
            {
                db.Nhanviens.Remove(nv);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
