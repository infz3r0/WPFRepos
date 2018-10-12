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

namespace QuanLyHoiNguoiCaoTuoi.UI.TaiKhoan
{
    /// <summary>
    /// Interaction logic for UpdateAccount.xaml
    /// </summary>
    public partial class UpdateAccount : Window
    {
        public UpdateAccount(int id)
        {
            InitializeComponent();
            LoadDefault();
            o = taiKhoanDAO.GetAccount(id);

            cmbIDThanhVien.SelectedValue = o.id_thanh_vien;
            txbUsername.Text = o.username;
            txbEmail.Text = o.email;
            cmbGroup.SelectedValue = o.id_quyen;
        }
        private TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private tai_khoan o;

        public void LoadDefault()
        {
            //thanh vien
            List<thanh_vien> thanh_vienL = thanhVienDAO.GetList();
            cmbIDThanhVien.DisplayMemberPath = "ho_ten";
            cmbIDThanhVien.SelectedValuePath = "id_thanh_vien";

            cmbIDThanhVien.ItemsSource = thanh_vienL;
            cmbIDThanhVien.SelectedIndex = 0;

            //quyen
            List<quyen> quyenL = taiKhoanDAO.GetListQuyen();
            cmbGroup.DisplayMemberPath = "mo_ta";
            cmbGroup.SelectedValuePath = "id_quyen";

            cmbGroup.ItemsSource = quyenL;
            cmbGroup.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //email
            if (txbEmail.Text.Length > 100 || string.IsNullOrEmpty(txbEmail.Text) || string.IsNullOrWhiteSpace(txbEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbEmail.Focus();
                return;
            }

            
            o.email = txbEmail.Text;

            if (taiKhoanDAO.Update(o))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }





        //end class
    }
}
