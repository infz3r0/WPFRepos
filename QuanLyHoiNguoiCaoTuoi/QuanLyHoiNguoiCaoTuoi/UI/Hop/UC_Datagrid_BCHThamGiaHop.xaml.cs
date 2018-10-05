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

using QuanLyHoiNguoiCaoTuoi.DATA;

namespace QuanLyHoiNguoiCaoTuoi.UI.Hop
{
    /// <summary>
    /// Interaction logic for UC_Datagrid_BCHThamGiaHop.xaml
    /// </summary>
    public partial class UC_Datagrid_BCHThamGiaHop : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource bch_tham_gia_hopViewSource;

        public UC_Datagrid_BCHThamGiaHop()
        {
            InitializeComponent();
            bch_tham_gia_hopViewSource = ((CollectionViewSource)(FindResource("bch_tham_gia_hopViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            bch_tham_gia_hopViewSource.View.Refresh();
        }

        private void LoadData()
        {
            bch_tham_gia_hopViewSource.Source = null;

            try
            {
                bch_tham_gia_hopViewSource.Source = context.bch_tham_gia_hop.Include("thanh_vien").ToList();
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
