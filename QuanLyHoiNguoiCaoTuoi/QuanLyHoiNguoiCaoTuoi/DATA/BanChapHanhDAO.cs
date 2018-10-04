using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    class BanChapHanhDAO
    {
        public List<thong_tin_ban_chap_hanh> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.thong_tin_ban_chap_hanh.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                } 
            }
        }

        public bool Add(thong_tin_ban_chap_hanh o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.thong_tin_ban_chap_hanh.Add(o);
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

        public bool Update(thong_tin_ban_chap_hanh o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    thong_tin_ban_chap_hanh old = db.thong_tin_ban_chap_hanh.FirstOrDefault(x => x.id_thanh_vien == o.id_thanh_vien);
                    old.dan_toc = o.dan_toc;
                    old.ton_giao = o.ton_giao;
                    old.nghe_nghiep = o.nghe_nghiep;
                    old.don_vi_cong_tac = o.don_vi_cong_tac;
                    old.trinh_do_hoc_van = o.trinh_do_hoc_van;
                    old.trinh_do_chuyen_mon = o.trinh_do_chuyen_mon;
                    old.trinh_do_ly_luan_chinh_tri = o.trinh_do_ly_luan_chinh_tri;
                    old.nam_tham_gia_cong_tac = o.nam_tham_gia_cong_tac;
                    old.dang_vien = o.dang_vien;
                    old.cap_uy_vien = o.cap_uy_vien;
                    old.bch_nhiem_ki_truoc = o.bch_nhiem_ki_truoc;
                    old.thanh_phan_co_cau = o.thanh_phan_co_cau;

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
