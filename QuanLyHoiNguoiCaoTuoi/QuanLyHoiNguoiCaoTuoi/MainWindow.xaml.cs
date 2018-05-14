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
using QuanLyHoiNguoiCaoTuoi.Quy;
using QuanLyHoiNguoiCaoTuoi.Hop;

namespace QuanLyHoiNguoiCaoTuoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            dgSimple.ItemsSource = users;
        }

        public class User
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public DateTime Birthday { get; set; }
        }

        private void rbtXoaKhuPho_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaKhuPho_Click(object sender, RoutedEventArgs e)
        {
            KhuPho f = new KhuPho(KhuPho.TYPE.EDIT);
            f.ShowDialog();
        }

        private void rbtThemKhuPho_Click(object sender, RoutedEventArgs e)
        {
            KhuPho f = new KhuPho(KhuPho.TYPE.ADD);
            f.ShowDialog();
        }

        private void rbtThemThanhVien_Click(object sender, RoutedEventArgs e)
        {
            ThongTinThanhVien f = new ThongTinThanhVien(ThongTinThanhVien.TYPE.ADD);
            f.ShowDialog();
        }

        private void rbtXoaThanhVien_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaThanhVien_Click(object sender, RoutedEventArgs e)
        {
            ThongTinThanhVien f = new ThongTinThanhVien(ThongTinThanhVien.TYPE.EDIT);
            f.ShowDialog();
        }

        private void rbtThemBCH_Click(object sender, RoutedEventArgs e)
        {
            ThongTinBanChapHanh f = new ThongTinBanChapHanh(ThongTinBanChapHanh.TYPE.ADD);
            f.ShowDialog();
        }

        private void rbtXoaBCH_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaBCH_Click(object sender, RoutedEventArgs e)
        {
            ThongTinBanChapHanh f = new ThongTinBanChapHanh(ThongTinBanChapHanh.TYPE.EDIT);
            f.ShowDialog();
        }

        private void rbtThemHoatDong_Click(object sender, RoutedEventArgs e)
        {
            HoatDong f = new HoatDong(HoatDong.TYPE.ADD);
            f.ShowDialog();
        }

        private void rbtXoaHoatDong_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaHoatDong_Click(object sender, RoutedEventArgs e)
        {
            HoatDong f = new HoatDong(HoatDong.TYPE.EDIT);
            f.ShowDialog();
        }

        private void rbtThemThamGiaHD_Click(object sender, RoutedEventArgs e)
        {
            ThanhVienHoatDong f = new ThanhVienHoatDong(ThanhVienHoatDong.TYPE.ADD);
            f.ShowDialog();
        }

        private void rbtXoaThamGiaHD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaThamGiaHD_Click(object sender, RoutedEventArgs e)
        {
            ThanhVienHoatDong f = new ThanhVienHoatDong(ThanhVienHoatDong.TYPE.EDIT);
            f.ShowDialog();
        }

        private void rbtThemKhoanThu_Click(object sender, RoutedEventArgs e)
        {

            Thu f = new Thu(Thu.TYPE.ADD);
            f.ShowDialog();
        }

        private void rbtXoaKhoanThu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaKhoanThu_Click(object sender, RoutedEventArgs e)
        {

            Thu f = new Thu(Thu.TYPE.EDIT);
            f.ShowDialog();
        }

        private void rbtThemKhoanChi_Click(object sender, RoutedEventArgs e)
        {

            Chi f = new Chi(Chi.TYPE.ADD);
            f.ShowDialog();
        }

        private void rbtXoaKhoanChi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaKhoanChi_Click(object sender, RoutedEventArgs e)
        {
            Chi f = new Chi(Chi.TYPE.EDIT);
            f.ShowDialog();

        }

        private void rbtThemCLB_Click(object sender, RoutedEventArgs e)
        {
            CLB f = new CLB(CLB.TYPE.ADD);
            f.ShowDialog();

        }

        private void rbtXoaCLB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaCLB_Click(object sender, RoutedEventArgs e)
        {
            CLB f = new CLB(CLB.TYPE.EDIT);
            f.ShowDialog();

        }

        private void rbtThemThanhVienCLB_Click(object sender, RoutedEventArgs e)
        {
            ThanhVienCLB f = new ThanhVienCLB(ThanhVienCLB.TYPE.ADD);
            f.ShowDialog();

        }

        private void rbtXoaThanhVienCLB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaThanhVienCLB_Click(object sender, RoutedEventArgs e)
        {
            ThanhVienCLB f = new ThanhVienCLB(ThanhVienCLB.TYPE.EDIT);
            f.ShowDialog();

        }

        private void rbtThemHopBCH_Click(object sender, RoutedEventArgs e)
        {
            HopBCH f = new HopBCH(HopBCH.TYPE.ADD);
            f.ShowDialog();

        }

        private void rbtXoaHopBCH_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaHopBCH_Click(object sender, RoutedEventArgs e)
        {
            HopBCH f = new HopBCH(HopBCH.TYPE.EDIT);
            f.ShowDialog();

        }

        private void rbtThemHopTN_Click(object sender, RoutedEventArgs e)
        {
            HopThuongNien f = new HopThuongNien(HopThuongNien.TYPE.ADD);
            f.ShowDialog();

        }

        private void rbtXoaHopTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaHopTN_Click(object sender, RoutedEventArgs e)
        {
            HopThuongNien f = new HopThuongNien(HopThuongNien.TYPE.EDIT);
            f.ShowDialog();

        }

        private void rbtThemThanhVienHop_Click(object sender, RoutedEventArgs e)
        {
            ThanhVienHop f = new ThanhVienHop(ThanhVienHop.TYPE.ADD);
            f.ShowDialog();

        }

        private void rbtXoaThanhVienHop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaThanhVienHop_Click(object sender, RoutedEventArgs e)
        {

            ThanhVienHop f = new ThanhVienHop(ThanhVienHop.TYPE.EDIT);
            f.ShowDialog();
        }

        //endclass
    }
}
