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
        public List<thanh_vien> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.thanh_vien.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                } 
            }
        }



        public List<thanh_vien> GetListNotInBCH()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    List<int> ids = db.thong_tin_ban_chap_hanh.Select(x => x.id_thanh_vien).ToList();
                    return db.thanh_vien.Where(x => !ids.Contains(x.id_thanh_vien)).ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                } 
            }
        }

        public List<thanh_vien> GetListNotInCLB(int id_clb)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    List<int> id_tv_clb = db.thanh_vien_clb.Where(x => x.id_clb == id_clb).Select(x=>x.id_thanh_vien).ToList();
                    return db.thanh_vien.Include("khu_pho").Where(x => !id_tv_clb.Contains(x.id_thanh_vien)).ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public List<thanh_vien> GetListNotInHoatDong(int id_hoat_dong)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    List<int> id_tv_hoat_dong = db.thanh_vien_tham_gia.Where(x => x.id_hoat_dong == id_hoat_dong).Select(x => x.id_thanh_vien).ToList();
                    return db.thanh_vien.Include("khu_pho").Where(x => !id_tv_hoat_dong.Contains(x.id_thanh_vien)).ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public List<thanh_vien> GetListNotInHopTN(int l, int y)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    List<int> id_tv_hop = db.thanh_vien_tham_gia_hop.Where(x => x.lan_hop == l && x.nam == y).Select(x => x.id_thanh_vien).ToList();
                    return db.thanh_vien.Include("khu_pho").Where(x => !id_tv_hop.Contains(x.id_thanh_vien)).ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public List<thanh_vien> GetListNotInTaiKhoan()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    List<int> id_tv_tk = db.tai_khoan.Select(x => x.id_thanh_vien).ToList();
                    return db.thanh_vien.Where(x => !id_tv_tk.Contains(x.id_thanh_vien)).ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool Add(thanh_vien o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
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
        }

        public bool Update(thanh_vien o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
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
        }


        //end class
    }
}
