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

namespace QuanLyHoiNguoiCaoTuoi.UI.Quy
{
    /// <summary>
    /// Interaction logic for UC_Datagrid_KhoanThu.xaml
    /// </summary>
    public partial class UC_Datagrid_KhoanThu : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource khoan_thuViewSource;

        public UC_Datagrid_KhoanThu()
        {
            InitializeComponent();
            khoan_thuViewSource = ((CollectionViewSource)(FindResource("khoan_thuViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            khoan_thuViewSource.View.Refresh();
        }

        private void LoadData()
        {
            khoan_thuViewSource.Source = null;

            try
            {
                //.khoan_thu.Load();
                khoan_thuViewSource.Source = context.khoan_thu.ToList();
            }
            catch (Exception ex)
            {
                CustomException.SQLException(ex);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }

            LoadData();
        }

        public void DeleteSelectedRows()
        {
            int countCol = khoan_thuDataGrid.Columns.Count;
            int countSelected = khoan_thuDataGrid.SelectedCells.Count / countCol;

            if (countSelected > 0)
            {
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelected);
                MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int c_success = 0;
                    int c_fail = 0;

                    List<khoan_thu> khoan_thuL = new List<khoan_thu>();
                    for (int r = 0; r < countSelected; r++)
                    {
                        khoan_thu o = (khoan_thu)khoan_thuDataGrid.SelectedCells[r * countCol].Item;
                        khoan_thuL.Add(o);
                    }
                    foreach (khoan_thu t in khoan_thuL)
                    {
                        using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
                        {
                            try
                            {
                                khoan_thu o = db.khoan_thu.FirstOrDefault(x => x.id_thu == t.id_thu);
                                db.khoan_thu.Remove(o);
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
            khoan_thu o = (khoan_thu)khoan_thuDataGrid.SelectedItem;
            Thu w = new Thu(o);
            w.ShowDialog();
            Refresh();
        }

        //end class
    }
}
