//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class thong_tin_ban_chap_hanh
    {
        public int id_thanh_vien { get; set; }
        public string dan_toc { get; set; }
        public string ton_giao { get; set; }
        public string nghe_nghiep { get; set; }
        public string don_vi_cong_tac { get; set; }
        public string trinh_do_hoc_van { get; set; }
        public string trinh_do_chuyen_mon { get; set; }
        public string trinh_do_ly_luan_chinh_tri { get; set; }
        public Nullable<int> nam_tham_gia_cong_tac { get; set; }
        public Nullable<bool> dang_vien { get; set; }
        public Nullable<bool> cap_uy_vien { get; set; }
        public Nullable<bool> bch_nhiem_ki_truoc { get; set; }
        public string thanh_phan_co_cau { get; set; }
    
        public virtual thanh_vien thanh_vien { get; set; }
        public virtual thanh_vien thanh_vien1 { get; set; }
    }
}
