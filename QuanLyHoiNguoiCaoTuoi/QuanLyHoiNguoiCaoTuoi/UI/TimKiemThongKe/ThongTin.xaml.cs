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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QuanLyHoiNguoiCaoTuoi.DATA;

namespace QuanLyHoiNguoiCaoTuoi.UI.TimKiemThongKe
{
    /// <summary>
    /// Interaction logic for ThongTin.xaml
    /// </summary>
    public partial class ThongTin : Window
    {
        public ThongTin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load("../../UI/TimKiemThongKe/R_ThongTin.rpt");
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                report.SetDataSource(db.V_ThongKe_ThongTin.ToList());
            }
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}
