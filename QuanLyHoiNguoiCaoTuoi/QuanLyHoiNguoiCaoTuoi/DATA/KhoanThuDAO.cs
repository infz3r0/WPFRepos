﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class KhoanThuDAO
    {
        public List<khoan_thu> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.khoan_thu.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool Add(khoan_thu o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.khoan_thu.Add(o);
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

        public bool Update(khoan_thu o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    khoan_thu old = db.khoan_thu.FirstOrDefault(x => x.id_thu == o.id_thu);
                    old.id_nguoi_thu = o.id_nguoi_thu;
                    old.id_nguoi_nop_tien = o.id_nguoi_nop_tien;
                    old.noi_dung_thu = o.noi_dung_thu;
                    old.so_tien = o.so_tien;
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
