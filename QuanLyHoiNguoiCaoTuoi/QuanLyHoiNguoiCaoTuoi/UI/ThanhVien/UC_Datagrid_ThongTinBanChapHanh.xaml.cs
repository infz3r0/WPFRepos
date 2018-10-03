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
    /// Interaction logic for UC_Datagrid_ThongTinBanChapHanh.xaml
    /// </summary>
    public partial class UC_Datagrid_ThongTinBanChapHanh : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource thong_tin_ban_chap_hanhViewSource;

        public UC_Datagrid_ThongTinBanChapHanh()
        {
            InitializeComponent();
            thong_tin_ban_chap_hanhViewSource = ((CollectionViewSource)(FindResource("thong_tin_ban_chap_hanhViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            thong_tin_ban_chap_hanhViewSource.View.Refresh();
        }

        private void LoadData()
        {
            thong_tin_ban_chap_hanhViewSource.Source = null;

            try
            {
                thong_tin_ban_chap_hanhViewSource.Source = context.thong_tin_ban_chap_hanh.Include("thanh_vien").ToList();
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
            int countCol = thong_tin_ban_chap_hanhDataGrid.Columns.Count;
            int countSelected = thong_tin_ban_chap_hanhDataGrid.SelectedCells.Count / countCol;

            if (countSelected > 0)
            {
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelected);
                MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int c_success = 0;
                    int c_fail = 0;

                    List<thong_tin_ban_chap_hanh> thong_tin_ban_chap_hanhL = new List<thong_tin_ban_chap_hanh>();
                    for (int r = 0; r < countSelected; r++)
                    {
                        thong_tin_ban_chap_hanh o = (thong_tin_ban_chap_hanh)thong_tin_ban_chap_hanhDataGrid.SelectedCells[r * countCol].Item;
                        thong_tin_ban_chap_hanhL.Add(o);
                    }
                    foreach (thong_tin_ban_chap_hanh o in thong_tin_ban_chap_hanhL)
                    {
                        using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
                        {
                            try
                            {
                                db.thong_tin_ban_chap_hanh.Remove(o);
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
            thong_tin_ban_chap_hanh o = (thong_tin_ban_chap_hanh)thong_tin_ban_chap_hanhDataGrid.SelectedItem;
            ThongTinBanChapHanh w = new ThongTinBanChapHanh(o);
            w.ShowDialog();
            Refresh();
        }

        //end class
    }
}
