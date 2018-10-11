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
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
            LoadDefault();
        }
        private TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();

        public void LoadDefault()
        {
            //account
            List<tai_khoan> tai_Khoans = taiKhoanDAO.GetList();
            cmbAccount.DisplayMemberPath = "username";
            cmbAccount.SelectedValuePath = "id_thanh_vien";

            cmbAccount.ItemsSource = tai_Khoans;
            cmbAccount.SelectedIndex = 0;

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string msg = string.Format("Bạn có chắc chắn reset password tài khoản [{0}]", ((tai_khoan)cmbAccount.SelectedItem).username);
            MessageBoxResult res = MessageBox.Show(msg, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(cmbAccount.SelectedValue);
                string newPass = RandomString.GetRandomString();
                string passMD5 = MD5Cal.GetMd5Hash(newPass);

                if (taiKhoanDAO.ResetPassword(id, passMD5))
                {
                    MessageBox.Show("Reset thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbNewPassword.Text = newPass;
                }
            }


            

        }





        //end class
    }
}
