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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        private TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        private bool loggedin;

        public DangNhap()
        {
            InitializeComponent();

            lblTitle.Content = "Đăng nhập";
            loggedin = false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //username
            if (string.IsNullOrEmpty(txbUsername.Text) || string.IsNullOrWhiteSpace(txbUsername.Text))
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

            if (taiKhoanDAO.Login(txbUsername.Text, txbPassword.Password) == false)
            {
                MessageBox.Show("Sai thông tin đăng nhập", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txbPassword.Clear();
                txbPassword.Focus();
                return;
            }
            else
            {
                loggedin = true;
                MessageBox.Show("Success", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!loggedin)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }



        //end class
    }
}
