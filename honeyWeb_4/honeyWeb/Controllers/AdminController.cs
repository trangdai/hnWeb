using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using honeyWeb.Models;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace honeyWeb.Controllers
{
    public class AdminController : Controller
    {
        private HoneyDBEntities db = new HoneyDBEntities();
        private DataSet ds = new DataSet();
        private List<KhachHang> prods = new List<KhachHang>();
        private List<DonDatHang> payments = new List<DonDatHang>();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        //get /Admin/EditCus
        public ActionResult EditCus(string key)
        {
            SqlParameter[] para = { };
            try
            {
                ds = DataAccessSql.RunStore("GetAllCustomer", para);
                prods = DataAccessSql.convertToListKH(ds.Tables[0]);
                ViewBag.Prods = prods;
                ViewBag.TotalProds = prods.Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return View();
        }

        //post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCus(FormCollection collection)
        {
            String[] deleteList, idList, usernameList, nameList, phoneList, emailList, addressList, cateList, markList, noteList,passList;
            int total;
            KhachHang kh = new KhachHang();
            try
            {
                deleteList = null;
                String del = collection["Delete"];
                if (del != null)
                {
                    deleteList = collection["Delete"].Split(',');
                }
                idList = collection["ID"].Split(',');
                usernameList = collection["Username"].Split(',');
                nameList = collection["Name"].Split(',');
                phoneList = collection["Phone"].Split(',');
                emailList = collection["Email"].Split(',');
                addressList = collection["Address"].Split(',');
                cateList = collection["Cate"].Split(',');
                markList = collection["Mark"].Split(',');
                noteList = collection["Note"].Split(',');
                passList = collection["Pa"].Split(',');

                total = idList.Length;

                for (var i = 0; i < total; i++)
                {
                    kh.id = idList[i];
                    kh.username = usernameList[i];
                    kh.password = passList[i];
                    kh.ho_ten = nameList[i];
                    kh.sdt = phoneList[i];
                    kh.email = emailList[i];
                    kh.dia_chi = addressList[i];
                    kh.loai_khach_hang = cateList[i];
                    kh.so_luong_tich_luy = Int32.Parse(markList[i]);
                    kh.ghi_chu = noteList[i];
                    UpdateCustomer(kh);
                }

                if (deleteList != null && deleteList.Length > 0)
                {
                    for (int i = 0; i < deleteList.Length; i++)
                    {
                        DeleteCustomer(deleteList[i]);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return View("Congrats");
        }

        public void UpdateCustomer(KhachHang kh)
        {
            try
            {
                SqlParameter[] para = { 
					DataAccessSql.AddParameter("@id",SqlDbType.NVarChar,10,kh.id),
					DataAccessSql.AddParameter("@username", SqlDbType.NVarChar, 50, kh.username),
					DataAccessSql.AddParameter("@password", SqlDbType.NVarChar, 20, kh.password),
					DataAccessSql.AddParameter("@loaiKH", SqlDbType.NVarChar, 20,kh.loai_khach_hang),
					DataAccessSql.AddParameter("@hoten", SqlDbType.NVarChar, 100, kh.ho_ten),
					DataAccessSql.AddParameter("@email", SqlDbType.NVarChar, 20,kh.email),
					DataAccessSql.AddParameter("@sdt", SqlDbType.NVarChar, 20, kh.sdt),
					DataAccessSql.AddParameter("@diachi", SqlDbType.NVarChar, 100, kh.dia_chi),
                    DataAccessSql.AddParameter("@visible", SqlDbType.Bit, 10, kh.visible),
                    DataAccessSql.AddParameter("@so_luong_tich_luy", SqlDbType.Int, 20, kh.so_luong_tich_luy),
                    DataAccessSql.AddParameter("@ghichu", SqlDbType.NText, 1000, kh.ghi_chu)
				};
                ds = DataAccessSql.RunStore("AddNewCustomer", para);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void DeleteCustomer(String id)
        {
            try
            {
                SqlParameter[] para = { DataAccessSql.AddParameter("@id", SqlDbType.NVarChar, 20, id) };
                ds = DataAccessSql.RunStore("DeleteCustomer", para);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        //Payment  /Admin/EditPayment
        public ActionResult EditPayment()
        {
            try
            {
                SqlParameter[] para = { };
                ds = DataAccessSql.RunStore("GetAllPayment", para);
                payments = DataAccessSql.convertToListDDH(ds.Tables[0]);
                ViewBag.Prods = payments;
                ViewBag.TotalProds = payments.Count;

                //Status of payment
                List<TrangThaiDonHang> status = new List<TrangThaiDonHang>();
                ds = DataAccessSql.RunStore("GetStatusPayment", para);
                status = DataAccessSql.convertToListTTDH(ds.Tables[0]);
                ViewBag.status = status;
                ViewBag.TotalStatus = status.Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return View();
        }

        
    }
}
