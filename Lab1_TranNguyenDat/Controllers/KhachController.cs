using Lab1_TranNguyenDat.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab1_TranNguyenDat.Controllers
{
    public class KhachController : Controller
    {
        QLBHContext db=new QLBHContext();
        public IActionResult Index()
        {
            ViewBag.kh = db.Khachhangs;
            return View();
        }

        public IActionResult indexdangnhap()
        {
            ViewBag.kTDangNhap = null;
            return View();
        }

        [HttpPost]
        public IActionResult dangnhap(Khachhang kh)
        {
            ViewBag.loginCheck = false;
            Khachhang x = db.Khachhangs.Find(kh.Makh);
            if (x != null)
            {
                if(x.Password == kh.Password)
                {
                    string json=JsonConvert.SerializeObject(x);
                    HttpContext.Session.SetString("Khachhang", json);
                    ViewBag.loginCheck = true;
                    return RedirectToAction("Index", "Khach");
                }
            }
            return View("indexdangnhap");
        }
       
        [HttpGet]
        public IActionResult dangxuat(Khachhang kh)
        {
           HttpContext.Session.Remove("Khachhang");
            return RedirectToAction("Index", "Khach");
            
		}

        [HttpGet]
        public ActionResult dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangky(Khachhang kh)
        {
            if (ModelState.IsValid)
            {
                db.Khachhangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
		}

        [HttpGet]
        public ActionResult themKhach()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themKhach(Khachhang n)
        {
            if (ModelState.IsValid)
            {
                db.Khachhangs.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult suaKH(string id)
        {
            Khachhang kh = db.Khachhangs.Find(id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult suaKH(Khachhang khach)
        {
            if (ModelState.IsValid)
            {
                Khachhang kh = db.Khachhangs.Find(khach.Makh);
                kh.Tenkh = khach.Tenkh;
                kh.Namsinh = khach.Namsinh;
                kh.Phai = khach.Phai;
                kh.Dienthoai = khach.Dienthoai;
                kh.Diachi = khach.Diachi;
                kh.Password = khach.Password;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult xoaKH(string id)
        {
            Khachhang kh = db.Khachhangs.Find(id);
            bool hasDeliveryOrder = db.Phieudathangs.Any(p => p.Makh == id); // Giả sử bảng Phiếu giao hàng có trường Manv

            // Truyền thông tin nhân viên và kết quả kiểm tra vào View
            ViewBag.CanDelete = !hasDeliveryOrder;  // Nếu có phiếu giao hàng thì không thể xóa
            return View(kh);
        }
        [HttpPost, ActionName("xoaKH")]
        public ActionResult xoa(string id)
        {
           Khachhang kh = db.Khachhangs.Find(id);
            if (kh != null)
            {
                bool hasDeliveryOrder = db.Phieudathangs.Any(p => p.Makh == id);
                if (!hasDeliveryOrder)
                {
                    db.Khachhangs.Remove(kh);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
