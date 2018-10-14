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

namespace QuanLyHoiNguoiCaoTuoi.UI.TimKiemThogKe
{
    /// <summary>
    /// Interaction logic for TimKiem.xaml
    /// </summary>
    public partial class TimKiem : Window
    {
        private hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource thanh_vienViewSource;
        CollectionViewSource cLBViewSource;
        CollectionViewSource hoat_dongViewSource;


        public TimKiem()
        {
            InitializeComponent();
            lblTitle.Content = "Tìm kiếm";

            thanh_vienViewSource = ((CollectionViewSource)(FindResource("thanh_vienViewSource")));
            cLBViewSource = ((CollectionViewSource)(FindResource("cLBViewSource")));
            hoat_dongViewSource = ((CollectionViewSource)(FindResource("hoat_dongViewSource")));
            DataContext = this;

            LoadDefault();

            txbSearch.Focus();
        }

        public void LoadDefault()
        {
            //Search type
            List<ComboBoxPairs> comboBoxPairs = new List<ComboBoxPairs>();
            comboBoxPairs.Add(new ComboBoxPairs("0", "Thành viên"));
            comboBoxPairs.Add(new ComboBoxPairs("1", "CLB"));
            comboBoxPairs.Add(new ComboBoxPairs("2", "Hoạt động"));

            cmbSearchType.DisplayMemberPath = "_Value";
            cmbSearchType.SelectedValuePath = "_Key";
            cmbSearchType.ItemsSource = comboBoxPairs;
            cmbSearchType.SelectedIndex = 0;


        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string input = txbSearch.Text;
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
            }
            else
            {

                switch (cmbSearchType.SelectedValue)
                {
                    case "0":
                        thanh_vienViewSource.Source = null;

                        try
                        {
                            thanh_vienViewSource.Source = db.thanh_vien.Include("khu_pho").Where(x => x.ho_ten.Contains(input)).ToList();
                        }
                        catch (Exception ex)
                        {
                            CustomException.SQLException(ex);
                        }
                        thanh_vienDataGrid.Visibility = Visibility.Visible;
                        cLBDataGrid.Visibility = Visibility.Hidden;
                        hoat_dongDataGrid.Visibility = Visibility.Hidden;

                        break;
                    case "1":
                        cLBViewSource.Source = null;

                        try
                        {
                            cLBViewSource.Source = db.CLBs.Where(x => x.ten_clb.Contains(input)).ToList();
                        }
                        catch (Exception ex)
                        {
                            CustomException.SQLException(ex);
                        }


                        thanh_vienDataGrid.Visibility = Visibility.Hidden;
                        cLBDataGrid.Visibility = Visibility.Visible;
                        hoat_dongDataGrid.Visibility = Visibility.Hidden;
                        break;
                    case "2":
                        hoat_dongViewSource.Source = null;

                        try
                        {
                            hoat_dongViewSource.Source = db.hoat_dong.Where(x => x.tieu_de.Contains(input) || x.noi_dung.Contains(input)).ToList();
                        }
                        catch (Exception ex)
                        {
                            CustomException.SQLException(ex);
                        }


                        thanh_vienDataGrid.Visibility = Visibility.Hidden;
                        cLBDataGrid.Visibility = Visibility.Hidden;
                        hoat_dongDataGrid.Visibility = Visibility.Visible;
                        break;
                        break;
                }

            
                
            }
            
        }




        //end class
    }
}
