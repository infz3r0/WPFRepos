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
    /// Interaction logic for ThanhVienHop.xaml
    /// </summary>
    public partial class ThanhVienHop : Window
    {
        private HopTNDAO hopTNDAO = new HopTNDAO();
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private ThanhVienHopDAO thanhVienHopDAO = new ThanhVienHopDAO();
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
            List<int> years = hopTNDAO.GetYears();

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
            //Load lan hop
            int y = Convert.ToInt32(cmbNam.SelectedItem);
            List<int> lan = hopTNDAO.GetLanHopsByYear(y);

            if (lan.Count <= 0)
            {
                MessageBox.Show("Không có cuộc họp.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            loaded = false;

            cmbLanHop.ItemsSource = lan;
            cmbLanHop.SelectedIndex = 0;

            if (loaded)
            {
                loaded = false;
                return;
            }
            LoadDatagrid();
        }

        private void cmbLanHop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDatagrid();
        }

        public ThanhVienHop()
        {
            InitializeComponent();
            LoadDefaultData();
            type = TYPE.ADD;
            lblTitle.Content = "Danh sách thành viên tham gia họp";
        }

        public void LoadDatagrid()
        {
        

            int y = Convert.ToInt32(cmbNam.SelectedValue);
            int l = Convert.ToInt32(cmbLanHop.SelectedValue);
            //Load tv hop
            thanh_vien_tham_gia_hopDataGrid.ItemsSource = thanhVienHopDAO.GetListByLanHopYear(l, y);

            //Load tv
            thanh_vienDataGrid.ItemsSource = thanhVienDAO.GetListNotInHopTN(l, y);

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (thanh_vienDataGrid.SelectedItems.Count <= 0)
            {
                return;
            }

            int y = Convert.ToInt32(cmbNam.SelectedValue);
            int l = Convert.ToInt32(cmbLanHop.SelectedValue);

            List<thanh_vien> selected_tv = new List<thanh_vien>(thanh_vienDataGrid.SelectedItems.Cast<thanh_vien>());
            foreach (thanh_vien o in selected_tv)
            {
                thanh_vien_tham_gia_hop newo = new thanh_vien_tham_gia_hop()
                {
                    lan_hop = l,
                    nam = y,
                    id_thanh_vien = o.id_thanh_vien
                };

                thanhVienHopDAO.Add(newo);
            }

            LoadDatagrid();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (thanh_vien_tham_gia_hopDataGrid.SelectedItems.Count <= 0)
            {
                return;
            }

            int y = Convert.ToInt32(cmbNam.SelectedValue);
            int l = Convert.ToInt32(cmbLanHop.SelectedValue);

            List<thanh_vien_tham_gia_hop> selected_tv = new List<thanh_vien_tham_gia_hop>(thanh_vien_tham_gia_hopDataGrid.SelectedItems.Cast<thanh_vien_tham_gia_hop>());
            foreach (thanh_vien_tham_gia_hop o in selected_tv)
            {
                thanhVienHopDAO.Remove(l, y, o.id_thanh_vien);
            }

            LoadDatagrid();
        }

        //end class

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource thanh_vien_tham_gia_hopViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("thanh_vien_tham_gia_hopViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // thanh_vien_tham_gia_hopViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource thanh_vienViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("thanh_vienViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // thanh_vienViewSource.Source = [generic data source]
        }
    }
}
