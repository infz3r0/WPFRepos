using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class HopTNDAO
    {
        private hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities();

        public List<hop_thuong_nien> GetList()
        {
            try
            {
                return db.hop_thuong_nien.ToList();
            }
            catch (Exception ex)
            {
                CustomException.UnknownException(ex);
                return null;
            }
        }

        public bool Add(hop_thuong_nien o)
        {
            try
            {
                db.hop_thuong_nien.Add(o);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CustomException.UnknownException(ex);
                return false;
            }
        }

        public bool Update(hop_thuong_nien o)
        {
            try
            {
                hop_thuong_nien old = db.hop_thuong_nien.FirstOrDefault(x => x.lan_hop == o.lan_hop && x.nam == o.nam);
                old.noi_dung = o.noi_dung;
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
