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

namespace QuanLyHoiNguoiCaoTuoi
{
    /// <summary>
    /// Interaction logic for ThongTinThanhVien.xaml
    /// </summary>
    public partial class ThongTinThanhVien : Window
    {
        public enum TYPE
        {
            ADD,
            EDIT
        }

        public ThongTinThanhVien(TYPE t)
        {
            InitializeComponent();
            if (t == TYPE.ADD)
            {
                lblTitle.Content = "Thêm ";
            }
            else if (t == TYPE.EDIT)
            {
                lblTitle.Content = "Sửa ";
            }
            lblTitle.Content += "thành viên";
        }
    }
}
