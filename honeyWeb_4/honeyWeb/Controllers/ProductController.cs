using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using honeyWeb.Models;

namespace honeyWeb.Controllers
{
    public class ProductController : Controller
    {
        private HoneyDBEntities db = new HoneyDBEntities();
        private DataSet ds = new DataSet();
        private List<SanPham> prods = new List<SanPham>();
        
        //
        // GET: /Product/

        public ActionResult Index()
        {
            SqlParameter[] para = { };
            ds = DataAccessSql.RunStore("GetAllProds", para);

            try
            {
                prods = DataAccessSql.convertToListSP(ds.Tables[0]);
                //prods = db.SanPhams.ToList();
                ViewBag.Prods = prods;
                ViewBag.TotalProds = prods.Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return View("Index");
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(string id = null)
        {
            //SanPham sanpham = db.SanPhams.Find(id);
            SanPham sanpham = new SanPham();
            SqlParameter[] para = { 
                DataAccessSql.AddParameter("@prodID", SqlDbType.NVarChar, 20, id)
                                  };
            ds = DataAccessSql.RunStore("GetDetailProdById", para);

            try
            {
                prods = DataAccessSql.convertToListSP(ds.Tables[0]);
                sanpham = prods[0];
                if (sanpham == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return View(sanpham);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham sp, FormCollection collection)
        {
            try
            {
                SqlParameter[] para = { 
					DataAccessSql.AddParameter("@id",SqlDbType.NVarChar,10,collection["ID"]),
					DataAccessSql.AddParameter("@tensp", SqlDbType.NVarChar, 100, collection["Name"]),
					DataAccessSql.AddParameter("@giasp", SqlDbType.Float, 20, collection["Price"]),
					DataAccessSql.AddParameter("@img", SqlDbType.NVarChar, 200,collection["Image"]),
					DataAccessSql.AddParameter("@tinhtrang", SqlDbType.Int, 20, collection["Status"]),
					DataAccessSql.AddParameter("@motangan", SqlDbType.NVarChar, 1000, collection["ShortDetail"]),
					DataAccessSql.AddParameter("@motachitiet", SqlDbType.NText, 1000, collection["Detail"]),
					DataAccessSql.AddParameter("@ghichu", SqlDbType.NText, 1000, collection["Note"])//,
                    //DataAccessSql.AddParameter("@visible", SqlDbType.Bit, 10, 1)
				};
                ds = DataAccessSql.RunStore("AddNewProduct", para);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            //if (ModelState.IsValid)
            //{
            //    db.SanPhams.Add(sanpham);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(sp);
        }

        public void AddNewProduct(SanPham sp)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        //
        // GET: /Product/Edit35oi9qyhutesc25xvb81mkol/caphe250

        public ActionResult Edit35oi9qyhutesc25xvb81mkol(string id)
        {
            //SanPham sanpham = db.SanPhams.Find(id);
            SanPham sanpham = new SanPham();
            SqlParameter[] para = {    };
            try
            {
                ds = DataAccessSql.RunStore("GetAllProds", para);
                prods = DataAccessSql.convertToListSP(ds.Tables[0]);
                sanpham = prods[0];
                ViewBag.Prods = prods;
                ViewBag.TotalProds = prods.Count;
                if (sanpham == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return View(sanpham);
        }

        //
        // POST: /Product/Edit35oi9qyhutesc25xvb81mkol/caphe500

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit35oi9qyhutesc25xvb81mkol(SanPham sanpham, FormCollection collection)
        {
            String[] idList, nameList, priceList, imgList, statusList, shortDetailList, detailList, noteList, deleteList;
            int total;
            SanPham sp = new SanPham();
            try
            {      
                String t = collection["ID"];
                idList = collection["ID"].Split(',');
                nameList = collection["Name"].Split(',');
                priceList = collection["Price"].Split(',');
                imgList = collection["Image"].Split(',');
                statusList = collection["Status"].Split(',');
                deleteList = collection["Delete"].Split(',');
                shortDetailList = collection["ShortDetail"].Split(',');
                detailList = collection["Detail"].Split(',');
                noteList = collection["Note"].Split(',');

                total = nameList.Length;

                for (var i = 0; i < total; i++)
                {
                    sp.id = idList[i];
                    sp.ten_sp = nameList[i];
                    sp.gia_sp = Double.Parse(priceList[i]);
                    sp.hinh_anh = imgList[i];
                    sp.tinh_trang = Int32.Parse(statusList[i]);
                    //sp.visible = Boolean.Parse(visibleList[i]);
                    sp.mo_ta_ngan = shortDetailList[i];
                    sp.mo_ta_chi_tiet = detailList[i];
                    sp.ghi_chu = noteList[i];
                    updateProd(sp);
                }

                //if (ModelState.IsValid)
                //{
                //    db.Entry(sanpham).State = EntityState.Modified;
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}

                //delete item
                if (deleteList.Length > 0)
                {
                    for (int i = 0; i < deleteList.Length; i++)
                    {
                        DeleteProduct(deleteList[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            //return View(idList[0]);
            return RedirectToAction("Index");
        }

        public void updateProd(SanPham sp)
        {
            try
            {
                SqlParameter[] para = { 
					DataAccessSql.AddParameter("@id",SqlDbType.NVarChar,10,sp.id),
					DataAccessSql.AddParameter("@tensp", SqlDbType.NVarChar, 100, sp.ten_sp),
					DataAccessSql.AddParameter("@giasp", SqlDbType.Float, 20, sp.gia_sp),
					DataAccessSql.AddParameter("@img", SqlDbType.NVarChar, 200,sp.hinh_anh),
					DataAccessSql.AddParameter("@tinhtrang", SqlDbType.Int, 20, sp.tinh_trang),
					DataAccessSql.AddParameter("@motangan", SqlDbType.NVarChar, 1000, sp.mo_ta_ngan),
					DataAccessSql.AddParameter("@motachitiet", SqlDbType.NText, 1000, sp.mo_ta_chi_tiet),
					DataAccessSql.AddParameter("@ghichu", SqlDbType.NText, 1000, sp.ghi_chu),
                    DataAccessSql.AddParameter("@visible", SqlDbType.Bit, 10, sp.visible)
				};
                ds = DataAccessSql.RunStore("AddNewProduct", para);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        //
        // GET: /Product/Delete/5

        public ActionResult Delete(string id = null)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void DeleteProduct(String id)
        {
            SqlParameter[] para = {DataAccessSql.AddParameter("@id",SqlDbType.NVarChar,10,id)};
            ds = DataAccessSql.RunStore("DeleteProdItem", para);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}