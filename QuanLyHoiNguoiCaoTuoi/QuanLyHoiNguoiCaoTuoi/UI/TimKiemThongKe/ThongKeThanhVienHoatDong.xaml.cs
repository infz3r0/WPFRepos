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
    /// Interaction logic for ThongKeThanhVienHoatDong.xaml
    /// </summary>
    public partial class ThongKeThanhVienHoatDong : Window
    {
        public ThongKeThanhVienHoatDong()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load("../../UI/TimKiemThongKe/R_MucDoHoatDong.rpt");
            using (hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities())
            {
                report.SetDataSource(from x in db.V_ThongKe_MucDoHoatDong select new { x.id_thanh_vien, x.ho_ten, x.ngay_sinh, x.SoLanThamGiaHD, x.SoCLBThamGia, x.SoLanThamGiaHop, x.Total });
            }
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}
