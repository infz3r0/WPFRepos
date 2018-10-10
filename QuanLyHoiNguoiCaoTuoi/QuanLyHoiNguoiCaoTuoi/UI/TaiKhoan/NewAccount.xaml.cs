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
    /// Interaction logic for NewAccount.xaml
    /// </summary>
    public partial class NewAccount : Window
    {
        private TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();

        public NewAccount()
        {
            InitializeComponent();
            LoadDefault();
        }

        public void LoadDefault()
        {
            //thanh vien
            List<thanh_vien> thanh_vienL = thanhVienDAO.GetListNotInTaiKhoan();
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
            //username
            if (txbUsername.Text.Length > 50 || string.IsNullOrEmpty(txbUsername.Text) || string.IsNullOrWhiteSpace(txbUsername.Text))
            {
                MessageBox.Show("Username không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbUsername.Focus();
                return;
            }

            //password
            if (string.IsNullOrEmpty(txbPassword.Password) || string.IsNullOrWhiteSpace(txbPassword.Password))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbPassword.Focus();
                return;
            }

            if ( string.IsNullOrEmpty(txbPasswordConfirm.Password) || string.IsNullOrWhiteSpace(txbPasswordConfirm.Password))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbPasswordConfirm.Focus();
                return;
            }

            //password match
            if (!txbPassword.Password.Equals(txbPasswordConfirm.Password))
            {
                MessageBox.Show("Password không trùng khớp", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbPassword.Focus();
                return;
            }

            //email
            if (txbEmail.Text.Length > 100 || string.IsNullOrEmpty(txbEmail.Text) || string.IsNullOrWhiteSpace(txbEmail.Text))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbEmail.Focus();
                return;
            }


            tai_khoan newo = new tai_khoan();
            newo.id_thanh_vien = Convert.ToInt32(cmbIDThanhVien.SelectedValue);
            newo.username = txbUsername.Text;
            newo.password = MD5Cal.GetMd5Hash(txbPassword.Password);
            newo.email = txbEmail.Text;
            newo.id_quyen = Convert.ToInt32(cmbGroup.SelectedValue);

            if (taiKhoanDAO.Add(newo))
            {
                MessageBox.Show("Tạo thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }





        //end class
    }
}
