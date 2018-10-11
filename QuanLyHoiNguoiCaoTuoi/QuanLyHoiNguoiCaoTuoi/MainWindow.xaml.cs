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
        public MainWindow()
        {
            InitializeComponent();
            
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
            DangNhap w = new DangNhap();
            w.ShowDialog();
        }

        private void rbtEditAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtChangePassword_Click(object sender, RoutedEventArgs e)
        {

        }


        //endclass
    }
}
