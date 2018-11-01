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
    /// Interaction logic for UC_Datagrid_HoatDong.xaml
    /// </summary>
    public partial class UC_Datagrid_HoatDong : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource hoat_dongViewSource;

        public UC_Datagrid_HoatDong()
        {
            InitializeComponent();
            hoat_dongViewSource = ((CollectionViewSource)(FindResource("hoat_dongViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            hoat_dongViewSource.View.Refresh();
        }

        private void LoadData()
        {
            hoat_dongViewSource.Source = null;

            try
            {
                hoat_dongViewSource.Source = context.hoat_dong.ToList();
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
            int countCol = hoat_dongDataGrid.Columns.Count;
            int countSelected = hoat_dongDataGrid.SelectedCells.Count / countCol;

            if (countSelected > 0)
            {
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelected);
                MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int c_success = 0;
                    int c_fail = 0;

                    List<hoat_dong> hoat_dongL = new List<hoat_dong>();
                    for (int r = 0; r < countSelected; r++)
                    {
                        hoat_dong temp = (hoat_dong)hoat_dongDataGrid.SelectedCells[r * countCol].Item;
                        hoat_dong o = context.hoat_dong.FirstOrDefault(x => x.id_hoat_dong == temp.id_hoat_dong);
                        hoat_dongL.Add(o);
                    }
                    foreach (hoat_dong o in hoat_dongL)
                    {
                        using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
                        {
                            try
                            {
                                db.hoat_dong.Remove(o);
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
            if (hoat_dongDataGrid.SelectedItems.Count > 0)
            {
                hoat_dong o = (hoat_dong)hoat_dongDataGrid.SelectedItem;
                HoatDong w = new HoatDong(o);
                w.ShowDialog();
                Refresh(); 
            }
        }

        public void OpenDanhGiaWindow()
        {
            if (hoat_dongDataGrid.SelectedItems.Count > 0)
            {
                hoat_dong o = (hoat_dong)hoat_dongDataGrid.SelectedItem;
                DanhGiaHD w = new DanhGiaHD(o);
                w.ShowDialog();
                Refresh();
            }
        }

        //end class
    }
}
