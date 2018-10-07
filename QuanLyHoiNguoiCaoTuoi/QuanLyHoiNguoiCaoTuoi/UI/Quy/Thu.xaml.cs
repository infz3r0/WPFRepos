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
    /// Interaction logic for Thu.xaml
    /// </summary>
    public partial class Thu : Window
    {
        private KhoanThuDAO khoanThuDAO = new KhoanThuDAO();
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private DongGopDAO dongGopDAO = new DongGopDAO();
        private TYPE type;
        private khoan_thu o;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        public void LoadDefault()
        {
            // ng thu
            cmbNguoiThu.ItemsSource = thanhVienDAO.GetList();
            cmbNguoiThu.DisplayMemberPath = "ho_ten";
            cmbNguoiThu.SelectedValuePath = "id_thanh_vien";
            cmbNguoiThu.SelectedIndex = 0;
            // ng nop
            cmbNguoiNop.ItemsSource = thanhVienDAO.GetList();
            cmbNguoiNop.DisplayMemberPath = "ho_ten";
            cmbNguoiNop.SelectedValuePath = "id_thanh_vien";
            cmbNguoiNop.SelectedIndex = 0;

            ckbDongGop.IsChecked = false;
            txbTen.IsEnabled = false;
            txbSDT.IsEnabled = false;
            txbEmail.IsEnabled = false;
        }

        public Thu()
        {
            InitializeComponent();
            type = TYPE.ADD;
            LoadDefault();
            lblTitle.Content = "Thêm khoản thu";
            txbNoiDung.Focus();
        }

        public Thu(khoan_thu o)
        {
            InitializeComponent();
            type = TYPE.EDIT;
            LoadDefault();
            this.o = (khoan_thu)o;
            lblTitle.Content = "Sửa khoản thu";
            txbNoiDung.Text = o.noi_dung_thu;
            txbSoTien.Text = o.so_tien.ToString();
            cmbNguoiThu.SelectedValue = o.id_nguoi_thu;
            if (o.id_nguoi_nop_tien == null)
            {
                ckbDongGop.IsChecked = true;
                txbTen.Text = o.dong_gop.ten;
                txbSDT.Text = o.dong_gop.sdt;
                txbEmail.Text = o.dong_gop.email;
            }
            else
            {
                cmbNguoiNop.SelectedValue = o.id_nguoi_nop_tien;
            }

            ckbDongGop.IsEnabled = false;
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
                dong_gop dg;
                

                khoan_thu newo = new khoan_thu();
                newo.noi_dung_thu = txbNoiDung.Text;
                newo.so_tien = Convert.ToDecimal(txbSoTien.Text);
                newo.id_nguoi_thu = Convert.ToInt32(cmbNguoiThu.SelectedValue);

                if (ckbDongGop.IsChecked == true)
                {
                    dg = new dong_gop()
                    {
                        ten = txbTen.Text,
                        sdt = txbSDT.Text,
                        email = txbEmail.Text
                    };
                    dongGopDAO.Add(dg);

                    newo.id = dg.id;
                }
                else
                {
                    newo.id_nguoi_nop_tien = Convert.ToInt32(cmbNguoiNop.SelectedValue);
                }


                if (khoanThuDAO.Add(newo))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbNoiDung.Clear();
                    txbSoTien.Clear();
                    txbTen.Clear();
                    txbSDT.Clear();
                    txbEmail.Clear();

                }
                txbNoiDung.Focus();
            }
            else if (type == TYPE.EDIT)
            {
                if (ckbDongGop.IsChecked == true)
                {
                    dong_gop dg = new dong_gop()
                    {
                        id = Convert.ToInt32(o.id),
                        ten = txbTen.Text,
                        sdt = txbSDT.Text,
                        email = txbEmail.Text
                    };
                    dongGopDAO.Update(dg);
                    
                }
                else
                {
                    o.id_nguoi_nop_tien = Convert.ToInt32(cmbNguoiNop.SelectedValue);
                }
                o.noi_dung_thu = txbNoiDung.Text;
                o.so_tien = Convert.ToDecimal(txbSoTien.Text);
                o.id_nguoi_thu = Convert.ToInt32(cmbNguoiThu.SelectedValue);

                if (khoanThuDAO.Update(o))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                txbNoiDung.Focus();
            }
        }

        private void ckbDongGop_Checked(object sender, RoutedEventArgs e)
        {
            cmbNguoiNop.IsEnabled = false;
            txbTen.IsEnabled = true;
            txbSDT.IsEnabled = true;
            txbEmail.IsEnabled = true;
        }

        private void ckbDongGop_Unchecked(object sender, RoutedEventArgs e)
        {
            cmbNguoiNop.IsEnabled = true;
            txbTen.IsEnabled = false;
            txbSDT.IsEnabled = false;
            txbEmail.IsEnabled = false;
        }
    }
}
