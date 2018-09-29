using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class HopBCHDAO
    {
        private hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities();

        public List<hop_bch> GetList()
        {
            try
            {
                return db.hop_bch.ToList();
            }
            catch (Exception ex)
            {
                CustomException.UnknownException(ex);
                return null;
            }
        }

        public bool Add(hop_bch o)
        {
            try
            {
                db.hop_bch.Add(o);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                CustomException.UnknownException(ex);
                return false;
            }
        }

        public bool Update(hop_bch o)
        {
            try
            {
                hop_bch old = db.hop_bch.FirstOrDefault(x => x.thang == o.thang && x.nam == o.nam);
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
