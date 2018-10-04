using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using QuanLyHoiNguoiCaoTuoi.DATA;

namespace QuanLyHoiNguoiCaoTuoi.UI.HoatDong
{
    /// <summary>
    /// Interaction logic for HoatDongUpdate.xaml
    /// </summary>
    public partial class HoatDongUpdate : Window
    {
        private ThanhVienHoatDongDAO thanhVienHoatDongDAO = new ThanhVienHoatDongDAO();
        private thanh_vien_tham_gia o;

        public HoatDongUpdate(thanh_vien_tham_gia o)
        {
            InitializeComponent();

            txbHoatDong.Text = o.hoat_dong.tieu_de;
            txbThanhVien.Text = o.thanh_vien.ho_ten;
            txbNhiemVu.Text = o.nhiem_vu;
            txbHoatDong.IsEnabled = false;
            txbThanhVien.IsEnabled = false;

            txbNhiemVu.Focus();

            this.o = o;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            o.nhiem_vu = txbNhiemVu.Text;

            if (thanhVienHoatDongDAO.Update(o))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }






        //end class
    }
}
