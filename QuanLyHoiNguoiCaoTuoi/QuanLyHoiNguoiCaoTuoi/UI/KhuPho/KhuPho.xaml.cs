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
using System.Windows.Shapes;

using QuanLyHoiNguoiCaoTuoi.DATA;

namespace QuanLyHoiNguoiCaoTuoi.UI.KhuPho
{
    /// <summary>
    /// Interaction logic for KhuPho.xaml
    /// </summary>
    public partial class KhuPho : Window
    {
        private KhuPhoDAO dao = new KhuPhoDAO();
        private TYPE type;
        private khu_pho o;

        public enum TYPE {
            ADD,
            EDIT
        }

        public KhuPho()
        {
            InitializeComponent();
            type = TYPE.ADD;
            lblTitle.Content = "Thêm khu phố";
        }

        public KhuPho(khu_pho o)
        {
            InitializeComponent();
            type = TYPE.EDIT;
            this.o = (khu_pho)o;
            lblTitle.Content = "Sửa khu phố";
            txbTenKhuPho.Text = o.ten_khu_pho;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (type == TYPE.ADD)
            {
                khu_pho newo = new khu_pho();
                newo.ten_khu_pho = txbTenKhuPho.Text;
                if (dao.Add(newo))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (type == TYPE.EDIT)
            {                
                o.ten_khu_pho = txbTenKhuPho.Text;
                if (dao.Update(o))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource khu_phoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("khu_phoViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // khu_phoViewSource.Source = [generic data source]
        }
    }
}
