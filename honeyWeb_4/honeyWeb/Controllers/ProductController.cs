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
        private DataSet ds;
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
        public ActionResult Create(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sanpham);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(string id = null)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanpham);
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}