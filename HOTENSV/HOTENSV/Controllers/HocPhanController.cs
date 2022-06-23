using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOTENSV.Models;

namespace HOTENSV.Controllers
{
    public class HocPhanController : Controller
    {
        SVDataDataContext data = new SVDataDataContext();
        // GET: HocPhan
        public ActionResult Index()
        {
            var all_hocphan = from hp in data.HocPhans select hp;
            return View(all_hocphan);
        }
    }
}