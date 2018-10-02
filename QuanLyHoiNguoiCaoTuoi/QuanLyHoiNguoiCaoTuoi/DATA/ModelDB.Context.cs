﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyHoiNguoiCaoTuoi.DATA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class hoi_nguoi_cao_tuoiEntities : DbContext
    {
        public hoi_nguoi_cao_tuoiEntities()
            : base("name=hoi_nguoi_cao_tuoiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bch_tham_gia_hop> bch_tham_gia_hop { get; set; }
        public virtual DbSet<CLB> CLBs { get; set; }
        public virtual DbSet<dong_gop> dong_gop { get; set; }
        public virtual DbSet<hoat_dong> hoat_dong { get; set; }
        public virtual DbSet<hop_thuong_nien> hop_thuong_nien { get; set; }
        public virtual DbSet<khoan_chi> khoan_chi { get; set; }
        public virtual DbSet<khoan_thu> khoan_thu { get; set; }
        public virtual DbSet<khu_pho> khu_pho { get; set; }
        public virtual DbSet<quyen> quyens { get; set; }
        public virtual DbSet<tai_khoan> tai_khoan { get; set; }
        public virtual DbSet<thanh_vien> thanh_vien { get; set; }
        public virtual DbSet<thanh_vien_clb> thanh_vien_clb { get; set; }
        public virtual DbSet<thanh_vien_tham_gia> thanh_vien_tham_gia { get; set; }
        public virtual DbSet<thanh_vien_tham_gia_hop> thanh_vien_tham_gia_hop { get; set; }
        public virtual DbSet<thong_tin_ban_chap_hanh> thong_tin_ban_chap_hanh { get; set; }
        public virtual DbSet<tong_ket> tong_ket { get; set; }
        public virtual DbSet<hop_bch> hop_bch { get; set; }
    
        public virtual int P_Delete_khu_pho(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_Delete_khu_pho", idParameter);
        }
    
        public virtual int P_Delete_clb(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_Delete_clb", idParameter);
        }
    
        public virtual int P_Delete_thanh_vien(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_Delete_thanh_vien", idParameter);
        }
    
        public virtual int P_Delete_thong_tin_ban_chap_hanh(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_Delete_thong_tin_ban_chap_hanh", idParameter);
        }
    
        public virtual int P_Delete_hop_bch(Nullable<int> thang, Nullable<int> nam)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("thang", thang) :
                new ObjectParameter("thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("nam", nam) :
                new ObjectParameter("nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_Delete_hop_bch", thangParameter, namParameter);
        }
    
        public virtual int P_Delete_hop_tn(Nullable<int> lanhop, Nullable<int> nam)
        {
            var lanhopParameter = lanhop.HasValue ?
                new ObjectParameter("lanhop", lanhop) :
                new ObjectParameter("lanhop", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("nam", nam) :
                new ObjectParameter("nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_Delete_hop_tn", lanhopParameter, namParameter);
        }
    }
}
