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
    /// Interaction logic for UC_Datagrid_HopBCH.xaml
    /// </summary>
    public partial class UC_Datagrid_HopBCH : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource hop_bchViewSource;

        public UC_Datagrid_HopBCH()
        {
            InitializeComponent();
            hop_bchViewSource = ((CollectionViewSource)(FindResource("hop_bchViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            hop_bchViewSource.View.Refresh();
        }

        private void LoadData()
        {
            hop_bchViewSource.Source = null;

            try
            {
                hop_bchViewSource.Source = context.hop_bch.ToList();
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
            int countCol = hop_bchDataGrid.Columns.Count;
            int countSelected = hop_bchDataGrid.SelectedCells.Count / countCol;

            if (countSelected > 0)
            {
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelected);
                MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int c_success = 0;
                    int c_fail = 0;

                    List<hop_bch> hop_bchL = new List<hop_bch>();
                    for (int r = 0; r < countSelected; r++)
                    {
                        hop_bch o = (hop_bch)hop_bchDataGrid.SelectedCells[r * countCol].Item;
                        hop_bchL.Add(o);
                    }
                    foreach (hop_bch o in hop_bchL)
                    {
                        try
                        {
                            context.P_Delete_hop_bch(o.thang, o.nam);
                            Refresh();
                            c_success++;
                        }
                        catch (Exception ex)
                        {
                            c_fail++;
                            CustomException.SQLException(ex);
                        }
                    }
                    string result = string.Format("Đã xóa: {0}\nLỗi: {1}", c_success, c_fail);
                    MessageBox.Show(result, "Kết quả", System.Windows.MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }


        }


        public void OpenUpdateWindow()
        {
            hop_bch o = (hop_bch)hop_bchDataGrid.SelectedItem;
            HopBCH w = new HopBCH(o);
            w.ShowDialog();
            Refresh();
        }

        //end class
    }
}
