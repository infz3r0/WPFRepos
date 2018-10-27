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
                thanh_vienViewSource.Source = context.thanh_vien.Include("khu_pho").ToList();
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
            int countCol = thanh_vienDataGrid.Columns.Count;
            int countSelected = thanh_vienDataGrid.SelectedCells.Count / countCol;

            if (countSelected > 0)
            {
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelected);
                MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int c_success = 0;
                    int c_fail = 0;

                    List<thanh_vien> thanh_vienL = new List<thanh_vien>();
                    for (int r = 0; r < countSelected; r++)
                    {
                        thanh_vien o = (thanh_vien)thanh_vienDataGrid.SelectedCells[r * countCol].Item;
                        thanh_vienL.Add(o);
                    }
                    foreach (thanh_vien t in thanh_vienL)
                    {
                        using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
                        {
                            try
                            {
                                thanh_vien o = db.thanh_vien.FirstOrDefault(x => x.id_thanh_vien == t.id_thanh_vien);
                                db.thanh_vien.Remove(o);
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
            thanh_vien o = (thanh_vien)thanh_vienDataGrid.SelectedItem;
            ThongTinThanhVien w = new ThongTinThanhVien(o);
            w.ShowDialog();
            Refresh();
        }

        //end class
    }
}
