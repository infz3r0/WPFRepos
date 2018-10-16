using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using QuanLyHoiNguoiCaoTuoi.UI;
using QuanLyHoiNguoiCaoTuoi.UI.CLB;
using QuanLyHoiNguoiCaoTuoi.UI.HoatDong;
using QuanLyHoiNguoiCaoTuoi.UI.Hop;
using QuanLyHoiNguoiCaoTuoi.UI.KhuPho;
using QuanLyHoiNguoiCaoTuoi.UI.Quy;
using QuanLyHoiNguoiCaoTuoi.UI.TaiKhoan;
using QuanLyHoiNguoiCaoTuoi.UI.ThanhVien;
using QuanLyHoiNguoiCaoTuoi.UI.TimKiemThogKe;

namespace QuanLyHoiNguoiCaoTuoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int id_account;
        public int id_role;

        public MainWindow()
        {
            InitializeComponent();

            
        }

        public void LoginInfo(int id_user, string username)
        {
            id_account = id_user;
            lblUsername.Content = username;
        }
        
        #region khu pho
        private void rbtThemKhuPho_Click(object sender, RoutedEventArgs e)
        {
            KhuPho f = new KhuPho();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSKhuPho";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_DatagridKhuPho)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaKhuPho_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSKhuPho";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //call delete
                    ((UC_DatagridKhuPho)((TabItem)item).Content).DeleteSelectedRows();
                    return;
                }
            }
        }

        private void rbtSuaKhuPho_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSKhuPho";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_DatagridKhuPho)((TabItem)item).Content).OpenUpdateWindow();
                    return;
                }
            }
        }

        #endregion
        #region thanh vien
        private void rbtThemThanhVien_Click(object sender, RoutedEventArgs e)
        {
            ThongTinThanhVien f = new ThongTinThanhVien();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSThanhVien";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_ThongTinThanhVien)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaThanhVien_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSThanhVien";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_ThongTinThanhVien)((TabItem)item).Content).DeleteSelectedRows();
                    return;
                }
            }
        }

        private void rbtSuaThanhVien_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSThanhVien";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_ThongTinThanhVien)((TabItem)item).Content).OpenUpdateWindow();
                    return;
                }
            }
        }

        #endregion
        #region bch
        private void rbtThemBCH_Click(object sender, RoutedEventArgs e)
        {
            ThongTinBanChapHanh f = new ThongTinBanChapHanh();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSBCH";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_ThongTinBanChapHanh)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaBCH_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSBCH";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_ThongTinBanChapHanh)((TabItem)item).Content).DeleteSelectedRows();
                    return;
                }
            }
        }

        private void rbtSuaBCH_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSBCH";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_ThongTinBanChapHanh)((TabItem)item).Content).OpenUpdateWindow();
                    return;
                }
            }
        }

        #endregion
        #region hoat dong
        private void rbtThemHoatDong_Click(object sender, RoutedEventArgs e)
        {
            HoatDong f = new HoatDong();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSHoatDong";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_HoatDong)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaHoatDong_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSHoatDong";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_HoatDong)((TabItem)item).Content).DeleteSelectedRows();
                    return;
                }
            }
        }

        private void rbtSuaHoatDong_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSHoatDong";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_HoatDong)((TabItem)item).Content).OpenUpdateWindow();
                    return;
                }
            }
        }

        #endregion
        #region thanh vien hoat dong
        private void rbtThemThamGiaHD_Click(object sender, RoutedEventArgs e)
        {
            ThanhVienHoatDong f = new ThanhVienHoatDong();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSThanhVienHoatDong";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_ThanhVienHoatDong)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaThamGiaHD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaThamGiaHD_Click(object sender, RoutedEventArgs e)
        {
            
        }

        #endregion
        #region thu
        private void rbtThemKhoanThu_Click(object sender, RoutedEventArgs e)
        {

            Thu f = new Thu();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSThu";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_KhoanThu)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaKhoanThu_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSThu";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_KhoanThu)((TabItem)item).Content).DeleteSelectedRows();
                    return;
                }
            }
        }

        private void rbtSuaKhoanThu_Click(object sender, RoutedEventArgs e)
        {

            //init tab
            string tabName = "tabDSThu";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_KhoanThu)((TabItem)item).Content).OpenUpdateWindow();
                    return;
                }
            }
        }

        #endregion
        #region chi
        private void rbtThemKhoanChi_Click(object sender, RoutedEventArgs e)
        {

            Chi f = new Chi();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSChi";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_KhoanChi)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaKhoanChi_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSChi";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_KhoanChi)((TabItem)item).Content).DeleteSelectedRows();
                    return;
                }
            }
        }

        private void rbtSuaKhoanChi_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSChi";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_KhoanChi)((TabItem)item).Content).OpenUpdateWindow();
                    return;
                }
            }

        }

        private void rbtDuyetKhoanChi_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSChi";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_KhoanChi)((TabItem)item).Content).OpenDuyetWindow();
                    return;
                }
            }
        }

        #endregion
        #region clb
        private void rbtThemCLB_Click(object sender, RoutedEventArgs e)
        {
            CLB f = new CLB();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSCLB";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_DatagridCLB)((TabItem)item).Content).Refresh();
                    return;
                }
            }

            //init tab
            string tabName2 = "tabDSThanhVienCLB";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName2) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_ThanhVienCLB)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaCLB_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSCLB";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_DatagridCLB)((TabItem)item).Content).DeleteSelectedRows();
                    return;
                }
            }
        }

        private void rbtSuaCLB_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSCLB";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_DatagridCLB)((TabItem)item).Content).OpenUpdateWindow();
                    return;
                }
            }

            //init tab
            string tabName2 = "tabDSThanhVienCLB";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName2) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_ThanhVienCLB)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        #endregion
        #region thanh vien clb
        private void rbtThemThanhVienCLB_Click(object sender, RoutedEventArgs e)
        {
            ThanhVienCLB f = new ThanhVienCLB();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSThanhVienCLB";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_ThanhVienCLB)((TabItem)item).Content).Refresh();
                    return;
                }
            }

        }

        private void rbtXoaThanhVienCLB_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rbtSuaThanhVienCLB_Click(object sender, RoutedEventArgs e)
        {
            
        }

        #endregion
        #region hop bch
        private void rbtThemHopBCH_Click(object sender, RoutedEventArgs e)
        {
            HopBCH f = new HopBCH();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSHopBCH";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_HopBCH)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaHopBCH_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSHopBCH";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_HopBCH)((TabItem)item).Content).DeleteSelectedRows();
                    return;
                }
            }
        }

        private void rbtSuaHopBCH_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSHopBCH";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_HopBCH)((TabItem)item).Content).OpenUpdateWindow();
                    return;
                }
            }
        }

        #endregion
        #region hop tn
        private void rbtThemHopTN_Click(object sender, RoutedEventArgs e)
        {
            HopThuongNien f = new HopThuongNien();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSHopTN";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_HopTN)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaHopTN_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSHopTN";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_HopTN)((TabItem)item).Content).DeleteSelectedRows();
                    return;
                }
            }
        }

        private void rbtSuaHopTN_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSHopTN";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //
                    ((UC_Datagrid_HopTN)((TabItem)item).Content).OpenUpdateWindow();
                    return;
                }
            }

        }

        #endregion
        #region thanh vien hop
        private void rbtThemThanhVienHop_Click(object sender, RoutedEventArgs e)
        {
            ThanhVienHop f = new ThanhVienHop();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSThanhVienHop";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_ThanhVienHop)((TabItem)item).Content).Refresh();
                    return;
                }
            }

        }

        private void rbtXoaThanhVienHop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaThanhVienHop_Click(object sender, RoutedEventArgs e)
        {
            
        }

        #endregion
        #region bch hop
        private void rbtThemBCHHop_Click(object sender, RoutedEventArgs e)
        {
            BCHThamGiaHop f = new BCHThamGiaHop();
            f.ShowDialog();

            //init tab
            string tabName = "tabDSBCHHop";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName) && ((TabItem)item).IsSelected)
                {
                    //refresh
                    ((UC_Datagrid_BCHThamGiaHop)((TabItem)item).Content).Refresh();
                    return;
                }
            }
        }

        private void rbtXoaBCHHop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtSuaBCHHop_Click(object sender, RoutedEventArgs e)
        {

        }



        #endregion
        #region Danh sach
        private void rbtDSHopBCH_Click(object sender, RoutedEventArgs e)
        {
            //AddNewTab("tabDSHopBCH", "Họp ban chấp hành", "dgDSHopBCH");
            //init tab
            string tabName = "tabDSHopBCH";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_HopBCH)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Họp BCH";

            UC_Datagrid_HopBCH uc = new UC_Datagrid_HopBCH();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSKhuPho_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSKhuPho";                      

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_DatagridKhuPho)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Khu phố";

            UC_DatagridKhuPho uc = new UC_DatagridKhuPho();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSThanhVien_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSThanhVien";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_ThongTinThanhVien)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Thành viên";

            UC_Datagrid_ThongTinThanhVien uc = new UC_Datagrid_ThongTinThanhVien();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSBCH_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSBCH";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_ThongTinBanChapHanh)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Ban chấp hành";

            UC_Datagrid_ThongTinBanChapHanh uc = new UC_Datagrid_ThongTinBanChapHanh();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSHoatDong_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSHoatDong";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_HoatDong)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Hoạt động";

            UC_Datagrid_HoatDong uc = new UC_Datagrid_HoatDong();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSThanhVienHoatDong_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSThanhVienHoatDong";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_ThanhVienHoatDong)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Thành viên tham gia hoạt động";

            UC_Datagrid_ThanhVienHoatDong uc = new UC_Datagrid_ThanhVienHoatDong();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSThu_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSThu";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_KhoanThu)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Khoản thu";

            UC_Datagrid_KhoanThu uc = new UC_Datagrid_KhoanThu();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSChi_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSChi";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_KhoanChi)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Khoản chi";

            UC_Datagrid_KhoanChi uc = new UC_Datagrid_KhoanChi();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSCLB_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSCLB";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_DatagridCLB)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Câu lạc bộ";

            UC_DatagridCLB uc = new UC_DatagridCLB();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSThanhVienCLB_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSThanhVienCLB";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_ThanhVienCLB)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Thành viên CLB";

            UC_Datagrid_ThanhVienCLB uc = new UC_Datagrid_ThanhVienCLB();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSBCHHop_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSBCHHop";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_BCHThamGiaHop)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "BCH tham gia họp";

            UC_Datagrid_BCHThamGiaHop uc = new UC_Datagrid_BCHThamGiaHop();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSHopTN_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSHopTN";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_HopTN)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Họp thường niên";

            UC_Datagrid_HopTN uc = new UC_Datagrid_HopTN();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtDSThanhVienHop_Click(object sender, RoutedEventArgs e)
        {
            //init tab
            string tabName = "tabDSThanhVienHop";

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    ((UC_Datagrid_ThanhVienHop)((TabItem)item).Content).Refresh();
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = "Thành viên họp";

            UC_Datagrid_ThanhVienHop uc = new UC_Datagrid_ThanhVienHop();
            tab.Content = uc;

            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }
        #endregion


        private void AddNewTab(string tabName, string tabHeader, string dgridName)
        {
            //init tab
            TabItem tab = new TabItem();
            tab.Name = tabName;
            tab.Header = tabHeader;
            DataGrid dataGrid = new DataGrid();
            dataGrid.Name = dgridName;
            tab.Content = dataGrid;

            //check exist
            foreach (object item in tctMain.Items)
            {
                if (item is TabItem && ((TabItem)item).Name.Equals(tabName))
                {
                    //go to exist tab
                    tctMain.SelectedItem = item;
                    return;
                }
            }

            //add new tab
            tctMain.Items.Add(tab);
            tctMain.SelectedItem = tab;
        }

        private void rbtSearch_Click(object sender, RoutedEventArgs e)
        {
            TimKiem f = new TimKiem();
            f.ShowDialog();
        }

        private void rbtThongKe_Click(object sender, RoutedEventArgs e)
        {
            ThongKeThanhVienHoatDong f = new ThongKeThanhVienHoatDong();
            f.ShowDialog();
        }



        private void rbtNewAccount_Click(object sender, RoutedEventArgs e)
        {
            NewAccount w = new NewAccount();
            w.ShowDialog();
        }

        private void rbtDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            DeleteAccount w = new DeleteAccount();
            w.ShowDialog();
        }

        private void rbtResetPassword_Click(object sender, RoutedEventArgs e)
        {
            ResetPassword w = new ResetPassword();
            w.ShowDialog();
        }

        private void rbtEditAccount_Click(object sender, RoutedEventArgs e)
        {
            UpdateAccount w = new UpdateAccount(id_account);
            w.ShowDialog();
        }

        private void rbtChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword w = new ChangePassword(id_account);
            w.ShowDialog();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            id_account = 0;
            lblUsername.Content = "#";
            lblRole.Content = "";

            Login();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            DangNhap w = new DangNhap();
            w.ShowDialog();

            ApplyPermission(id_role);
        }

        #region set permission

        enum TypePermission
        {
            VIEWONLY,
            FULL,
            NONE
        }

        private void SetVisibility(TypePermission permission, RibbonGroup rbg, RibbonButton ds, RibbonButton add, RibbonButton del, RibbonButton edit )
        {
            switch(permission)
            {
                case TypePermission.VIEWONLY:
                    rbg.Visibility = Visibility.Visible;
                    ds.Visibility = Visibility.Visible;
                    add.Visibility = Visibility.Hidden;
                    del.Visibility = Visibility.Hidden;
                    edit.Visibility = Visibility.Hidden;
                    break;
                case TypePermission.FULL:
                    rbg.Visibility = Visibility.Visible;
                    ds.Visibility = Visibility.Visible;
                    add.Visibility = Visibility.Visible;
                    del.Visibility = Visibility.Visible;
                    edit.Visibility = Visibility.Visible;
                    break;
                case TypePermission.NONE:
                    rbg.Visibility = Visibility.Hidden;
                    ds.Visibility = Visibility.Hidden;
                    add.Visibility = Visibility.Hidden;
                    del.Visibility = Visibility.Hidden;
                    edit.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void SetVisibility_KhuPho(TypePermission permission)
        {
            SetVisibility(permission, rbgKhuPho, rbtDSKhuPho, rbtThemKhuPho, rbtXoaKhuPho, rbtSuaKhuPho);
        }

        private void SetVisibility_ThanhVien(TypePermission permission)
        {
            SetVisibility(permission, rbgThanhVien, rbtDSThanhVien, rbtThemThanhVien, rbtXoaThanhVien, rbtSuaThanhVien);
        }

        private void SetVisibility_BCH(TypePermission permission)
        {
            SetVisibility(permission, rbgBCH, rbtDSBCH, rbtThemBCH, rbtXoaBCH, rbtSuaBCH);
        }

        private void SetVisibility_HoatDong(TypePermission permission)
        {
            SetVisibility(permission, rbgHoatDong, rbtDSHoatDong, rbtThemHoatDong, rbtXoaHoatDong, rbtSuaHoatDong);
        }

        private void SetVisibility_ThamGiaHD(TypePermission permission)
        {
            SetVisibility(permission, rbgThamGiaHD, rbtDSThamGiaHD, rbtThemThamGiaHD, rbtXoaThamGiaHD, rbtSuaThamGiaHD);
        }

        private void SetVisibility_KhoanThu(TypePermission permission)
        {
            SetVisibility(permission, rbgKhoanThu, rbtDSKhoanThu, rbtThemKhoanThu, rbtXoaKhoanThu, rbtSuaKhoanThu);
        }

        private void SetVisibility_KhoanChi(TypePermission permission)
        {
            SetVisibility(permission, rbgKhoanChi, rbtDSKhoanChi, rbtThemKhoanChi, rbtXoaKhoanChi, rbtSuaKhoanChi);
            rbtDuyetKhoanChi.Visibility = Visibility.Hidden;
        }

        private void SetVisibility_CLB(TypePermission permission)
        {
            SetVisibility(permission, rbgCLB, rbtDSCLB, rbtThemCLB, rbtXoaCLB, rbtSuaCLB);
        }

        private void SetVisibility_ThanhVienCLB(TypePermission permission)
        {
            SetVisibility(permission, rbgThanhVienCLB, rbtDSThanhVienCLB, rbtThemThanhVienCLB, rbtXoaThanhVienCLB, rbtSuaThanhVienCLB);
        }

        private void SetVisibility_HopBCH(TypePermission permission)
        {
            SetVisibility(permission, rbgHopBCH, rbtDSHopBCH, rbtThemHopBCH, rbtXoaHopBCH, rbtSuaHopBCH);
        }

        private void SetVisibility_BCHHop(TypePermission permission)
        {
            SetVisibility(permission, rbgBCHHop, rbtDSBCHHop, rbtThemBCHHop, rbtXoaBCHHop, rbtSuaBCHHop);
        }

        private void SetVisibility_HopTN(TypePermission permission)
        {
            SetVisibility(permission, rbgHopTN, rbtDSHopTN, rbtThemHopTN, rbtXoaHopTN, rbtSuaHopTN);
        }

        private void SetVisibility_ThanhVienHop(TypePermission permission)
        {
            SetVisibility(permission, rbgThanhVienHop, rbtDSThanhVienHop, rbtThemThanhVienHop, rbtXoaThanhVienHop, rbtSuaThanhVienHop);
        }

        private void SetVisibility_TimKiem(TypePermission permission)
        {
            switch(permission)
            {
                case TypePermission.FULL:
                    rbgTimKiem.Visibility = Visibility.Visible;
                    break;
                case TypePermission.NONE:
                    rbgTimKiem.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void SetVisibility_ThongKe(TypePermission permission)
        {
            //SetVisibility(permission, rbgKhuPho, rbtDSKhuPho, rbtThemKhuPho, rbtXoaKhuPho, rbtSuaKhuPho);
        }

        private void SetVisibility_QuanLyTaiKhoan(TypePermission permission)
        {
            switch (permission)
            {
                case TypePermission.FULL:
                    rbgQuanLyTaiKhoan.Visibility = Visibility.Visible;
                    break;
                case TypePermission.NONE:
                    rbgQuanLyTaiKhoan.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void SetVisibility_TaiKhoanCaNhan(TypePermission permission)
        {
            switch (permission)
            {
                case TypePermission.FULL:
                    rbgTaiKhoanCaNhan.Visibility = Visibility.Visible;
                    break;
                case TypePermission.NONE:
                    rbgTaiKhoanCaNhan.Visibility = Visibility.Hidden;
                    break;
            }
        }

        #endregion

        private void ApplyPermission(int idp)
        {
            switch (idp)
            {
                //admin
                case -1:
                    SetVisibility_KhuPho(TypePermission.FULL);
                    SetVisibility_ThanhVien(TypePermission.FULL);
                    SetVisibility_BCH(TypePermission.FULL);

                    SetVisibility_HoatDong(TypePermission.FULL);
                    SetVisibility_ThamGiaHD(TypePermission.FULL);

                    SetVisibility_KhoanThu(TypePermission.FULL);
                    SetVisibility_KhoanChi(TypePermission.FULL);

                    SetVisibility_CLB(TypePermission.FULL);
                    SetVisibility_ThanhVienCLB(TypePermission.FULL);

                    SetVisibility_HopBCH(TypePermission.FULL);
                    SetVisibility_BCHHop(TypePermission.FULL);

                    SetVisibility_HopTN(TypePermission.FULL);
                    SetVisibility_ThanhVienHop(TypePermission.FULL);

                    SetVisibility_TimKiem(TypePermission.FULL);
                    SetVisibility_ThongKe(TypePermission.FULL);

                    SetVisibility_QuanLyTaiKhoan(TypePermission.FULL);
                    SetVisibility_TaiKhoanCaNhan(TypePermission.FULL);
                    break;
                //chu tich
                case 0:
                    SetVisibility_KhuPho(TypePermission.FULL);
                    SetVisibility_ThanhVien(TypePermission.FULL);
                    SetVisibility_BCH(TypePermission.FULL);

                    SetVisibility_HoatDong(TypePermission.FULL);
                    SetVisibility_ThamGiaHD(TypePermission.FULL);

                    SetVisibility_KhoanThu(TypePermission.VIEWONLY);
                    SetVisibility_KhoanChi(TypePermission.VIEWONLY);
                    rbtDuyetKhoanChi.Visibility = Visibility.Visible;

                    SetVisibility_CLB(TypePermission.FULL);
                    SetVisibility_ThanhVienCLB(TypePermission.FULL);

                    SetVisibility_HopBCH(TypePermission.FULL);
                    SetVisibility_BCHHop(TypePermission.FULL);

                    SetVisibility_HopTN(TypePermission.FULL);
                    SetVisibility_ThanhVienHop(TypePermission.FULL);

                    SetVisibility_TimKiem(TypePermission.FULL);
                    SetVisibility_ThongKe(TypePermission.FULL);

                    SetVisibility_QuanLyTaiKhoan(TypePermission.FULL);
                    SetVisibility_TaiKhoanCaNhan(TypePermission.FULL);
                    break;
                //pho chu tich
                case 1:
                    SetVisibility_KhuPho(TypePermission.VIEWONLY);
                    SetVisibility_ThanhVien(TypePermission.VIEWONLY);
                    SetVisibility_BCH(TypePermission.VIEWONLY);

                    SetVisibility_HoatDong(TypePermission.FULL);
                    SetVisibility_ThamGiaHD(TypePermission.FULL);

                    SetVisibility_KhoanThu(TypePermission.NONE);
                    SetVisibility_KhoanChi(TypePermission.NONE);

                    SetVisibility_CLB(TypePermission.FULL);
                    SetVisibility_ThanhVienCLB(TypePermission.FULL);

                    SetVisibility_HopBCH(TypePermission.FULL);
                    SetVisibility_BCHHop(TypePermission.FULL);

                    SetVisibility_HopTN(TypePermission.FULL);
                    SetVisibility_ThanhVienHop(TypePermission.FULL);

                    SetVisibility_TimKiem(TypePermission.FULL);
                    SetVisibility_ThongKe(TypePermission.FULL);

                    SetVisibility_QuanLyTaiKhoan(TypePermission.NONE);
                    SetVisibility_TaiKhoanCaNhan(TypePermission.FULL);
                    break;
                //uy vien
                case 2:
                    SetVisibility_KhuPho(TypePermission.VIEWONLY);
                    SetVisibility_ThanhVien(TypePermission.VIEWONLY);
                    SetVisibility_BCH(TypePermission.VIEWONLY);

                    SetVisibility_HoatDong(TypePermission.VIEWONLY);
                    SetVisibility_ThamGiaHD(TypePermission.VIEWONLY);

                    SetVisibility_KhoanThu(TypePermission.NONE);
                    SetVisibility_KhoanChi(TypePermission.NONE);

                    SetVisibility_CLB(TypePermission.VIEWONLY);
                    SetVisibility_ThanhVienCLB(TypePermission.VIEWONLY);

                    SetVisibility_HopBCH(TypePermission.VIEWONLY);
                    SetVisibility_BCHHop(TypePermission.VIEWONLY);

                    SetVisibility_HopTN(TypePermission.VIEWONLY);
                    SetVisibility_ThanhVienHop(TypePermission.VIEWONLY);

                    SetVisibility_TimKiem(TypePermission.FULL);
                    SetVisibility_ThongKe(TypePermission.NONE);

                    SetVisibility_QuanLyTaiKhoan(TypePermission.NONE);
                    SetVisibility_TaiKhoanCaNhan(TypePermission.FULL);
                    break;
                //ke toan
                case 3:
                    SetVisibility_KhuPho(TypePermission.VIEWONLY);
                    SetVisibility_ThanhVien(TypePermission.VIEWONLY);
                    SetVisibility_BCH(TypePermission.VIEWONLY);

                    SetVisibility_HoatDong(TypePermission.VIEWONLY);
                    SetVisibility_ThamGiaHD(TypePermission.VIEWONLY);

                    SetVisibility_KhoanThu(TypePermission.FULL);
                    SetVisibility_KhoanChi(TypePermission.FULL);

                    SetVisibility_CLB(TypePermission.VIEWONLY);
                    SetVisibility_ThanhVienCLB(TypePermission.VIEWONLY);

                    SetVisibility_HopBCH(TypePermission.VIEWONLY);
                    SetVisibility_BCHHop(TypePermission.VIEWONLY);

                    SetVisibility_HopTN(TypePermission.VIEWONLY);
                    SetVisibility_ThanhVienHop(TypePermission.VIEWONLY);

                    SetVisibility_TimKiem(TypePermission.FULL);
                    SetVisibility_ThongKe(TypePermission.NONE);

                    SetVisibility_QuanLyTaiKhoan(TypePermission.NONE);
                    SetVisibility_TaiKhoanCaNhan(TypePermission.FULL);
                    break;
            }

        }


        //endclass
    }
}
