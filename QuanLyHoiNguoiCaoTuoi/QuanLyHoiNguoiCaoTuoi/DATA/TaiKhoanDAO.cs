﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    public class TaiKhoanDAO
    {
        public List<tai_khoan> GetList()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.tai_khoan.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public tai_khoan GetAccount(int id)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.tai_khoan.FirstOrDefault(x => x.id_thanh_vien == id);
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public List<quyen> GetListQuyen()
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    return db.quyens.ToList();
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool Add(tai_khoan o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    db.tai_khoan.Add(o);
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

        public bool Update(tai_khoan o)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    tai_khoan old = db.tai_khoan.FirstOrDefault(x => x.id_thanh_vien == o.id_thanh_vien);
                    old.username = o.username;
                    old.password = o.password;
                    old.email = o.email;
                    old.id_quyen = o.id_quyen;



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

        public bool Delete(int id)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    tai_khoan o = db.tai_khoan.FirstOrDefault(x => x.id_thanh_vien == id);
                    db.tai_khoan.Remove(o);



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

        public bool ResetPassword(int id, string pass)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    tai_khoan o = db.tai_khoan.FirstOrDefault(x => x.id_thanh_vien == id);
                    o.password = pass;

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

        public tai_khoan Login(string username, string password)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    string passMD5 = MD5Cal.GetMd5Hash(password);
                    tai_khoan o = db.tai_khoan.FirstOrDefault(x => x.username.Equals(username) && x.password.Equals(passMD5));

                    if (o == null)
                    {
                        return null;
                    }


                    
                    return o;
                }
                catch (Exception ex)
                {
                    CustomException.UnknownException(ex);
                    return null;
                }
            }
        }

        public bool ChangePassword(int id, string oldpass, string newpass)
        {
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                try
                {
                    tai_khoan o = db.tai_khoan.FirstOrDefault(x => x.id_thanh_vien == id);
                    string oldpassMD5 = MD5Cal.GetMd5Hash(oldpass);
                    string newpassMD5 = MD5Cal.GetMd5Hash(newpass);

                    if (o.password.Equals(oldpassMD5))
                    {
                        o.password = newpassMD5;
                    }
                    else
                    {
                        return false;
                    }

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
