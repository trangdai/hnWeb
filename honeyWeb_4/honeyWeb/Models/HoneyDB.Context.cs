﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace honeyWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class HoneyDBEntities : DbContext
    {
        public HoneyDBEntities()
            : base("name=HoneyDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        public DbSet<DaiLy> DaiLies { get; set; }
        public DbSet<DonDatHang> DonDatHangs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<TinhTrangSanPham> TinhTrangSanPhams { get; set; }
        public DbSet<TrangThaiDonHang> TrangThaiDonHangs { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual ObjectResult<GetAllArticles_Result> GetAllArticles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllArticles_Result>("GetAllArticles");
        }
    
        public virtual ObjectResult<GetAllProds_Result> GetAllProds()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProds_Result>("GetAllProds");
        }
    
        public virtual ObjectResult<GetDetailProdById_Result> GetDetailProdById(string prodID)
        {
            var prodIDParameter = prodID != null ?
                new ObjectParameter("prodID", prodID) :
                new ObjectParameter("prodID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDetailProdById_Result>("GetDetailProdById", prodIDParameter);
        }
    
        public virtual ObjectResult<GetDetailProdByName_Result> GetDetailProdByName(string prodName)
        {
            var prodNameParameter = prodName != null ?
                new ObjectParameter("prodName", prodName) :
                new ObjectParameter("prodName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDetailProdByName_Result>("GetDetailProdByName", prodNameParameter);
        }
    
        public virtual ObjectResult<GetAllArticles1_Result> GetAllArticles1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllArticles1_Result>("GetAllArticles1");
        }
    
        public virtual ObjectResult<GetAllProds1_Result> GetAllProds1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProds1_Result>("GetAllProds1");
        }
    
        public virtual ObjectResult<GetDetailProdById1_Result> GetDetailProdById1(string prodID)
        {
            var prodIDParameter = prodID != null ?
                new ObjectParameter("prodID", prodID) :
                new ObjectParameter("prodID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDetailProdById1_Result>("GetDetailProdById1", prodIDParameter);
        }
    
        public virtual ObjectResult<GetDetailProdByName1_Result> GetDetailProdByName1(string prodName)
        {
            var prodNameParameter = prodName != null ?
                new ObjectParameter("prodName", prodName) :
                new ObjectParameter("prodName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDetailProdByName1_Result>("GetDetailProdByName1", prodNameParameter);
        }
    
        public virtual int AddNewCustomer(string id, string username, string password, string loaiKH, string hoten, string email, string sdt, string diachi, Nullable<bool> visible, Nullable<int> so_luong_tich_luy, string ghichu)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var loaiKHParameter = loaiKH != null ?
                new ObjectParameter("loaiKH", loaiKH) :
                new ObjectParameter("loaiKH", typeof(string));
    
            var hotenParameter = hoten != null ?
                new ObjectParameter("hoten", hoten) :
                new ObjectParameter("hoten", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var sdtParameter = sdt != null ?
                new ObjectParameter("sdt", sdt) :
                new ObjectParameter("sdt", typeof(string));
    
            var diachiParameter = diachi != null ?
                new ObjectParameter("diachi", diachi) :
                new ObjectParameter("diachi", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            var so_luong_tich_luyParameter = so_luong_tich_luy.HasValue ?
                new ObjectParameter("so_luong_tich_luy", so_luong_tich_luy) :
                new ObjectParameter("so_luong_tich_luy", typeof(int));
    
            var ghichuParameter = ghichu != null ?
                new ObjectParameter("ghichu", ghichu) :
                new ObjectParameter("ghichu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewCustomer", idParameter, usernameParameter, passwordParameter, loaiKHParameter, hotenParameter, emailParameter, sdtParameter, diachiParameter, visibleParameter, so_luong_tich_luyParameter, ghichuParameter);
        }
    
        public virtual ObjectResult<GetCustomerById_Result> GetCustomerById(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCustomerById_Result>("GetCustomerById", idParameter);
        }
    
        public virtual int UpdateMarkCustomer(string id, Nullable<int> mark)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var markParameter = mark.HasValue ?
                new ObjectParameter("mark", mark) :
                new ObjectParameter("mark", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateMarkCustomer", idParameter, markParameter);
        }
    
        public virtual int AddNewPayment(string id, string idKH, string idSP, Nullable<int> soluong, Nullable<System.DateTime> thoigian, Nullable<int> tinh_trang, string ghi_chu)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var idKHParameter = idKH != null ?
                new ObjectParameter("idKH", idKH) :
                new ObjectParameter("idKH", typeof(string));
    
            var idSPParameter = idSP != null ?
                new ObjectParameter("idSP", idSP) :
                new ObjectParameter("idSP", typeof(string));
    
            var soluongParameter = soluong.HasValue ?
                new ObjectParameter("soluong", soluong) :
                new ObjectParameter("soluong", typeof(int));
    
            var thoigianParameter = thoigian.HasValue ?
                new ObjectParameter("thoigian", thoigian) :
                new ObjectParameter("thoigian", typeof(System.DateTime));
    
            var tinh_trangParameter = tinh_trang.HasValue ?
                new ObjectParameter("tinh_trang", tinh_trang) :
                new ObjectParameter("tinh_trang", typeof(int));
    
            var ghi_chuParameter = ghi_chu != null ?
                new ObjectParameter("ghi_chu", ghi_chu) :
                new ObjectParameter("ghi_chu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewPayment", idParameter, idKHParameter, idSPParameter, soluongParameter, thoigianParameter, tinh_trangParameter, ghi_chuParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int AddNewProduct(string id, string tensp, Nullable<double> giasp, string img, Nullable<int> tinhtrang, string motangan, string motachitiet, string ghichu, Nullable<bool> visible)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var tenspParameter = tensp != null ?
                new ObjectParameter("tensp", tensp) :
                new ObjectParameter("tensp", typeof(string));
    
            var giaspParameter = giasp.HasValue ?
                new ObjectParameter("giasp", giasp) :
                new ObjectParameter("giasp", typeof(double));
    
            var imgParameter = img != null ?
                new ObjectParameter("img", img) :
                new ObjectParameter("img", typeof(string));
    
            var tinhtrangParameter = tinhtrang.HasValue ?
                new ObjectParameter("tinhtrang", tinhtrang) :
                new ObjectParameter("tinhtrang", typeof(int));
    
            var motanganParameter = motangan != null ?
                new ObjectParameter("motangan", motangan) :
                new ObjectParameter("motangan", typeof(string));
    
            var motachitietParameter = motachitiet != null ?
                new ObjectParameter("motachitiet", motachitiet) :
                new ObjectParameter("motachitiet", typeof(string));
    
            var ghichuParameter = ghichu != null ?
                new ObjectParameter("ghichu", ghichu) :
                new ObjectParameter("ghichu", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewProduct", idParameter, tenspParameter, giaspParameter, imgParameter, tinhtrangParameter, motanganParameter, motachitietParameter, ghichuParameter, visibleParameter);
        }
    
        public virtual int AddNewProduct1(string id, string tensp, Nullable<double> giasp, string img, Nullable<int> tinhtrang, string motangan, string motachitiet, string ghichu, Nullable<bool> visible)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var tenspParameter = tensp != null ?
                new ObjectParameter("tensp", tensp) :
                new ObjectParameter("tensp", typeof(string));
    
            var giaspParameter = giasp.HasValue ?
                new ObjectParameter("giasp", giasp) :
                new ObjectParameter("giasp", typeof(double));
    
            var imgParameter = img != null ?
                new ObjectParameter("img", img) :
                new ObjectParameter("img", typeof(string));
    
            var tinhtrangParameter = tinhtrang.HasValue ?
                new ObjectParameter("tinhtrang", tinhtrang) :
                new ObjectParameter("tinhtrang", typeof(int));
    
            var motanganParameter = motangan != null ?
                new ObjectParameter("motangan", motangan) :
                new ObjectParameter("motangan", typeof(string));
    
            var motachitietParameter = motachitiet != null ?
                new ObjectParameter("motachitiet", motachitiet) :
                new ObjectParameter("motachitiet", typeof(string));
    
            var ghichuParameter = ghichu != null ?
                new ObjectParameter("ghichu", ghichu) :
                new ObjectParameter("ghichu", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewProduct1", idParameter, tenspParameter, giaspParameter, imgParameter, tinhtrangParameter, motanganParameter, motachitietParameter, ghichuParameter, visibleParameter);
        }
    
        public virtual int AddNewProduct2(string id, string tensp, Nullable<double> giasp, string img, Nullable<int> tinhtrang, string motangan, string motachitiet, string ghichu, Nullable<bool> visible)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var tenspParameter = tensp != null ?
                new ObjectParameter("tensp", tensp) :
                new ObjectParameter("tensp", typeof(string));
    
            var giaspParameter = giasp.HasValue ?
                new ObjectParameter("giasp", giasp) :
                new ObjectParameter("giasp", typeof(double));
    
            var imgParameter = img != null ?
                new ObjectParameter("img", img) :
                new ObjectParameter("img", typeof(string));
    
            var tinhtrangParameter = tinhtrang.HasValue ?
                new ObjectParameter("tinhtrang", tinhtrang) :
                new ObjectParameter("tinhtrang", typeof(int));
    
            var motanganParameter = motangan != null ?
                new ObjectParameter("motangan", motangan) :
                new ObjectParameter("motangan", typeof(string));
    
            var motachitietParameter = motachitiet != null ?
                new ObjectParameter("motachitiet", motachitiet) :
                new ObjectParameter("motachitiet", typeof(string));
    
            var ghichuParameter = ghichu != null ?
                new ObjectParameter("ghichu", ghichu) :
                new ObjectParameter("ghichu", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewProduct2", idParameter, tenspParameter, giaspParameter, imgParameter, tinhtrangParameter, motanganParameter, motachitietParameter, ghichuParameter, visibleParameter);
        }
    
        public virtual int DeleteProdItem(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProdItem", idParameter);
        }
    
        public virtual ObjectResult<GetAllCustomer_Result> GetAllCustomer()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllCustomer_Result>("GetAllCustomer");
        }
    
        public virtual int DeleteCustomer(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCustomer", idParameter);
        }
    
        public virtual ObjectResult<GetAllPayment_Result> GetAllPayment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllPayment_Result>("GetAllPayment");
        }
    
        public virtual int RemovePayment(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemovePayment", idParameter);
        }
    
        public virtual ObjectResult<GetStatusPayment_Result> GetStatusPayment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStatusPayment_Result>("GetStatusPayment");
        }
    }
}
