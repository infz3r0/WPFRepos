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
    
    public partial class thanh_vien_clb
    {
        public int id_clb { get; set; }
        public int id_thanh_vien { get; set; }
        public Nullable<System.DateTime> ngay_tham_gia { get; set; }
        public bool la_quan_ly { get; set; }
    
        public virtual CLB CLB { get; set; }
        public virtual CLB CLB1 { get; set; }
        public virtual thanh_vien thanh_vien { get; set; }
        public virtual thanh_vien thanh_vien1 { get; set; }
    }
}