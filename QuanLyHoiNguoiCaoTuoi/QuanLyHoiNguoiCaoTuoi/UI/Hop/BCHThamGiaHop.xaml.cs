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
    /// Interaction logic for BCHThamGiaHop.xaml
    /// </summary>
    public partial class BCHThamGiaHop : Window
    {
        private HopBCHDAO hopBCHDAO = new HopBCHDAO();
        private BanChapHanhDAO banChapHanhDAO = new BanChapHanhDAO();
        private BCHThamGiaHopDAO bchThamGiaHopDAO = new BCHThamGiaHopDAO();
        private TYPE type;
        private bool loaded;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        private void LoadDefaultData()
        {
            //Nam
            List<int> years = hopBCHDAO.GetYears();

            if (years.Count <= 0)
            {
                MessageBox.Show("Không có cuộc họp.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            cmbNam.ItemsSource = years;
            cmbNam.SelectedIndex = 0;
        }

        private void cmbNam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Load Thang
            int y = Convert.ToInt32(cmbNam.SelectedItem);
            List<int> months = hopBCHDAO.GetMonthsByYear(y);

            if (months.Count <= 0)
            {
                MessageBox.Show("Không có cuộc họp.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            loaded = false;

            cmbThang.ItemsSource = months;
            cmbThang.SelectedIndex = 0;

            if (loaded)
            {
                loaded = false;
                return;
            }
            LoadDatagrid();
        }

        private void cmbThang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDatagrid();
        }

        public BCHThamGiaHop()
        {
            InitializeComponent();
            LoadDefaultData();
            type = TYPE.ADD;
            lblTitle.Content = "Danh sách BCH tham gia họp";
        }

        public void LoadDatagrid()
        {
            

            int y = Convert.ToInt32(cmbNam.SelectedValue);
            int m = Convert.ToInt32(cmbThang.SelectedValue);
            //Load bch hop
            hop_bchDataGrid.ItemsSource = bchThamGiaHopDAO.GetListByMonthYear(m, y);

            //Load bch
            thong_tin_ban_chap_hanhDataGrid.ItemsSource = banChapHanhDAO.GetListNotInHopBCH(m, y);
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (thong_tin_ban_chap_hanhDataGrid.SelectedItems.Count <= 0)
            {
                return;
            }

            int y = Convert.ToInt32(cmbNam.SelectedValue);
            int m = Convert.ToInt32(cmbThang.SelectedValue);

            List<thong_tin_ban_chap_hanh> selected_tv = new List<thong_tin_ban_chap_hanh>(thong_tin_ban_chap_hanhDataGrid.SelectedItems.Cast<thong_tin_ban_chap_hanh>());
            foreach (thong_tin_ban_chap_hanh o in selected_tv)
            {
                bch_tham_gia_hop newo = new bch_tham_gia_hop()
                {
                    thang = m,
                    nam = y,
                    id_thanh_vien = o.id_thanh_vien
                };

                bchThamGiaHopDAO.Add(newo);
            }

            LoadDatagrid();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (hop_bchDataGrid.SelectedItems.Count <= 0)
            {
                return;
            }

            int y = Convert.ToInt32(cmbNam.SelectedValue);
            int m = Convert.ToInt32(cmbThang.SelectedValue);

            List<thong_tin_ban_chap_hanh> selected_tv = new List<thong_tin_ban_chap_hanh>(thong_tin_ban_chap_hanhDataGrid.SelectedItems.Cast<thong_tin_ban_chap_hanh>());
            foreach (thong_tin_ban_chap_hanh o in selected_tv)
            {
                bchThamGiaHopDAO.Remove(m, y, o.id_thanh_vien);
            }

            LoadDatagrid();
        }

        //end class

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hop_bchViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hop_bchViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hop_bchViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource thong_tin_ban_chap_hanhViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("thong_tin_ban_chap_hanhViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // thong_tin_ban_chap_hanhViewSource.Source = [generic data source]
        }

        
    }
}
