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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword(int id)
        {
            InitializeComponent();
            LoadDefault();
            o = taiKhoanDAO.GetAccount(id);

        }
        private TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        private tai_khoan o;

        public void LoadDefault()
        {
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //password
            if (string.IsNullOrEmpty(txbOldPassword.Password) || string.IsNullOrWhiteSpace(txbOldPassword.Password))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbOldPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txbNewPassword.Password) || string.IsNullOrWhiteSpace(txbNewPassword.Password))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbNewPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txbPasswordConfirm.Password) || string.IsNullOrWhiteSpace(txbPasswordConfirm.Password))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbPasswordConfirm.Focus();
                return;
            }

            //password match
            if (!txbNewPassword.Password.Equals(txbPasswordConfirm.Password))
            {
                MessageBox.Show("Password không trùng khớp", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbNewPassword.Focus();
                return;
            }

            

            if (taiKhoanDAO.ChangePassword(o.id_thanh_vien, txbOldPassword.Password, txbNewPassword.Password))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Sai password", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txbOldPassword.Clear();
                txbNewPassword.Clear();
                txbPasswordConfirm.Clear();
                txbOldPassword.Focus();
            }
        }





        //end class
    }
}
