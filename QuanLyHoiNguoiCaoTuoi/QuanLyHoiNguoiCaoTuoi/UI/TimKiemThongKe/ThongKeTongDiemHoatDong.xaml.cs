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
    /// Interaction logic for ThongKeTongDiemHoatDong.xaml
    /// </summary>
    public partial class ThongKeTongDiemHoatDong : Window
    {
        public ThongKeTongDiemHoatDong()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load("../../UI/TimKiemThongKe/R_TongDiemHoatDong.rpt");
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                report.SetDataSource(from x in db.V_ThongKe_TongDiemHoatDong select new { x.nam, x.tong_diem, x.max, x.percent });
            }
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}
