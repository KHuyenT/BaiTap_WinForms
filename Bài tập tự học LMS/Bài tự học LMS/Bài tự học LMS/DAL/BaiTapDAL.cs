using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bài_tự_học_LMS.DTO;
using System.Data;

namespace Bài_tự_học_LMS.DAL
{
    internal class BaiTapDAL
    {
        DatabaseHelper db = new DatabaseHelper();

        public DataTable GetAllBaiTap()
        {
            return db.ExecuteQuery("SELECT * FROM BaiTap");
        }

        public bool ThemBaiTap(BaiTap bt)
        {
            // String.Format giúp chèn biến vào câu lệnh
            string sql = string.Format("INSERT INTO BaiTap (TenBai, MonHoc, LinkCode, TrangThai, Diem) VALUES ('{0}', '{1}', '{2}', '{3}', {4})",
                                       bt.TenBai, bt.MonHoc, bt.LinkCode, bt.TrangThai, bt.Diem);

            return db.ExecuteNonQuery(sql) > 0;
        }
        public bool SuaBaiTap(BaiTap bt)
        {
            string sql = string.Format("UPDATE BaiTap SET TenBai = '{0}', MonHoc = '{1}', LinkCode = '{2}', TrangThai = '{3}', Diem = {4} WHERE MaBai = {5}",
                bt.TenBai, bt.MonHoc, bt.LinkCode, bt.TrangThai, bt.Diem, bt.MaBai);

            return db.ExecuteNonQuery(sql) > 0;
        }
        public bool XoaBaiTap(int maBai)
        {
            string sql = string.Format("DELETE FROM BaiTap WHERE MaBai = {0}", maBai);

            return db.ExecuteNonQuery(sql) > 0;
        }
    }
}
