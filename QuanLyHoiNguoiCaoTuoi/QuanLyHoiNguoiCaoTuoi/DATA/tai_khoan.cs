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
    
    public partial class tai_khoan
    {
        public int id_thanh_vien { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> last_login { get; set; }
        public int id_quyen { get; set; }
    
        public virtual quyen quyen { get; set; }
        public virtual quyen quyen1 { get; set; }
        public virtual thanh_vien thanh_vien { get; set; }
        public virtual thanh_vien thanh_vien1 { get; set; }
    }
}