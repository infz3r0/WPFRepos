using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class BCHThamGiaHopDAO
    {
        public List<bch_tham_gia_hop> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.bch_tham_gia_hop.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        

        public List<bch_tham_gia_hop> GetListByMonthYear(int m, int y)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.bch_tham_gia_hop.Include("thanh_vien").Where(x => x.thang == m && x.nam == y).ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool Add(bch_tham_gia_hop o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.bch_tham_gia_hop.Add(o);
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

        public bool Update(bch_tham_gia_hop o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    bch_tham_gia_hop old = db.bch_tham_gia_hop.FirstOrDefault(x => x.id_thanh_vien == o.id_thanh_vien && x.thang == o.thang && x.nam == o.nam);

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

        public bool Remove(int thang, int nam, int id_thanh_vien)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    bch_tham_gia_hop o = db.bch_tham_gia_hop.FirstOrDefault(x => x.thang == thang && x.nam == nam && x.id_thanh_vien == id_thanh_vien);
                    db.bch_tham_gia_hop.Remove(o);
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
