//------------------------------------------------------------------------------
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
    using System.Collections.ObjectModel;
    
    public partial class thanh_vien_tham_gia_hop
    {
        public int lan_hop { get; set; }
        public int nam { get; set; }
        public int id_thanh_vien { get; set; }
    
        public virtual hop_thuong_nien hop_thuong_nien { get; set; }
        public virtual hop_thuong_nien hop_thuong_nien1 { get; set; }
        public virtual thanh_vien thanh_vien { get; set; }
        public virtual thanh_vien thanh_vien1 { get; set; }
    }
}
