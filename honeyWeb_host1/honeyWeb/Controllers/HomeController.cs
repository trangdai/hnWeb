using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using honeyWeb.Models;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.Validation;
using System.Data.Odbc;

namespace honeyWeb.Controllers
{
    public class HomeController : Controller
    {
        private HoneyDBEntities db = new HoneyDBEntities();
        private OdbcConnection conn = new OdbcConnection();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //conn.ConnectionString =
            //              "Driver={SQL Server};" +
            //              "Server=honeydb.mssql.somee.com;" +
            //              "DataBase=honeydb;" +
            //              "Uid=honey_lylinh_SQLLogin_1;" +
            //              "Pwd=dpj5c75r9c;"; 
            //conn.Open();
            List<SanPham> prods = new List<SanPham>();
            prods = db.SanPhams.ToList();
            ViewBag.Prods = prods;
            ViewBag.TotalProds = prods.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            List<BaiViet> articles = new List<BaiViet>();
            articles = db.BaiViets.ToList();
            ViewBag.articles = articles;
            ViewBag.totalArticle = articles.Count();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection collection)
        {
            ViewBag.Message = "Your contact page.";
            KhachHang kh = new KhachHang();
            try
            {
                kh.ho_ten = collection["Name"];
                kh.email = collection.Get("Email");
                kh.sdt = collection.Get("Phone");
                if (collection["Quantity"] != null)
                    kh.so_luong_tich_luy = Int32.Parse(collection["Quantity"]);
                if (kh.sdt != null)
                {
                    kh.id = kh.sdt.Substring(1);
                    kh.username = kh.id;
                    kh.password = kh.id;
                    kh.loai_khach_hang = "bt";
                    kh.visible = true;
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            } 
            return View();
        }
    }
}
