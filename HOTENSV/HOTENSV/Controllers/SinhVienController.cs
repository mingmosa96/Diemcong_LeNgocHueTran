using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOTENSV.Models;

namespace HOTENSV.Controllers
{
    public class SinhVienController : Controller
    {
        SVDataDataContext data = new SVDataDataContext();
        // GET: SinhVien
        public ActionResult Index()
        {
            var all_sv = from sv in data.SinhViens select sv;
            return View(all_sv);
        }
        public ActionResult Detail(string id)
        {
            var S_sinhvien = data.SinhViens.Where(p => p.MaSV == id).First();
            return View(S_sinhvien);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var S_mssv = collection["MaSV"];
            var S_hoten = collection["HoTen"];
            var S_gioitinh = collection["GioiTinh"];
            var S_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var S_hinh = collection["Hinh"];
            var S_manganh = collection["MaNganh"];
            if (string.IsNullOrEmpty(S_mssv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sv.MaSV = S_mssv.ToString();
                sv.HoTen = S_hoten.ToString();
                sv.GioiTinh = S_gioitinh.ToString();
                sv.NgaySinh = S_ngaysinh;
                sv.Hinh = S_hinh.ToString();
                sv.MaNganh = S_manganh.ToString();
                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var S_sinhvien = data.SinhViens.First(p => p.MaSV == id);
            return View(S_sinhvien);
        }

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var S_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            var S_mssv = collection["MaSV"];
            var S_hoten = collection["HoTen"];
            var S_gioitinh = collection["GioiTinh"];
            var S_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var S_hinh = collection["Hinh"];
            var S_manganh = collection["MaNganh"];
            S_sinhvien.MaSV = id;
            if (string.IsNullOrEmpty(S_mssv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                S_sinhvien.MaSV = S_mssv.ToString();
                S_sinhvien.HoTen = S_hoten.ToString();
                S_sinhvien.GioiTinh = S_gioitinh.ToString();
                S_sinhvien.NgaySinh = S_ngaysinh;
                S_sinhvien.Hinh = S_hinh.ToString();
                S_sinhvien.MaNganh = S_manganh.ToString();
                UpdateModel(S_sinhvien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(string id)
        {
            var S_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(S_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var S_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(S_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}
