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

namespace QuanLyHoiNguoiCaoTuoi.UI.KhuPho
{
    /// <summary>
    /// Interaction logic for UC_DatagridKhuPho.xaml
    /// </summary>
    public partial class UC_DatagridKhuPho : UserControl
    {
        hoi_nguoi_cao_tuoiEntities context = new hoi_nguoi_cao_tuoiEntities();
        CollectionViewSource khu_phoViewSource;

        public UC_DatagridKhuPho()
        {
            InitializeComponent();
            khu_phoViewSource = ((CollectionViewSource)(FindResource("khu_phoViewSource")));
            DataContext = this;
        }

        public void Refresh()
        {
            LoadData();
            khu_phoViewSource.View.Refresh();
        }

        private void LoadData()
        {
            khu_phoViewSource.Source = null;

            try
            {
                //.khu_pho.Load();
                khu_phoViewSource.Source = context.khu_pho.ToList();
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
            int countCol = khu_phoDataGrid.Columns.Count;
            int countSelected = khu_phoDataGrid.SelectedCells.Count / countCol;

            if (countSelected > 0)
            {                
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelected);
                MessageBoxResult messageBoxResult = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int c_success = 0;
                    int c_fail = 0;

                    List<khu_pho> khu_phoL = new List<khu_pho>();
                    for (int r = 0; r < countSelected; r++)
                    {
                        khu_pho t = (khu_pho)khu_phoDataGrid.SelectedCells[r * countCol].Item;

                        khu_phoL.Add(t);
                    }
                    foreach (khu_pho t in khu_phoL)
                    {
                        using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
                        {
                            try
                            {
                                khu_pho o = db.khu_pho.FirstOrDefault(x => x.id_khu_pho == t.id_khu_pho);
                                db.khu_pho.Remove(o);
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
            if (khu_phoDataGrid.SelectedItems.Count > 0)
            {
                khu_pho o = (khu_pho)khu_phoDataGrid.SelectedItem;
                KhuPho w = new KhuPho(o);
                w.ShowDialog();
                Refresh(); 
            }
        }

        //end class
    }
}
