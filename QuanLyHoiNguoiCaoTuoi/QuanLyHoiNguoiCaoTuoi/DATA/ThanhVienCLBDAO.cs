using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class ThanhVienCLBDAO
    {

        public List<thanh_vien_clb> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.thanh_vien_clb.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public List<thanh_vien_clb> GetList(int id_clb)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.thanh_vien_clb.Include("thanh_vien").Where(x=>x.id_clb == id_clb && x.la_quan_ly == false).ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public void ChangeQuanLy(int id_clb, int id_old_quan_ly, int id_new_quan_ly)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    //set old ql = false
                    thanh_vien_clb old_ql = db.thanh_vien_clb.FirstOrDefault(x => x.id_clb == id_clb && x.id_thanh_vien == id_old_quan_ly);
                    old_ql.la_quan_ly = false;

                    //if new ql exists in clb set ql = true
                    thanh_vien_clb new_ql = db.thanh_vien_clb.FirstOrDefault(x => x.id_clb == id_clb && x.id_thanh_vien == id_new_quan_ly);
                    if (new_ql != null)
                    {
                        new_ql.la_quan_ly = true;
                    }
                    //else add new ql to clb
                    else
                    {
                        thanh_vien_clb newo = new thanh_vien_clb()
                        {
                            id_clb = id_clb,
                            id_thanh_vien = id_new_quan_ly,
                            ngay_tham_gia = DateTime.Now,
                            la_quan_ly = true
                        };
                        db.thanh_vien_clb.Add(newo);
                    }

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return;
                }
            }
        }

        public bool Add(thanh_vien_clb o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.thanh_vien_clb.Add(o);
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

        public bool Remove(int id_clb, int id_thanh_vien)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    thanh_vien_clb o = db.thanh_vien_clb.FirstOrDefault(x => x.id_clb == id_clb && x.id_thanh_vien == id_thanh_vien);
                    db.thanh_vien_clb.Remove(o);
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
