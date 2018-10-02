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

namespace QuanLyHoiNguoiCaoTuoi.UI.CLB
{
    /// <summary>
    /// Interaction logic for CLB.xaml
    /// </summary>
    public partial class CLB : Window
    {
        private CLBDAO clbDAO = new CLBDAO();
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private ThanhVienCLBDAO thanhVienCLBDAO = new ThanhVienCLBDAO();
        private TYPE type;
        private DATA.CLB o;
        private thanh_vien_clb quanly;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        public void LoadDefaultData()
        {
            List<thanh_vien> thanh_Viens = thanhVienDAO.GetList();

            if (thanh_Viens.Count <= 0)
            {
                MessageBox.Show("Không có thành viên.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                btnOK.IsEnabled = false;
                return;
            }

            cmbQuanLy.ItemsSource = thanh_Viens;

            cmbQuanLy.DisplayMemberPath = "ho_ten";
            cmbQuanLy.SelectedValuePath = "id_thanh_vien";

            cmbQuanLy.SelectedIndex = 0;
        }

        public CLB()
        {
            InitializeComponent();
            type = TYPE.ADD;
            LoadDefaultData();
            lblTitle.Content = "Thêm câu lạc bộ";
            dtpNgayThanhLap.SelectedDate = DateTime.Now;
            txbTenCLB.Focus();
        }

        public CLB(DATA.CLB o)
        {
            InitializeComponent();
            type = TYPE.EDIT;
            LoadDefaultData();
            this.o = (DATA.CLB)o;
            lblTitle.Content = "Sửa câu lạc bộ";
            txbTenCLB.Text = o.ten_clb;
            dtpNgayThanhLap.SelectedDate = o.ngay_thanh_lap;
            quanly = clbDAO.GetQuanLy(o.id_clb);
            cmbQuanLy.SelectedValue = quanly.id_thanh_vien;
            txbTenCLB.Focus();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txbTenCLB.Text.Length > 50 || string.IsNullOrEmpty(txbTenCLB.Text) || string.IsNullOrWhiteSpace(txbTenCLB.Text))
            {
                MessageBox.Show("Tên CLB không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTenCLB.Focus();
                return;
            }
            if ((DateTime)dtpNgayThanhLap.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Ngày thành lập không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpNgayThanhLap.Focus();
                return;
            }



            if (type == TYPE.ADD)
            {
                DATA.CLB newo = new DATA.CLB();
                newo.ten_clb = txbTenCLB.Text;
                newo.ngay_thanh_lap = (DateTime)dtpNgayThanhLap.SelectedDate;                
                if (clbDAO.Add(newo))
                {
                    thanh_vien_clb thanh_Vien_Clb = new thanh_vien_clb()
                    {
                        id_clb = newo.id_clb,
                        id_thanh_vien = Convert.ToInt32(cmbQuanLy.SelectedValue),
                        ngay_tham_gia = DateTime.Now,
                        la_quan_ly = true
                    };
                    thanhVienCLBDAO.Add(thanh_Vien_Clb);

                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbTenCLB.Clear();
                }
                txbTenCLB.Focus();
            }
            else if (type == TYPE.EDIT)
            {
                o.ten_clb = txbTenCLB.Text;
                o.ngay_thanh_lap = (DateTime)dtpNgayThanhLap.SelectedDate;
                if (clbDAO.Update(o))
                {
                    thanhVienCLBDAO.ChangeQuanLy(o.id_clb, quanly.id_thanh_vien, Convert.ToInt32(cmbQuanLy.SelectedValue));
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                txbTenCLB.Focus();
            }
        }

        //end class
    }
}
