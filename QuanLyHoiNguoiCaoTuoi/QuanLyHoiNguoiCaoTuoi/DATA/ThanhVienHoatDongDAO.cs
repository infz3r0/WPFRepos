using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class ThanhVienHoatDongDAO
    {
        public List<thanh_vien_tham_gia> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.thanh_vien_tham_gia.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public List<thanh_vien_tham_gia> GetList(int id_hoat_dong)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.thanh_vien_tham_gia.Include("thanh_vien").Where(x => x.id_hoat_dong == id_hoat_dong).ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool Add(thanh_vien_tham_gia o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.thanh_vien_tham_gia.Add(o);
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

        public bool Update(thanh_vien_tham_gia o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    thanh_vien_tham_gia old = db.thanh_vien_tham_gia.FirstOrDefault(x => x.id_thanh_vien == o.id_thanh_vien && x.id_hoat_dong == o.id_hoat_dong);
                    old.nhiem_vu = o.nhiem_vu;

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

        public bool Remove(int id_hoat_dong, int id_thanh_vien)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    thanh_vien_tham_gia o = db.thanh_vien_tham_gia.FirstOrDefault(x => x.id_hoat_dong == id_hoat_dong && x.id_thanh_vien == id_thanh_vien);
                    db.thanh_vien_tham_gia.Remove(o);
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
