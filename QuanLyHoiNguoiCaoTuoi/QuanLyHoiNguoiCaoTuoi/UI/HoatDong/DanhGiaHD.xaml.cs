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
    /// Interaction logic for DanhGiaHD.xaml
    /// </summary>
    public partial class DanhGiaHD : Window
    {
        public DanhGiaHD(hoat_dong o)
        {
            InitializeComponent();

            txbHoatDong.Text = o.tieu_de;
            txbDiemChuan.Text = o.diem_chuan.ToString();
            txbHoatDong.IsEnabled = false;
            txbDiemChuan.IsEnabled = false;

            txbTuChamDiem.Focus();
            this.o = o;
        }

        private HoatDongDAO hoatDongDAO = new HoatDongDAO();
        private hoat_dong o;

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbTuChamDiem.Text) || string.IsNullOrWhiteSpace(txbTuChamDiem.Text))
            {
                MessageBox.Show("Điểm không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTuChamDiem.Focus();
                return;
            }

            int diemchuan = Convert.ToInt32(txbDiemChuan.Text);
            for (int i = 0; i < txbTuChamDiem.Text.Length; i++)
            {
                if (!char.IsDigit(txbTuChamDiem.Text, i))
                {
                    MessageBox.Show("Điểm không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txbTuChamDiem.Focus();
                    return;
                }
            }
            int diem = Convert.ToInt32(txbTuChamDiem.Text);
            if (diem > diemchuan)
            {
                MessageBox.Show("Điểm không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTuChamDiem.Focus();
                return;
            }
            if (diem < 0)
            {
                MessageBox.Show("Điểm không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbDiemChuan.Focus();
                return;
            }

            o.tu_cham_diem = diem;
            o.ket_qua_dat_duoc = txbKetQuaDatDuoc.Text;

            if (hoatDongDAO.Update(o))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }






        //end class
    }
}
