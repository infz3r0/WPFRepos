using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class KhoanChiDAO
    {
        public List<khoan_chi> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.khoan_chi.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool Add(khoan_chi o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.khoan_chi.Add(o);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return false;
                }
            }
        }

        public bool Update(khoan_chi o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    khoan_chi old = db.khoan_chi.FirstOrDefault(x => x.id_chi == o.id_chi);
                    old.noi_dung_chi = o.noi_dung_chi;
                    old.id_hoat_dong = o.id_hoat_dong;
                    old.so_tien = o.so_tien;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return false;
                }
            }
        }





    }
}
