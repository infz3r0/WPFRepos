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
            // Load is an extension method on IQueryable,    
            // defined in the System.Data.Entity namespace.   
            // This method enumerates the results of the query,    
            // similar to ToList but without creating a list.   
            // When used with Linq to Entities, this method    
            // creates entity objects and adds them to the context.   
            context.khu_pho.Load();

            // After the data is loaded, call the DbSet<T>.Local property    
            // to use the DbSet<T> as a binding source.   
            khu_phoViewSource.Source = context.khu_pho.Local;
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
            int countColumns = khu_phoDataGrid.Columns.Count;
            int countSelectedRows = khu_phoDataGrid.SelectedCells.Count / countColumns;

            if (countSelectedRows > 0)
            {
                string msg = string.Format("Bạn có chắc chắn xóa {0} dòng dữ liệu này?", countSelectedRows);
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(msg, "Xác nhận xóa", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    for (int r = 0; r < countSelectedRows; r++)
                    {
                        khu_pho o = (khu_pho)khu_phoDataGrid.Items[r];
                        try
                        {
                            context.khu_pho.Remove(o);
                            context.SaveChanges();
                            Refresh();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\n###Exception: " + ex);
                        }
                    }
                }
            }

            
        }

        public void OpenUpdateWindow()
        {
            khu_pho o = (khu_pho)khu_phoDataGrid.SelectedItem;
            KhuPho w = new KhuPho(o);
            w.ShowDialog();
            Refresh();
        }

        //end class
    }
}
