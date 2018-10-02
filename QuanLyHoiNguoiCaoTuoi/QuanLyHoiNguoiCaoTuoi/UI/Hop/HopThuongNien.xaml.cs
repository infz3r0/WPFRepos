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

namespace QuanLyHoiNguoiCaoTuoi.UI.Hop
{
    /// <summary>
    /// Interaction logic for HopThuongNien.xaml
    /// </summary>
    public partial class HopThuongNien : Window
    {
        private HopTNDAO hopTNDAO = new HopTNDAO();
        private TYPE type;
        private hop_thuong_nien o;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        private void LoadDefaultData()
        {
            //Lan
            List<int> lanhop = new List<int>();

            for (int i = 1; i <= 2; i++)
            {
                lanhop.Add(i);
            }

            cmbLanHop.ItemsSource = lanhop;
            cmbLanHop.SelectedIndex = 0;

            //Nam
            List<int> years = new List<int>();

            for (int i = 1800; i <= 2200; i++)
            {
                years.Add(i);
            }

            cmbNam.ItemsSource = years;
            cmbNam.SelectedIndex = 0;
        }

        public HopThuongNien()
        {
            InitializeComponent();
            type = TYPE.ADD;
            LoadDefaultData();
            lblTitle.Content = "Thêm cuộc họp";
            cmbNam.Focus();
        }

        public HopThuongNien(hop_thuong_nien o)
        {
            InitializeComponent();
            type = TYPE.EDIT;
            LoadDefaultData();
            this.o = (hop_thuong_nien)o;
            lblTitle.Content = "Sửa cuộc họp";
            cmbLanHop.SelectedItem = o.lan_hop;
            cmbNam.SelectedItem = o.nam;
            txbNoiDung.Text = o.noi_dung;
            txbNoiDung.Focus();

            cmbLanHop.IsEnabled = false;
            cmbNam.IsEnabled = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            if (type == TYPE.ADD)
            {
                hop_thuong_nien newo = new hop_thuong_nien();
                newo.lan_hop = Convert.ToInt32(cmbLanHop.SelectedItem);
                newo.nam = Convert.ToInt32(cmbNam.SelectedItem);
                newo.noi_dung = txbNoiDung.Text;

                if (hopTNDAO.Add(newo))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbNoiDung.Clear();
                }
                cmbNam.Focus();
            }
            else if (type == TYPE.EDIT)
            {
                o.lan_hop = Convert.ToInt32(cmbLanHop.SelectedItem);
                o.nam = Convert.ToInt32(cmbNam.SelectedItem);
                o.noi_dung = txbNoiDung.Text;
                if (hopTNDAO.Update(o))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                txbNoiDung.Focus();
            }
        }

        //end class
    }
}
