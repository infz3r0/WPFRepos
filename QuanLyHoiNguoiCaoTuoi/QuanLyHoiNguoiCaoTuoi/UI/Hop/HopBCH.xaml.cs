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
    /// Interaction logic for HopBCH.xaml
    /// </summary>
    public partial class HopBCH : Window
    {
        private HopBCHDAO hopBCHDAO = new HopBCHDAO();
        private TYPE type;
        private hop_bch o;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        private void LoadDefaultData()
        {
            //Thang
            List<int> months = new List<int>();

            for (int i=1; i <=12; i++)
            {
                months.Add(i);
            }

            cmbThang.ItemsSource = months;
            cmbThang.SelectedIndex = 0;

            //Nam
            List<int> years = new List<int>();

            for (int i = 1800; i <= 2200; i++)
            {
                years.Add(i);
            }

            cmbNam.ItemsSource = years;
            cmbNam.SelectedIndex = 0;
        }

        public HopBCH()
        {
            InitializeComponent();
            type = TYPE.ADD;
            LoadDefaultData();
            lblTitle.Content = "Thêm cuộc họp";
            cmbThang.Focus();
        }

        public HopBCH(hop_bch o)
        {
            InitializeComponent();
            type = TYPE.EDIT;
            LoadDefaultData();
            this.o = (hop_bch)o;
            lblTitle.Content = "Sửa cuộc họp";
            cmbThang.SelectedItem = o.thang;
            cmbNam.SelectedItem = o.nam;
            txbNoiDung.Text = o.noi_dung;
            txbNoiDung.Focus();

            cmbThang.IsEnabled = false;
            cmbNam.IsEnabled = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            if (type == TYPE.ADD)
            {
                hop_bch newo = new hop_bch();
                newo.thang = Convert.ToInt32(cmbThang.SelectedItem);
                newo.nam = Convert.ToInt32(cmbNam.SelectedItem);
                newo.noi_dung = txbNoiDung.Text;

                if (hopBCHDAO.Add(newo))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbNoiDung.Clear();
                }
                cmbThang.Focus();
            }
            else if (type == TYPE.EDIT)
            {
                o.thang = Convert.ToInt32(cmbThang.SelectedItem);
                o.nam = Convert.ToInt32(cmbNam.SelectedItem);
                o.noi_dung = txbNoiDung.Text;
                if (hopBCHDAO.Update(o))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                txbNoiDung.Focus();
            }
        }

        //end class
    }
}
