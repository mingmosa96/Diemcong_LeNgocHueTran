using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOTENSV.Models;

namespace HOTENSV.Controllers
{
    public class NguoiDungController : Controller
    {
        SVDataDataContext data = new SVDataDataContext();
        // GET: NguoiDung
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangnhap = collection["MaSV"];
            SinhVien sv = data.SinhViens.SingleOrDefault(n => n.MaSV == tendangnhap);
            if (sv != null)
            {
                ViewBag.ThongBao = collection["Chuc mung dang nhap thanh cong"];
                Session["TaiKhoan"] = sv;
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập không đúng ";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}