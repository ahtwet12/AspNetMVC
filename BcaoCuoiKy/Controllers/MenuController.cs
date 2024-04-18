using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BcaoCuoiKy.Models;
using System.Collections;

namespace BcaoCuoiKy.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            using (cuoikydbEntities db = new cuoikydbEntities())
            {
                var loaisp = db.LoaiSPs.ToList();
                Hashtable tenloaisp = new Hashtable();
                foreach( var item in loaisp)
                {
                    tenloaisp.Add(item.MaLoaiSP, item.TenLoaiSP);

                }
                ViewBag.TenLoaiSP = tenloaisp;
                return PartialView("Index");
            }
                
        }
    }
}