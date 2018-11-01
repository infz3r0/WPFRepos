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

namespace QuanLyHoiNguoiCaoTuoi.UI.Hop
{
    /// <summary>
    /// Interaction logic for UC_Datagrid_HopTN.xaml
    /// </summary>
    public partial class UC_Datagrid_HopTN : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource hop_thuong_nienViewSource;

        public UC_Datagrid_HopTN()
        {
            InitializeComponent();
            hop_thuong_nienViewSource = ((CollectionViewSource)(FindResource("hop_thuong_nienViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            hop_thuong_nienViewSource.View.Refresh();
        }

        private void LoadData()
        {
            hop_thuong_nienViewSource.Source = null;

            try
            {
                hop_thuong_nienViewSource.Source = context.hop_thuong_nien.ToList();
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


        public void DeleteSelectedRows()
        {
            int countCol = hop_thuong_nienDataGrid.Columns.Count;
            int countSelected = hop_thuong_nienDataGrid.SelectedCells.Count / countCol;

            if (countSelected > 0)
            {
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelected);
                MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int c_success = 0;
                    int c_fail = 0;

                    List<hop_thuong_nien> hop_thuong_nienL = new List<hop_thuong_nien>();
                    for (int r = 0; r < countSelected; r++)
                    {
                        hop_thuong_nien o = (hop_thuong_nien)hop_thuong_nienDataGrid.SelectedCells[r * countCol].Item;
                        hop_thuong_nienL.Add(o);
                    }
                    foreach (hop_thuong_nien o in hop_thuong_nienL)
                    {
                        using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
                        {
                            try
                            {
                                db.hop_thuong_nien.Remove(o);
                                db.SaveChanges();
                                Refresh();
                                c_success++;
                            }
                            catch (Exception ex)
                            {
                                c_fail++;
                                CustomException.SQLException(ex);
                            } 
                        }
                    }
                    string result = string.Format("Đã xóa: {0}\nLỗi: {1}", c_success, c_fail);
                    MessageBox.Show(result, "Kết quả", System.Windows.MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }


        }


        public void OpenUpdateWindow()
        {
            if (hop_thuong_nienDataGrid.SelectedItems.Count > 0)
            {
                hop_thuong_nien o = (hop_thuong_nien)hop_thuong_nienDataGrid.SelectedItem;
                HopThuongNien w = new HopThuongNien(o);
                w.ShowDialog();
                Refresh(); 
            }
        }

        //end class
    }
}
