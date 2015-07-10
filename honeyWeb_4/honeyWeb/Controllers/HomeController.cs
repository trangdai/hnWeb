using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using honeyWeb.Models;
//using honeyWeb.Models.DataAccessSql;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace honeyWeb.Controllers
{
    public class HomeController : Controller
    {
        private HoneyDBEntities db = new HoneyDBEntities();
        private int TOTAL_ARTICLE_PER_PAGE = 7;
        private List<SanPham> prods = new List<SanPham>();
        DataSet ds = new DataSet();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            
            try
            {
                prods = getAllProds();
                //prods = db.SanPhams.ToList();
                //DataAccessSql.AddParameter("",db,size,);
                ViewBag.Prods = prods;
                ViewBag.TotalProds = prods.Count();
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

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            List<BaiViet> articles = new List<BaiViet>();
            articles = getAllArticles();
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
            articles = getAllArticles();
            //articles = db.BaiViets.ToList();
            ViewBag.articles = articles;
            ViewBag.totalArticle = articles.Count();
            ViewBag.totalPage = articles.Count() / TOTAL_ARTICLE_PER_PAGE;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            prods = getAllProds();
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
        public ActionResult Contact(String cateId, FormCollection collection)
        {
            ViewBag.Message = "Your contact page.";
            KhachHang kh = new KhachHang();//2
            DonDatHang don = new DonDatHang();
            IEnumerable<SanPham> sp = (IEnumerable<SanPham>)db.SanPhams;
            //ViewBag.Prods = new SelectList(sp, "id", "ten_sp");

            try
            {
                ViewBag.Prods = new SelectList(sp, "id", "ghi_chu");

				//get data
				String hoten = collection["Name"];
				String email = collection.Get("Email");
				String sdt = collection.Get("Phone");
				String diachi = collection["Address"];
				String soluong = collection["Quantity"];
                String id_kh = sdt.Substring(2);

/*                //if (hoten == "" || hoten == null || email == "" || email == null ||
                //    sdt == "" || sdt == null || diachi == "" || diachi == null || soluong == "" || soluong == null)
                //{
                //    return RedirectToAction("ErrorFilling");
                //}
*/
				//if customer first buy

                //if(checkVisibleKhachHang(sdt) == null){
                ////register n save info
                //    kh.id = sdt.Substring(2);//id 10 chu so
                //    kh.username = kh.id;
                //    kh.password = kh.id;
                //    kh.loai_khach_hang = "bt";
                //    kh.visible = true;
                //    kh.ho_ten = collection["Name"];
                //    kh.email = collection.Get("Email");
                //    kh.sdt = collection.Get("Phone");
                //    kh.dia_chi = collection["Address"];	
                //    kh.so_luong_tich_luy = 0;
                //    db.KhachHangs.Add(kh);
                //}

                
				SqlParameter[] para = { 
					DataAccessSql.AddParameter("@id",SqlDbType.NVarChar,10,id_kh),
					DataAccessSql.AddParameter("@username", SqlDbType.NVarChar, 50, id_kh),
					DataAccessSql.AddParameter("@password", SqlDbType.NVarChar, 20, id_kh),
					DataAccessSql.AddParameter("@loaiKH", SqlDbType.NVarChar, 20, "bt"),
					DataAccessSql.AddParameter("@hoten", SqlDbType.NVarChar, 100, hoten),
					DataAccessSql.AddParameter("@email", SqlDbType.NVarChar, 20, email),
					DataAccessSql.AddParameter("@sdt", SqlDbType.NVarChar, 20, sdt),
					DataAccessSql.AddParameter("@diachi", SqlDbType.NVarChar, 100, diachi)
				};				

                ds = DataAccessSql.RunStore("AddNewCustomer", para);
				//save the bill
                DateTime time = DateTime.Now;
                String t = time.ToString();
                String[] words = t.Split(' ','/',':');
                String result = "";
                for(var i=0;i<words.Length;i++){
                    result += words[i];
                }
                //don.id = sdt +result;
                //don.id_kh = sdt;
                //don.id_sp = cateId;
                //don.so_luong_sp = Int32.Parse(soluong);
                //don.thoi_gian = time;
                //db.DonDatHangs.Add(don);
                //db.SaveChanges();
                SqlParameter[] para1 = { 
					DataAccessSql.AddParameter("@id", SqlDbType.NVarChar, 50, sdt +'o'+result),
					DataAccessSql.AddParameter("@idKH", SqlDbType.NVarChar, 20,id_kh),
					DataAccessSql.AddParameter("@idSP", SqlDbType.NVarChar, 10, cateId),
					DataAccessSql.AddParameter("@soluong", SqlDbType.Int, 50, Int32.Parse(soluong)),
					DataAccessSql.AddParameter("@thoigian", SqlDbType.DateTime, 50, time)
				};
                DataAccessSql.RunStore("AddNewPayment", para1);

                plusMarkToKhachHang(id_kh, Int32.Parse(soluong));

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
            List<KhachHang> lst = new List<KhachHang>();
            KhachHang kh = new KhachHang();
            int myMark = 0;
            //KhachHang kh = db.KhachHangs.Find(id);
            //if(kh != null)// || kh != undefined)
            //{
            //    kh.so_luong_tich_luy = kh.so_luong_tich_luy + mark;
            //}
            try
            {
                SqlParameter[] para = { DataAccessSql.AddParameter("@id", SqlDbType.NVarChar, 20, id) };
                ds = DataAccessSql.RunStore("GetCustomerById", para);
                lst = DataAccessSql.convertToListKH(ds.Tables[0]);
                if (lst.Count > 0)
                {
                    kh = lst[0];
                    myMark = (Int32)kh.so_luong_tich_luy + mark;

                    SqlParameter[] para1 = { 
                                         DataAccessSql.AddParameter("@id", SqlDbType.NVarChar, 20, id),
                                         DataAccessSql.AddParameter("@mark", SqlDbType.Int, 50, mark)
                                      };
                    DataAccessSql.RunStore("UpdateMarkCustomer", para1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
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

        public List<SanPham> getAllProds()
        {
            DataSet ds;
            SqlParameter[] para = { };
            ds = DataAccessSql.RunStore("GetAllProds", para);

            prods = DataAccessSql.convertToListSP(ds.Tables[0]);
            return prods;
        }

        public List<BaiViet> getAllArticles()
        {
            List<BaiViet> articles = new List<BaiViet>();
            DataSet ds;
            SqlParameter[] para = { };
            ds = DataAccessSql.RunStore("GetAllArticles", para);
            articles = DataAccessSql.convertToListBV(ds.Tables[0]);
            return articles;
        }
    }
}
