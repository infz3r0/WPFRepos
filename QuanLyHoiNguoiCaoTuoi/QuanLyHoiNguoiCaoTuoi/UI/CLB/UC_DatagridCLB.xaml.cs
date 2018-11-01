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

namespace QuanLyHoiNguoiCaoTuoi.UI.CLB
{
    /// <summary>
    /// Interaction logic for UC_DatagridCLB.xaml
    /// </summary>
    public partial class UC_DatagridCLB : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource cLBViewSource;

        public UC_DatagridCLB()
        {
            InitializeComponent();
            cLBViewSource = ((CollectionViewSource)(FindResource("cLBViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            cLBViewSource.View.Refresh();
        }

        private void LoadData()
        {
            cLBViewSource.Source = null;

            try
            {
                //.CLB.Load();
                cLBViewSource.Source = context.CLBs.ToList();
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
            int countCol = cLBDataGrid.Columns.Count;
            int countSelected = cLBDataGrid.SelectedCells.Count / countCol;

            if (countSelected > 0)
            {
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelected);
                MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int c_success = 0;
                    int c_fail = 0;

                    List<DATA.CLB> CLBL = new List<DATA.CLB>();
                    for (int r = 0; r < countSelected; r++)
                    {
                        DATA.CLB o = (DATA.CLB)cLBDataGrid.SelectedCells[r * countCol].Item;
                        CLBL.Add(o);
                    }
                    foreach (DATA.CLB o in CLBL)
                    {
                        using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
                        {
                            try
                            {
                                List<thanh_vien_clb> thanh_Vien_Clbs = db.thanh_vien_clb.Where(x => x.id_clb == o.id_clb).ToList();
                                if (thanh_Vien_Clbs.Count > 1)
                                {
                                    //MessageBox.Show("Không thể xóa CLB đã có thành viên.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                                    c_fail++;
                                    continue;
                                }
                                thanh_vien_clb quanly = db.thanh_vien_clb.FirstOrDefault(x => x.id_clb == o.id_clb && x.la_quan_ly == true);
                                db.thanh_vien_clb.Remove(quanly);
                                DATA.CLB clb = db.CLBs.FirstOrDefault(x => x.id_clb == o.id_clb);
                                db.CLBs.Remove(clb);

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
                    MessageBox.Show(result, "Kết quả", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }


        }

        public void OpenUpdateWindow()
        {
            if (cLBDataGrid.SelectedItems.Count > 0)
            {
                DATA.CLB o = (DATA.CLB)cLBDataGrid.SelectedItem;
                CLB w = new CLB(o);
                w.ShowDialog();
                Refresh(); 
            }
        }

        //end class
    }
}
