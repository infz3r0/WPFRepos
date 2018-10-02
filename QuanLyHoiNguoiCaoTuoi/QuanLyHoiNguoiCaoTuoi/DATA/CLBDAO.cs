using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class CLBDAO
    {
        private hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities();

        public List<CLB> GetList()
        {
            try
            {
                return db.CLBs.ToList();
            }
            catch (Exception ex)
            {
                CustomException.UnknownException(ex);
                return null;
            }
        }

        public thanh_vien_clb GetQuanLy(int id_clb)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.thanh_vien_clb.FirstOrDefault(x => x.id_clb == id_clb && x.la_quan_ly == true);
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool Add(CLB o)
        {
            try
            {
                db.CLBs.Add(o);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CustomException.UnknownException(ex);
                return false;
            }
        }

        public bool Update(CLB o)
        {
            try
            {
                CLB old = db.CLBs.FirstOrDefault(x => x.id_clb == o.id_clb);
                old.ten_clb = o.ten_clb;
                old.ngay_thanh_lap = o.ngay_thanh_lap;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CustomException.UnknownException(ex);
                return false;
            }
        }


        //end class
    }
}
