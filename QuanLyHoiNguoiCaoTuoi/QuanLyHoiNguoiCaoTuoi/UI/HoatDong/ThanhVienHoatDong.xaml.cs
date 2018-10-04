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

namespace QuanLyHoiNguoiCaoTuoi.UI.HoatDong
{
    /// <summary>
    /// Interaction logic for ThanhVienHoatDong.xaml
    /// </summary>
    public partial class ThanhVienHoatDong : Window
    {
        private HoatDongDAO hoatDongDAO = new HoatDongDAO();
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private ThanhVienHoatDongDAO thanhVienhoat_dongDAO = new ThanhVienHoatDongDAO();
        private TYPE type;
        private thanh_vien o;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        private void LoadDefaultData()
        {
            //Hoat dong
            List<hoat_dong> hoat_Dongs = hoatDongDAO.GetList();

            if (hoat_Dongs.Count <= 0)
            {
                MessageBox.Show("Không có hoạt động.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                btnAdd.IsEnabled = false;
                btnRemove.IsEnabled = false;
                return;
            }

            cmbHoatDong.DisplayMemberPath = "tieu_de";
            cmbHoatDong.SelectedValuePath = "id_hoat_dong";

            cmbHoatDong.ItemsSource = hoat_Dongs;
            cmbHoatDong.SelectedIndex = 0;

        }

        public ThanhVienHoatDong()
        {
            InitializeComponent();
            LoadDefaultData();
            type = TYPE.ADD;
            lblTitle.Content = "Danh sách thành viên tham gia hoạt động";
            cmbHoatDong.Focus();
        }

        public void LoadDatagrid()
        {
            int id_hoat_dong = Convert.ToInt32(cmbHoatDong.SelectedValue);
            //Load thanh_vien_hoat_dong
            thanh_vien_tham_giaDataGrid.ItemsSource = thanhVienhoat_dongDAO.GetList(id_hoat_dong);

            //Load thanh vien
            thanh_vienDataGrid.ItemsSource = thanhVienDAO.GetListNotInHoatDong(id_hoat_dong);
        }

        private void cmbHoatDong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDatagrid();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (thanh_vienDataGrid.SelectedItems.Count <= 0)
            {
                return;
            }

            int id_hoat_dong = Convert.ToInt32(cmbHoatDong.SelectedValue);
            List<thanh_vien> selected_tv = new List<thanh_vien>(thanh_vienDataGrid.SelectedItems.Cast<thanh_vien>());
            foreach (thanh_vien o in selected_tv)
            {
                thanh_vien_tham_gia newo = new thanh_vien_tham_gia()
                {
                    id_hoat_dong = id_hoat_dong,
                    id_thanh_vien = o.id_thanh_vien,
                    nhiem_vu = ""
                };

                thanhVienhoat_dongDAO.Add(newo);
            }

            LoadDatagrid();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (thanh_vien_tham_giaDataGrid.SelectedItems.Count <= 0)
            {
                return;
            }

            int id_hoat_dong = Convert.ToInt32(cmbHoatDong.SelectedValue);
            List<thanh_vien_tham_gia> selected_tv = new List<thanh_vien_tham_gia>(thanh_vien_tham_giaDataGrid.SelectedItems.Cast<thanh_vien_tham_gia>());
            foreach (thanh_vien_tham_gia o in selected_tv)
            {
                thanhVienhoat_dongDAO.Remove(id_hoat_dong, o.id_thanh_vien);
            }

            LoadDatagrid();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource thanh_vien_tham_giaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("thanh_vien_tham_giaViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // thanh_vien_tham_giaViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource thanh_vienViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("thanh_vienViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // thanh_vienViewSource.Source = [generic data source]
        }

        private void thanh_vien_tham_giaDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (thanh_vien_tham_giaDataGrid.SelectedItems.Count > 0)
            {
                using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
                {
                    thanh_vien_tham_gia temp = (thanh_vien_tham_gia)thanh_vien_tham_giaDataGrid.SelectedItem;
                    thanh_vien_tham_gia o = db.thanh_vien_tham_gia.FirstOrDefault(x => x.id_hoat_dong == temp.id_hoat_dong && x.id_thanh_vien == temp.id_thanh_vien);
                    HoatDongUpdate w = new HoatDongUpdate(o);
                    w.ShowDialog();
                    LoadDatagrid();
                }
            }
            
        }

        //end class
    }
}
