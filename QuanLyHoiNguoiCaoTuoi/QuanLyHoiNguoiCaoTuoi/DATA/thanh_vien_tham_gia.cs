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
    
    public partial class thanh_vien_tham_gia
    {
        public int id_thanh_vien { get; set; }
        public int id_hoat_dong { get; set; }
        public string nhiem_vu { get; set; }
    
        public virtual hoat_dong hoat_dong { get; set; }
        public virtual hoat_dong hoat_dong1 { get; set; }
        public virtual thanh_vien thanh_vien { get; set; }
        public virtual thanh_vien thanh_vien1 { get; set; }
    }
}
