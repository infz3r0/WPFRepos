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

namespace QuanLyHoiNguoiCaoTuoi.UI.Quy
{
    /// <summary>
    /// Interaction logic for Chi.xaml
    /// </summary>
    public partial class Chi : Window
    {
        private KhoanChiDAO khoanChiDAO = new KhoanChiDAO();
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private HoatDongDAO hoatDongDAO = new HoatDongDAO();
        private TYPE type;
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
            
            
        }

        public Chi()
        {
            InitializeComponent();
            type = TYPE.ADD;
            LoadDefault();
            lblTitle.Content = "Thêm khoản chi";
            txbNoiDung.Focus();
        }

        public Chi(khoan_chi o)
        {
            InitializeComponent();
            type = TYPE.EDIT;
            LoadDefault();
            this.o = (khoan_chi)o;
            lblTitle.Content = "Sửa khoản Chi";
            txbNoiDung.Text = o.noi_dung_chi;
            txbSoTien.Text = o.so_tien.ToString();
            cmbHoatDong.SelectedValue = o.id_hoat_dong;

            txbNoiDung.Focus();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNoiDung.Text) || string.IsNullOrWhiteSpace(txbNoiDung.Text))
            {
                MessageBox.Show("Nội dung không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbNoiDung.Focus();
                return;
            }

            for (int i = 0; i < txbSoTien.Text.Length; i++)
            {
                if (!char.IsDigit(txbSoTien.Text, i))
                {
                    MessageBox.Show("Số tiền không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txbSoTien.Focus();
                    return;
                }
            }



            if (type == TYPE.ADD)
            {


                khoan_chi newo = new khoan_chi();
                newo.noi_dung_chi = txbNoiDung.Text;
                newo.so_tien = Convert.ToDecimal(txbSoTien.Text);
                newo.id_hoat_dong = Convert.ToInt32(cmbHoatDong.SelectedValue);


                if (khoanChiDAO.Add(newo))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbNoiDung.Clear();
                    txbSoTien.Clear();

                }
                txbNoiDung.Focus();
            }
            else if (type == TYPE.EDIT)
            {
                o.noi_dung_chi = txbNoiDung.Text;
                o.so_tien = Convert.ToDecimal(txbSoTien.Text);
                o.id_hoat_dong = Convert.ToInt32(cmbHoatDong.SelectedValue);

                if (khoanChiDAO.Update(o))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                txbNoiDung.Focus();
            }
        }



        //end class
    }
}
