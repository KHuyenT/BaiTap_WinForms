using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bài_tự_học_LMS.DAL;
using Bài_tự_học_LMS.DTO;
using System.Data;

namespace Bài_tự_học_LMS.BLL
{
    internal class BaiTapBLL
    {
        BaiTapDAL dal = new BaiTapDAL();

        public DataTable LayDanhSach()
        {
            return dal.GetAllBaiTap();
        }

        public bool ThemMoi(BaiTap bt)
        {
            if (string.IsNullOrEmpty(bt.TenBai)) return false;
            if (bt.Diem < 0 || bt.Diem > 10) return false;
            return dal.ThemBaiTap(bt);
        }

        public bool CapNhat(BaiTap bt)
        {
            if (bt.MaBai <= 0) return false;
            return dal.SuaBaiTap(bt);
        }

        public bool Xoa(int maBai)
        {
            return dal.XoaBaiTap(maBai);
        }
    }
}
