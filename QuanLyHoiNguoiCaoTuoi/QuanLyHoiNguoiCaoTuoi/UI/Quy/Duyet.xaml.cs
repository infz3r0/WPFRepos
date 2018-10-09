using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using QuanLyHoiNguoiCaoTuoi.DATA;

namespace QuanLyHoiNguoiCaoTuoi.UI.Quy
{
    /// <summary>
    /// Interaction logic for Duyet.xaml
    /// </summary>
    public partial class Duyet : Window
    {
        private KhoanChiDAO khoanChiDAO = new KhoanChiDAO();
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private HoatDongDAO hoatDongDAO = new HoatDongDAO();
        private khoan_chi o;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        public void LoadDefault()
        {
            // hoat dong
            cmbHoatDong.ItemsSource = hoatDongDAO.GetList();
            cmbHoatDong.DisplayMemberPath = "tieu_de";
            cmbHoatDong.SelectedValuePath = "id_hoat_dong";
            cmbHoatDong.SelectedIndex = 0;

            //ng duyet
            cmbNguoiDuyet.ItemsSource = thanhVienDAO.GetList();
            cmbNguoiDuyet.DisplayMemberPath = "ho_ten";
            cmbNguoiDuyet.SelectedValuePath = "id_thanh_vien";
            cmbNguoiDuyet.SelectedIndex = 0;
        }

        public Duyet(khoan_chi o)
        {
            InitializeComponent();
            LoadDefault();
            this.o = (khoan_chi)o;
            lblTitle.Content = "Duyệt khoản Chi";
            txbNoiDung.Text = o.noi_dung_chi;
            txbSoTien.Text = o.so_tien.ToString();
            cmbHoatDong.SelectedValue = o.id_hoat_dong;

            txbNoiDung.Focus();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Bạn có chắc chắn duyệt khoản chi này?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                o.da_duyet = true;
                o.ngay_duyet = DateTime.Now;
                o.id_nguoi_duyet = Convert.ToInt32(cmbNguoiDuyet.SelectedValue);

                if (khoanChiDAO.Update(o))
                {
                    System.Windows.Forms.MessageBox.Show("Duyệt thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }



        //end class
    }
}
