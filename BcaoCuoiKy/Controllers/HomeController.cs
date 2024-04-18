using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BcaoCuoiKy.Models;

namespace BcaoCuoiKy.Controllers
{
    public class HomeController : Controller
    {
        cuoikydbEntities db = new cuoikydbEntities();
        public ActionResult Index(int maloaisp = 0, string SearchString = "")
        {
            //tkiem
            if(SearchString != "")
            {
                var sanPhams = db.SanPhams.Include(s => s.LoaiSP).Where(x => x.TenSP.ToUpper().Contains(SearchString.ToUpper()));
                return View(sanPhams.ToList());
            }
            else if(maloaisp == 0)
            {
                var sanPhams = db.SanPhams.Include(s => s.LoaiSP);
                return View(sanPhams.ToList());

            }
            else
            {
                var sanPhams = db.SanPhams.Include(s => s.LoaiSP).Where(x => x.MaLoaiSP == maloaisp);
                return View(sanPhams.ToList());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}