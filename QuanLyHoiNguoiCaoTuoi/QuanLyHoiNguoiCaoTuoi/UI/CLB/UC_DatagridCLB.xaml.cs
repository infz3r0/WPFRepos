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
            // Load is an extension method on IQueryable,    
            // defined in the System.Data.Entity namespace.   
            // This method enumerates the results of the query,    
            // similar to ToList but without creating a list.   
            // When used with Linq to Entities, this method    
            // creates entity objects and adds them to the context.   
            try
            {
                //.CLB.Load();
                cLBViewSource.Source = context.CLBs.ToList();
            }
            catch (Exception ex)
            {
                CustomException.SQLException(ex);
            }

            // After the data is loaded, call the DbSet<T>.Local property    
            // to use the DbSet<T> as a binding source.   
            //CLBViewSource.Source = context.CLB.Local;
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
                        try
                        {
                            context.P_Delete_clb(o.id_clb);
                            context.SaveChanges();
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
                    MessageBox.Show(result, "Kết quả", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }


        }

        public void OpenUpdateWindow()
        {
            DATA.CLB o = (DATA.CLB)cLBDataGrid.SelectedItem;
            CLB w = new CLB(o);
            w.ShowDialog();
            Refresh();
        }

        //end class
    }
}
