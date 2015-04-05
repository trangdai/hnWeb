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

namespace honeyWeb.Controllers
{
    public class HomeController : Controller
    {
        private HoneyDBEntities db = new HoneyDBEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
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
            List<SanPham> prods = new List<SanPham>();
            prods = db.SanPhams.ToList();
            IEnumerable<SanPham> sp = (IEnumerable<SanPham>)prods;
            ViewBag.Prods = new SelectList(sp, "id", "ten_sp");
            ViewBag.TotalProds = prods.Count();
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string cateId, FormCollection collection)
        {
            ViewBag.Message = "Your contact page.";
            KhachHang kh = new KhachHang();//2
            DonDatHang don = new DonDatHang();
            try
            {
                kh.ho_ten = collection["Name"];
                kh.email = collection.Get("Email");
                kh.sdt = collection.Get("Phone");
                kh.dia_chi = collection["Address"];
                ViewBag.Prods = new SelectList(db.SanPhams, "id", "ten_sp");
                don.id_sp = cateId;
                if (collection["Quantity"] != null)
                    kh.so_luong_tich_luy = Int32.Parse(collection["Quantity"]);
                if (kh.sdt != null)
                {
                    //kh.id = kh.sdt.Substring(1);
                    kh.id = kh.sdt;
                    kh.username = kh.id;
                    kh.password = kh.id;
                    kh.loai_khach_hang = "bt";
                    kh.visible = true;
                    kh.ghi_chu = don.id_sp.ToString();
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
