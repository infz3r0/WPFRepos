using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class KhuPhoDAO
    {
        public List<khu_pho> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.khu_pho.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                } 
            }
        }

        public bool Add(khu_pho o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.khu_pho.Add(o);
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

        public bool Update(khu_pho o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    khu_pho old = db.khu_pho.FirstOrDefault(x => x.id_khu_pho == o.id_khu_pho);
                    old.ten_khu_pho = o.ten_khu_pho;
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


        //end class
    }
}
