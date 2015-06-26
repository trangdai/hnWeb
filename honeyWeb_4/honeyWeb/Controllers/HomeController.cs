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
        private int TOTAL_ARTICLE_PER_PAGE = 7;

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
            ViewBag.totalPage = articles.Count() / TOTAL_ARTICLE_PER_PAGE;
            return View();
        }

        //*/About/1
        public ActionResult AboutPage(int page)
        {
            ViewBag.Message = "Your app description page.";
            List<BaiViet> articles = new List<BaiViet>();
            articles = db.BaiViets.ToList();
            ViewBag.articles = articles;
            ViewBag.totalArticle = articles.Count();
            ViewBag.totalPage = articles.Count() / TOTAL_ARTICLE_PER_PAGE;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            List<SanPham> prods = new List<SanPham>();
            prods = db.SanPhams.ToList();
            IEnumerable<SanPham> sp = (IEnumerable<SanPham>)prods;
            ViewBag.Prods = new SelectList(sp, "id", "ghi_chu");
            ViewBag.TotalProds = prods.Count();
            return View();
        }
/*
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
*/

        [HttpPost]
        public ActionResult Contact(string cateId, FormCollection collection)
        {
            ViewBag.Message = "Your contact page.";
            KhachHang kh = new KhachHang();//2
            DonDatHang don = new DonDatHang();
            IEnumerable<SanPham> sp = (IEnumerable<SanPham>)db.SanPhams;
            //ViewBag.Prods = new SelectList(sp, "id", "ten_sp");
            ViewBag.Prods = new SelectList(sp, "id", "ghi_chu");
            try
            {
				//get data
				String hoten = collection["Name"];
				String email = collection.Get("Email");
				String sdt = collection.Get("Phone");
				String diachi = collection["Address"];
				String soluong = collection["Quantity"];

                if (hoten == "" || hoten == null || email == "" || email == null ||
                    sdt == "" || sdt == null || diachi == "" || diachi == null || soluong == "" || soluong == null)
                {
                    return RedirectToAction("ErrorFilling");
                }
				//if customer first buy
				if(checkVisibleKhachHang(sdt) == null){
				//register n save info
                    kh.id = sdt.Substring(2);//id 10 chu so
                    kh.username = kh.id;
                    kh.password = kh.id;
                    kh.loai_khach_hang = "bt";
                    kh.visible = true;
					kh.ho_ten = collection["Name"];
					kh.email = collection.Get("Email");
					kh.sdt = collection.Get("Phone");
					kh.dia_chi = collection["Address"];	
					kh.so_luong_tich_luy = 0;
					db.KhachHangs.Add(kh);
				}
                
				//save the bill
                DateTime time = DateTime.Now;
                String t = time.ToString();
                String[] words = t.Split(' ','/',':');
                String result = "";
                for(var i=0;i<words.Length;i++){
                    result += words[i];
                }
                don.id = sdt +result;
				don.id_kh = sdt;
				don.id_sp = cateId;
				don.so_luong_sp = Int32.Parse(soluong);
                don.thoi_gian = time;
                plusMarkToKhachHang(sdt, Int32.Parse(soluong));
				db.DonDatHangs.Add(don);
				
				db.SaveChanges();

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
           // return View(don);
            return RedirectToAction("PaymentOK");
        }
		
		public KhachHang checkVisibleKhachHang(String id)
		{
			KhachHang kh = new KhachHang();
            kh = db.KhachHangs.Find(id);
			if(kh != null)// || kh != undefined)
            {
				return kh;
			}
            return null;
		}
		
		public void plusMarkToKhachHang(String id, int mark)
		{
			KhachHang kh = db.KhachHangs.Find(id);
			if(kh != null)// || kh != undefined)
            {
				kh.so_luong_tich_luy = kh.so_luong_tich_luy + mark;
			}
		}

		// int temp;
		// int.tryparse(yourstring, out temp);
		// if (temp == 0) return false
		// else return true;

        public ActionResult PaymentOK()
        {
            
            return View();
        }

        public ActionResult ErrorFilling()
        {
            return View();
        }

    }
}
