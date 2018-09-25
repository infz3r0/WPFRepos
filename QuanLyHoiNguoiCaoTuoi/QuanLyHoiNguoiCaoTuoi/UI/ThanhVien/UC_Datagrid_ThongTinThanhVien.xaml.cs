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

namespace QuanLyHoiNguoiCaoTuoi.UI.ThanhVien
{
    /// <summary>
    /// Interaction logic for UC_Datagrid_ThongTinThanhVien.xaml
    /// </summary>
    public partial class UC_Datagrid_ThongTinThanhVien : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource thanh_vienViewSource;

        public UC_Datagrid_ThongTinThanhVien()
        {
            InitializeComponent();
            thanh_vienViewSource = ((CollectionViewSource)(FindResource("thanh_vienViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            thanh_vienViewSource.View.Refresh();
        }

        private void LoadData()
        {
            thanh_vienViewSource.Source = null;

            try
            {
                context.thanh_vien.Include("khu_pho").Load();
            }
            catch (Exception ex)
            {
                CustomException.SQLException(ex);
            }

            thanh_vienViewSource.Source = context.thanh_vien.Local;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        
        public void DeleteSelectedRows()
        {
            int countColumns = thanh_vienDataGrid.Columns.Count;
            int countSelectedRows = thanh_vienDataGrid.SelectedCells.Count / countColumns;

            if (countSelectedRows > 0)
            {
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelectedRows);
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(msg, "Xác nhận xóa", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    for (int r = 0; r < countSelectedRows; r++)
                    {
                        thanh_vien o = (thanh_vien)thanh_vienDataGrid.Items[r];
                        try
                        {
                            context.thanh_vien.Remove(o);
                            context.SaveChanges();
                            Refresh();
                        }
                        catch (Exception ex)
                        {
                            CustomException.UnknownException(ex);
                        }
                    }
                }
            }


        }


        public void OpenUpdateWindow()
        {
            thanh_vien o = (thanh_vien)thanh_vienDataGrid.SelectedItem;
            ThongTinThanhVien w = new ThongTinThanhVien(o);
            w.ShowDialog();
            Refresh();
        }

        //end class
    }
}
