using LMS_Desktopbuoi4.DAL;
using LMS_Desktopbuoi4.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Desktopbuoi4.BUS
{
    internal class SanPhamBUS
    {
        SanPhamDAL dal = new SanPhamDAL();

        // 1. Hàm lấy danh sách Sản Phẩm
        public DataTable LayDSSanPham()
        {
            return dal.GetDanhSachSP();
        }

        // 2. Hàm lấy danh sách Loại (Sửa lỗi CS1061: Đặt tên đúng như GUI gọi)
        public DataTable LayDSLoaiSanPham()
        {
            return dal.GetDanhSachLoai();
        }

        // 3. Hàm Thêm (Sửa lỗi CS0029: Trả về bool thay vì void)
        public bool ThemSanPham(SanPham sp)
        {
            try
            {
                // Kiểm tra nghiệp vụ: Mã không được để trống
                if (string.IsNullOrEmpty(sp.MaSP)) return false;

                dal.ThemSP(sp);
                return true; // Nếu chạy qua dòng trên mà không lỗi thì trả về True
            }
            catch
            {
                return false; // Có lỗi (trùng mã...) thì trả về False
            }
        }

        // 4. Hàm Sửa
        public bool SuaSanPham(SanPham sp)
        {
            try
            {
                dal.SuaSP(sp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 5. Hàm Xóa
        public bool XoaSanPham(string maSP)
        {
            try
            {
                dal.XoaSP(maSP);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
