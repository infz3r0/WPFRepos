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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.Entity;
using QuanLyHoiNguoiCaoTuoi.DATA;

namespace QuanLyHoiNguoiCaoTuoi.UI.HoatDong
{
    /// <summary>
    /// Interaction logic for UC_Datagrid_ThanhVienHoatDong.xaml
    /// </summary>
    public partial class UC_Datagrid_ThanhVienHoatDong : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource thanh_vien_tham_giaViewSource;

        public UC_Datagrid_ThanhVienHoatDong()
        {
            InitializeComponent();
            thanh_vien_tham_giaViewSource = ((CollectionViewSource)(FindResource("thanh_vien_tham_giaViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            thanh_vien_tham_giaViewSource.View.Refresh();
        }

        private void LoadData()
        {
            thanh_vien_tham_giaViewSource.Source = null;

            try
            {
                thanh_vien_tham_giaViewSource.Source = context.thanh_vien_tham_gia.ToList();
            }
            catch (Exception ex)
            {
                CustomException.SQLException(ex);
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        

        //end class
    }
}
