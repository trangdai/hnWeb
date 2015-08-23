using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace honeyWeb.Models
{
    class DataAccessSql
    {
        public DataAccessSql()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected static string Connstr = ConfigurationManager.ConnectionStrings["HoneyDBEntities"].ToString();
        private static SqlConnection GetConnection()
        {
            try {
                SqlConnection myconn = new SqlConnection(Connstr);
                if (myconn.State == ConnectionState.Open)
                    myconn.Close();
                myconn.Open();
                return myconn;
            }
            catch (Exception ex){
                throw new Exception("000 "+ex);
            }            
        }
        public static DataSet RunStore(string sp, SqlParameter[] param)
        {
            using (SqlConnection myConn = GetConnection())
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlCommand myCommand = CreateCommand(sp, myConn, param);
                    //myCommand.ExecuteNonQuery();
                    SqlDataAdapter adp = new SqlDataAdapter(myCommand);
                    adp.Fill(ds);  
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
                return ds;
            }
        }
        public static SqlCommand CreateCommand(string strSP, SqlConnection myconn, SqlParameter[] param)
        {
            SqlCommand mycommand = new SqlCommand(strSP, myconn);
            mycommand.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    mycommand.Parameters.Add(p);
                }
            }
            return mycommand;
        }
        public static SqlParameter AddParameter(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParameter(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        public static SqlParameter MakeParameter(string ParamName, SqlDbType dbType, int Size, ParameterDirection direction, object value)
        {
            SqlParameter param;
            if (Size > 0)
                param = new SqlParameter(ParamName, dbType, Size);
            else
                param = new SqlParameter(ParamName, dbType);
            param.Direction = direction;
            if (!(direction == ParameterDirection.Output && value == null))
                param.Value = value;

            return param;
        }
        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParameter(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        //****************For detail database*************************************
        private static List<SanPham> ConvertDataTable(DataTable dt)
        {
            List<SanPham> data = new List<SanPham>();
            foreach (DataRow row in dt.Rows)
            {
                SanPham item = GetItem<SanPham>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (var pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static List<SanPham> convertToListSP(DataTable dt)
        {
            List<SanPham> list = new List<SanPham>();
            list = (from DataRow dr in dt.Rows
                    select new SanPham()
                    {
                        //id = Convert.ToInt32(dr["id"]),
                        id = (dr["id"]).ToString(),
                        ten_sp = dr["ten_sp"].ToString(),
                        gia_sp = Convert.ToDouble(dr["gia_sp"]),
                        hinh_anh = dr["hinh_anh"].ToString(),
                        tinh_trang = Convert.ToInt32(dr["tinh_trang"]),
                        ghi_chu = dr["ghi_chu"].ToString(),
                        visible = Convert.ToBoolean(dr["visible"]),
                        mo_ta_ngan = dr["mo_ta_ngan"].ToString(),
                        mo_ta_chi_tiet = dr["mo_ta_chi_tiet"].ToString()
                    }).ToList();
            return list;
        }

        public static List<BaiViet> convertToListBV(DataTable dt)
        {
            List<BaiViet> list = new List<BaiViet>();
            list = (from DataRow dr in dt.Rows
                    select new BaiViet()
                    {
                        //id = Convert.ToInt32(dr["id"]),
                        id = Convert.ToInt32(dr["id"]),
                        tieu_de = dr["tieu_de"].ToString(),
                        noi_dung = dr["noi_dung"].ToString(),
                        thoi_gian = Convert.ToDateTime(dr["thoi_gian"]),
                        ghi_chu = dr["ghi_chu"].ToString(),
                    }).ToList();
            return list;
        }

        public static List<KhachHang> convertToListKH(DataTable dt)
        {
            List<KhachHang> list = new List<KhachHang>();
            list = (from DataRow dr in dt.Rows
                    select new KhachHang()
                    {
                        //id = Convert.ToInt32(dr["id"]),
                        id = dr["id"].ToString(),
                        username = dr["username"].ToString(),
                        password = dr["password"].ToString(),
                        ho_ten = dr["ho_ten"].ToString(),
                        sdt = dr["sdt"].ToString(),
                        email = dr["email"].ToString(),
                        dia_chi = dr["dia_chi"].ToString(),
                        loai_khach_hang = dr["loai_khach_hang"].ToString(),
                        ghi_chu = dr["ghi_chu"].ToString(),
                        visible = Convert.ToBoolean(dr["visible"]),
                        so_luong_tich_luy = Convert.ToInt32(dr["so_luong_tich_luy"]),
                    }).ToList();
            return list;
        }

        public static List<DonDatHang> convertToListDDH(DataTable dt)
        {
            List<DonDatHang> list = new List<DonDatHang>();
            list = (from DataRow dr in dt.Rows
                    select new DonDatHang()
                    {
                        id = dr["id"].ToString(),
                        id_kh = dr["id_kh"].ToString(),
                        id_sp = dr["id_sp"].ToString(),
                        so_luong_sp = Convert.ToInt32(dr["so_luong_sp"]),
                        thoi_gian = Convert.ToDateTime(dr["thoi_gian"].ToString()),
                        tinh_trang = Convert.ToInt32(dr["tinh_trang"]),
                        ghi_chu = dr["ghi_chu"].ToString()
                    }).ToList();
            return list;
        }

        public static List<TrangThaiDonHang> convertToListTTDH(DataTable dt)
        {
            List<TrangThaiDonHang> list = new List<TrangThaiDonHang>();
            list = (from DataRow dr in dt.Rows
                    select new TrangThaiDonHang()
                    {
                        id = Convert.ToInt32(dr["id"].ToString()),
                        ten = dr["ten"].ToString(),
                        ghi_chu = dr["ghi_chu"].ToString()
                    }).ToList();
            return list;
        }
    }
}
