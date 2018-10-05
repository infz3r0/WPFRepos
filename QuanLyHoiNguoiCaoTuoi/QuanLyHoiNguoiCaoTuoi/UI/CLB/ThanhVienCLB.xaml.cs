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
    /// Interaction logic for ThanhVienCLB.xaml
    /// </summary>
    public partial class ThanhVienCLB : Window
    {
        private CLBDAO cLBDAO = new CLBDAO();
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private ThanhVienCLBDAO thanhVienCLBDAO = new ThanhVienCLBDAO();
        private TYPE type;


        public enum TYPE
        {
            ADD,
            EDIT
        }

        private void LoadDefaultData()
        {
            //CLB
            List<DATA.CLB> clbL = cLBDAO.GetList();

            if (clbL.Count <= 0)
            {
                MessageBox.Show("Không có CLB.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                btnOK.IsEnabled = false;
                return;
            }

            cmbCLB.DisplayMemberPath = "ten_clb";
            cmbCLB.SelectedValuePath = "id_clb";

            cmbCLB.ItemsSource = clbL;
            cmbCLB.SelectedIndex = 0;
            
        }

        public ThanhVienCLB()
        {
            InitializeComponent();
            LoadDefaultData();
            type = TYPE.ADD;
            lblTitle.Content = "Danh sách thành viên CLB";
            cmbCLB.Focus();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (type == TYPE.ADD)
            {

                //if (thanhVienDAO.Add())
                //{
                //    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //}
            }

        }

        public void LoadDatagrid()
        {
            int id_clb = Convert.ToInt32(cmbCLB.SelectedValue);
            //Load thanh_vien_clb
            thanh_vien_clbDataGrid.ItemsSource = thanhVienCLBDAO.GetList(id_clb);

            //Load thanh vien
            thanh_vienDataGrid.ItemsSource = thanhVienDAO.GetListNotInCLB(id_clb);
        }

        private void cmbCLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDatagrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource thanh_vien_clbViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("thanh_vien_clbViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // thanh_vien_clbViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource thanh_vienViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("thanh_vienViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // thanh_vienViewSource.Source = [generic data source]
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (thanh_vienDataGrid.SelectedItems.Count <= 0)
            {
                return;
            }

            int id_clb = Convert.ToInt32(cmbCLB.SelectedValue);
            List<thanh_vien> selected_tv = new List<thanh_vien>(thanh_vienDataGrid.SelectedItems.Cast<thanh_vien>());
            foreach (thanh_vien o in selected_tv)
            {
                thanh_vien_clb newo = new thanh_vien_clb()
                {
                    id_clb = id_clb,
                    id_thanh_vien = o.id_thanh_vien,
                    ngay_tham_gia = DateTime.Now,
                    la_quan_ly = false
                };

                thanhVienCLBDAO.Add(newo);
            }

            LoadDatagrid();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (thanh_vien_clbDataGrid.SelectedItems.Count <= 0)
            {
                return;
            }

            int id_clb = Convert.ToInt32(cmbCLB.SelectedValue);
            List<thanh_vien_clb> selected_tv = new List<thanh_vien_clb>(thanh_vien_clbDataGrid.SelectedItems.Cast<thanh_vien_clb>());
            foreach (thanh_vien_clb o in selected_tv)
            {
                thanhVienCLBDAO.Remove(id_clb, o.id_thanh_vien);
            }

            LoadDatagrid();
        }

        //end class
    }
}
