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
    
    public partial class thanh_vien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public thanh_vien()
        {
            this.bch_tham_gia_hop = new ObservableCollection<bch_tham_gia_hop>();
            this.bch_tham_gia_hop1 = new ObservableCollection<bch_tham_gia_hop>();
            this.khoan_chi = new ObservableCollection<khoan_chi>();
            this.khoan_chi1 = new ObservableCollection<khoan_chi>();
            this.khoan_thu = new ObservableCollection<khoan_thu>();
            this.khoan_thu1 = new ObservableCollection<khoan_thu>();
            this.khoan_thu2 = new ObservableCollection<khoan_thu>();
            this.khoan_thu3 = new ObservableCollection<khoan_thu>();
            this.thanh_vien_clb = new ObservableCollection<thanh_vien_clb>();
            this.thanh_vien_tham_gia_hop = new ObservableCollection<thanh_vien_tham_gia_hop>();
            this.thanh_vien_tham_gia = new ObservableCollection<thanh_vien_tham_gia>();
            this.thanh_vien_clb1 = new ObservableCollection<thanh_vien_clb>();
            this.thanh_vien_tham_gia_hop1 = new ObservableCollection<thanh_vien_tham_gia_hop>();
            this.thanh_vien_tham_gia1 = new ObservableCollection<thanh_vien_tham_gia>();
        }
    
        public int id_thanh_vien { get; set; }
        public int id_khu_pho { get; set; }
        public string ho_ten { get; set; }
        public bool gioi_tinh { get; set; }
        public Nullable<System.DateTime> ngay_sinh { get; set; }
        public string dia_chi { get; set; }
        public string chuc_vu { get; set; }
        public System.DateTime ngay_tham_gia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<bch_tham_gia_hop> bch_tham_gia_hop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<bch_tham_gia_hop> bch_tham_gia_hop1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<khoan_chi> khoan_chi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<khoan_chi> khoan_chi1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<khoan_thu> khoan_thu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<khoan_thu> khoan_thu1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<khoan_thu> khoan_thu2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<khoan_thu> khoan_thu3 { get; set; }
        public virtual khu_pho khu_pho { get; set; }
        public virtual khu_pho khu_pho1 { get; set; }
        public virtual tai_khoan tai_khoan { get; set; }
        public virtual tai_khoan tai_khoan1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<thanh_vien_clb> thanh_vien_clb { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<thanh_vien_tham_gia_hop> thanh_vien_tham_gia_hop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<thanh_vien_tham_gia> thanh_vien_tham_gia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<thanh_vien_clb> thanh_vien_clb1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<thanh_vien_tham_gia_hop> thanh_vien_tham_gia_hop1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<thanh_vien_tham_gia> thanh_vien_tham_gia1 { get; set; }
        public virtual thong_tin_ban_chap_hanh thong_tin_ban_chap_hanh { get; set; }
        public virtual thong_tin_ban_chap_hanh thong_tin_ban_chap_hanh1 { get; set; }
    }
}