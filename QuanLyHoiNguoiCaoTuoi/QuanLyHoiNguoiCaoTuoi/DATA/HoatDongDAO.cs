using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class HoatDongDAO
    {
        public List<hoat_dong> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.hoat_dong.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool Add(hoat_dong o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.hoat_dong.Add(o);
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

        public bool Update(hoat_dong o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    hoat_dong old = db.hoat_dong.FirstOrDefault(x => x.id_hoat_dong == o.id_hoat_dong);
                    old.tieu_de = o.tieu_de;
                    old.noi_dung = o.noi_dung;
                    old.ngay_bat_dau = o.ngay_bat_dau;
                    old.ngay_ket_thuc = o.ngay_ket_thuc;
                    old.diem_chuan = o.diem_chuan;
                    old.tu_cham_diem = o.tu_cham_diem;

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
