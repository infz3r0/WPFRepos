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

namespace QuanLyHoiNguoiCaoTuoi.UI.ThanhVien
{
    /// <summary>
    /// Interaction logic for KhuPho.xaml
    /// </summary>
    public partial class ThongTinThanhVien : Window
    {
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private KhuPhoDAO khuPhoDAO = new KhuPhoDAO();
        private TYPE type;
        private thanh_vien o;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        private void LoadDefaultData()
        {
            //gioi_tinh
            List<ComboBoxPairs> gioi_tinhL = new List<ComboBoxPairs>
            {
                new ComboBoxPairs("Nam", "false"),
                new ComboBoxPairs("Nữ", "true")
            };

            cmbGioiTinh.DisplayMemberPath = "_Key";
            cmbGioiTinh.SelectedValuePath = "_Value";

            cmbGioiTinh.ItemsSource = gioi_tinhL;
            cmbGioiTinh.SelectedIndex = 0;

            //chuc_vu
            List<string> chuc_vuL = new List<string>
            {
                "Chủ tịch",
                "Phó chủ tịch",
                "Ủy viên",
                "Thành viên"
            };

            cmbChucVu.ItemsSource = chuc_vuL;
            cmbChucVu.SelectedIndex = 0;

            //khu_pho
            List<khu_pho> khu_phoL = khuPhoDAO.GetList();
            cmbKhuPho.DisplayMemberPath = "ten_khu_pho";
            cmbKhuPho.SelectedValuePath = "id_khu_pho";

            cmbKhuPho.ItemsSource = khu_phoL;
            cmbKhuPho.SelectedIndex = 0;

            //ngay_tham_gia
            dtpNgayThamGia.SelectedDate = DateTime.Now;
        }

        public ThongTinThanhVien()
        {
            InitializeComponent();
            LoadDefaultData();
            type = TYPE.ADD;
            lblTitle.Content = "Thêm thành viên";
            txbHoTen.Focus();
        }

        public ThongTinThanhVien(thanh_vien o)
        {
            InitializeComponent();
            LoadDefaultData();
            type = TYPE.EDIT;
            this.o = (thanh_vien)o;
            lblTitle.Content = "Sửa thành viên";

            txbHoTen.Text = o.ho_ten;
            dtpNgaySinh.SelectedDate = o.ngay_sinh;
            cmbGioiTinh.SelectedValue = o.gioi_tinh.ToString().ToLower();
            txbDiaChi.Text = o.dia_chi;
            cmbKhuPho.SelectedValue = o.id_khu_pho;
            cmbChucVu.SelectedItem = o.chuc_vu;
            dtpNgayThamGia.SelectedDate = o.ngay_tham_gia;

            txbHoTen.Focus();

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txbHoTen.Text.Length > 50 || string.IsNullOrEmpty(txbHoTen.Text) || string.IsNullOrWhiteSpace(txbHoTen.Text))
            {
                MessageBox.Show("Tên thành viên không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbHoTen.Focus();
                return;
            }

            //if (txbDiaChi.Text.Length > 50 || string.IsNullOrEmpty(txbDiaChi.Text) || string.IsNullOrWhiteSpace(txbDiaChi.Text))
            //{
            //    MessageBox.Show("Địa chỉ không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    txbDiaChi.Focus();
            //    return;
            //}

            if (DateTime.Now.Year - ((DateTime)dtpNgaySinh.SelectedDate).Year < 40)
            {
                MessageBox.Show("Chưa đủ tuổi tham gia", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpNgaySinh.Focus();
                return;
            }

            if ((DateTime)dtpNgayThamGia.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Ngày tham gia không thể lớn hơn hiện tại", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpNgayThamGia.Focus();
                return;
            }

            if (type == TYPE.ADD)
            {
                thanh_vien newo = new thanh_vien();
                newo.ho_ten = txbHoTen.Text;
                newo.ngay_sinh = dtpNgaySinh.SelectedDate;
                newo.gioi_tinh = Convert.ToBoolean(cmbGioiTinh.SelectedValue);
                newo.dia_chi = txbDiaChi.Text;
                newo.id_khu_pho = Convert.ToInt32(cmbKhuPho.SelectedValue);
                newo.chuc_vu = cmbChucVu.SelectedItem.ToString();
                newo.ngay_tham_gia = (DateTime)dtpNgayThamGia.SelectedDate;

                if (thanhVienDAO.Add(newo))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbHoTen.Clear();
                    txbDiaChi.Clear();
                }
                txbHoTen.Focus();
            }
            else if (type == TYPE.EDIT)
            {
                o.ho_ten = txbHoTen.Text;
                o.ngay_sinh = dtpNgaySinh.SelectedDate;
                o.gioi_tinh = Convert.ToBoolean(cmbGioiTinh.SelectedValue);
                o.dia_chi = txbDiaChi.Text;
                o.id_khu_pho = Convert.ToInt32(cmbKhuPho.SelectedValue);
                o.chuc_vu = cmbChucVu.SelectedItem.ToString();
                o.ngay_tham_gia = (DateTime)dtpNgayThamGia.SelectedDate;

                if (thanhVienDAO.Update(o))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                txbHoTen.Focus();
            }
        }

        //end class
    }
}
