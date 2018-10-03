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
    /// Interaction logic for HoatDong.xaml
    /// </summary>
    public partial class HoatDong : Window
    {
        private HoatDongDAO hoatDongDAO = new HoatDongDAO();
        private TongKetDAO tongKetDAO = new TongKetDAO();
        private TYPE type;
        private hoat_dong o;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        private void LoadDefaultData()
        {
            //nam
            List<int> years = new List<int>();

            for (int i = 1800; i <= 2200; i++)
            {
                years.Add(i);
            }

            cmbNam.ItemsSource = years;
            cmbNam.SelectedIndex = 200;

            //ngay
            dtpNgayBatDau.SelectedDate = DateTime.Now;
            dtpNgayKetThuc.SelectedDate = DateTime.Now;

            txbDiemChuan.Text = "0";
        }

        public HoatDong()
        {
            InitializeComponent();
            LoadDefaultData();
            type = TYPE.ADD;
            lblTitle.Content = "Thêm hoạt động";
            cmbNam.Focus();
        }

        public HoatDong(hoat_dong o)
        {
            InitializeComponent();
            LoadDefaultData();
            type = TYPE.EDIT;
            this.o = (hoat_dong)o;
            lblTitle.Content = "Sửa hoạt động";

            cmbNam.SelectedItem = o.nam;
            txbTieuDe.Text = o.tieu_de;
            txbNoiDung.Text = o.noi_dung;
            dtpNgayBatDau.SelectedDate = o.ngay_bat_dau;
            dtpNgayKetThuc.SelectedDate = o.ngay_ket_thuc;
            txbDiemChuan.Text = o.diem_chuan.ToString();

            txbTieuDe.Focus();

            cmbNam.IsEnabled = false;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txbTieuDe.Text.Length > 50 || string.IsNullOrEmpty(txbTieuDe.Text) || string.IsNullOrWhiteSpace(txbTieuDe.Text))
            {
                MessageBox.Show("Tiêu đề không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTieuDe.Focus();
                return;
            }

            if (txbNoiDung.Text.Length > 3000 || string.IsNullOrEmpty(txbNoiDung.Text) || string.IsNullOrWhiteSpace(txbNoiDung.Text))
            {
                MessageBox.Show("Nội dung không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbNoiDung.Focus();
                return;
            }

            if ((DateTime)dtpNgayBatDau.SelectedDate > (DateTime)dtpNgayKetThuc.SelectedDate)
            {
                MessageBox.Show("Ngày bắt đầu hoặc kết thúc không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpNgayBatDau.Focus();
                return;
            }

            for (int i = 0; i < txbDiemChuan.Text.Length; i++)
            {
                if (!char.IsDigit(txbDiemChuan.Text, i))
                {
                    MessageBox.Show("Điểm chuẩn không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txbDiemChuan.Focus();
                    return;
                }
            }

            if (Convert.ToInt32(txbDiemChuan.Text) < 0)
            {
                MessageBox.Show("Điểm chuẩn không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbDiemChuan.Focus();
                return;
            }

            if (type == TYPE.ADD)
            {
                int y = Convert.ToInt32(cmbNam.SelectedItem);
                if (!tongKetDAO.IsExists(y))
                {
                    tong_ket tong_Ket = new tong_ket();
                    tong_Ket.nam = y;
                    tong_Ket.tong_diem = 0;
                    tongKetDAO.Add(tong_Ket);
                }


                hoat_dong newo = new hoat_dong();
                newo.tieu_de = txbTieuDe.Text;
                newo.noi_dung = txbNoiDung.Text;
                newo.ngay_bat_dau = dtpNgayBatDau.SelectedDate;
                newo.ngay_ket_thuc = dtpNgayKetThuc.SelectedDate;
                newo.diem_chuan = Convert.ToInt32(txbDiemChuan.Text);
                newo.nam = Convert.ToInt32(cmbNam.SelectedItem);

                if (hoatDongDAO.Add(newo))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbTieuDe.Clear();
                    txbNoiDung.Clear();
                    txbDiemChuan.Clear();
                }
                txbTieuDe.Focus();
            }
            else if (type == TYPE.EDIT)
            {
                o.tieu_de = txbTieuDe.Text;
                o.noi_dung = txbNoiDung.Text;
                o.ngay_bat_dau = dtpNgayBatDau.SelectedDate;
                o.ngay_ket_thuc = dtpNgayKetThuc.SelectedDate;
                o.diem_chuan = Convert.ToInt32(txbDiemChuan.Text);
                o.nam = Convert.ToInt32(cmbNam.SelectedItem);

                if (hoatDongDAO.Update(o))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                txbTieuDe.Focus();
            }
        }

        //end class
    }
}
