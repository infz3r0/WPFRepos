using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class ThanhVienHopDAO
    {
        public List<thanh_vien_tham_gia_hop> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.thanh_vien_tham_gia_hop.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }



        public List<thanh_vien_tham_gia_hop> GetListByLanHopYear(int l, int y)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.thanh_vien_tham_gia_hop.Include("thanh_vien").Where(x => x.lan_hop == l && x.nam == y).ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool Add(thanh_vien_tham_gia_hop o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.thanh_vien_tham_gia_hop.Add(o);
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

        public bool Update(thanh_vien_tham_gia_hop o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    thanh_vien_tham_gia_hop old = db.thanh_vien_tham_gia_hop.FirstOrDefault(x => x.id_thanh_vien == o.id_thanh_vien && x.lan_hop == o.lan_hop && x.nam == o.nam);

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

        public bool Remove(int l, int nam, int id_thanh_vien)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    thanh_vien_tham_gia_hop o = db.thanh_vien_tham_gia_hop.FirstOrDefault(x => x.lan_hop == l && x.nam == nam && x.id_thanh_vien == id_thanh_vien);
                    db.thanh_vien_tham_gia_hop.Remove(o);
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
