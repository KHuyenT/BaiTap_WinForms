using LMS_Desktopbuoi4.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Desktopbuoi4.DAL
{
    internal class SanPhamDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public DataTable GetDanhSachSP()
        {
            return db.GetDataTable("SELECT * FROM SanPham");
        }

        public DataTable GetDanhSachLoai()
        {
            return db.GetDataTable("SELECT * FROM LoaiSanPham");
        }


        public void ThemSP(SanPham sp)
        {
            string sql = $"INSERT INTO SanPham VALUES(N'{sp.MaSP}', N'{sp.TenSP}', N'{sp.DVTinh}', {sp.DonGia}, N'{sp.MaLoai}')";
            db.ExecuteNonQuery(sql);
        }

        public void SuaSP(SanPham sp)
        {
            string sql = $"UPDATE SanPham SET TenSP=N'{sp.TenSP}', DVTinh=N'{sp.DVTinh}', DonGia={sp.DonGia}, MaLoai=N'{sp.MaLoai}' WHERE MaSP=N'{sp.MaSP}'";
            db.ExecuteNonQuery(sql);
        }

        public void XoaSP(string maSP)
        {
            string sql = $"DELETE FROM SanPham WHERE MaSP=N'{maSP}'";
            db.ExecuteNonQuery(sql);
        }
    }
}
