using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class ThanhVienDAO
    {
        private hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities();

        public bool Add(thanh_vien o)
        {
            try
            {
                db.thanh_vien.Add(o);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CustomException.UnknownException(ex);
                return false;
            }
        }

        public bool Update(thanh_vien o)
        {
            try
            {
                thanh_vien old = db.thanh_vien.FirstOrDefault(x => x.id_thanh_vien == o.id_thanh_vien);
                old.ho_ten = o.ho_ten;
                old.gioi_tinh = o.gioi_tinh;
                old.ngay_sinh = o.ngay_sinh;
                old.dia_chi = o.dia_chi;
                old.id_khu_pho = o.id_khu_pho;
                old.chuc_vu = o.chuc_vu;
                old.ngay_tham_gia = o.ngay_tham_gia;

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
