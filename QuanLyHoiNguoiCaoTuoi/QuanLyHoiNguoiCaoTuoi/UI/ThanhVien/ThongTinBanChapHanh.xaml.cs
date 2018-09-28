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

namespace QuanLyHoiNguoiCaoTuoi.UI.ThanhVien
{
    /// <summary>
    /// Interaction logic for ThongTinBanChapHanh.xaml
    /// </summary>
    public partial class ThongTinBanChapHanh : Window
    {
        private ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
        private BanChapHanhDAO banChapHanhDAO = new BanChapHanhDAO();
        private TYPE type;
        private thong_tin_ban_chap_hanh o;

        public enum TYPE
        {
            ADD,
            EDIT
        }

        private void LoadDefaultData()
        {
            //ho ten
            cmbHoTen.DisplayMemberPath = "ho_ten";
            cmbHoTen.SelectedValuePath = "id_thanh_vien";

            if (type == TYPE.ADD)
            {
                List<thanh_vien> thanh_Viens = thanhVienDAO.GetListNotInBCH();
                if (thanh_Viens.Count <= 0)
                {
                    MessageBox.Show("Không có thành viên để thêm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    btnOK.IsEnabled = false;
                    return;
                }
                cmbHoTen.ItemsSource = thanh_Viens;
            }
            else
            {
                cmbHoTen.ItemsSource = thanhVienDAO.GetList();
            }
            
            cmbHoTen.SelectedIndex = 0;

            //nam tham gia
            List<int> namL = new List<int>();
            for (int i=1700; i <= 3000; i++)
            {
                namL.Add(i);
            }

            cmbNamThamGiaCongTac.ItemsSource = namL;
            cmbNamThamGiaCongTac.SelectedIndex = 300;
            
        }

        public ThongTinBanChapHanh()
        {
            InitializeComponent();            
            type = TYPE.ADD;
            LoadDefaultData();
            lblTitle.Content = "Thêm thông tin BCH";
            cmbHoTen.Focus();
        }

        public ThongTinBanChapHanh(thong_tin_ban_chap_hanh o)
        {
            InitializeComponent();
            type = TYPE.EDIT;
            LoadDefaultData();
            this.o = (thong_tin_ban_chap_hanh)o;
            lblTitle.Content = "Sửa thông tin BCH";

            cmbHoTen.SelectedValue = o.id_thanh_vien;
            txbDanToc.Text = o.dan_toc;
            txbTonGiao.Text = o.ton_giao;
            txbNgheNghiep.Text = o.nghe_nghiep;
            txbDonViCongTac.Text = o.don_vi_cong_tac;
            txbTrinhDoHocVan.Text = o.trinh_do_hoc_van;
            txbTrinhDoChuyenMon.Text = o.trinh_do_chuyen_mon;
            txbTrinhDoLyLuanChinhTri.Text = o.trinh_do_ly_luan_chinh_tri;
            cmbNamThamGiaCongTac.SelectedItem = o.nam_tham_gia_cong_tac;
            ckbDangVien.IsChecked = o.dang_vien;
            ckbCapUyVien.IsChecked = o.cap_uy_vien;
            ckbBCHNhiemKiTruoc.IsChecked = o.bch_nhiem_ki_truoc;
            txbThanhPhanCoCau.Text = o.thanh_phan_co_cau;

            cmbHoTen.IsEnabled = false;
            txbDanToc.Focus();

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txbDanToc.Text.Length > 20)
            {
                MessageBox.Show("Dân tộc không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbDanToc.Focus();
                return;
            }

            if (txbTonGiao.Text.Length > 10)
            {
                MessageBox.Show("Tôn giáo không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTonGiao.Focus();
                return;
            }

            if (txbNgheNghiep.Text.Length > 50)
            {
                MessageBox.Show("Nghề nghiệp không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbNgheNghiep.Focus();
                return;
            }

            if (txbDonViCongTac.Text.Length > 50)
            {
                MessageBox.Show("Đơn vị công tác không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbDonViCongTac.Focus();
                return;
            }

            if (txbTrinhDoHocVan.Text.Length > 6)
            {
                MessageBox.Show("Trình độ học vấn không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTrinhDoHocVan.Focus();
                return;
            }

            if (txbTrinhDoChuyenMon.Text.Length > 50)
            {
                MessageBox.Show("Trình độ chuyên môn không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTrinhDoChuyenMon.Focus();
                return;
            }

            if (txbTrinhDoLyLuanChinhTri.Text.Length > 6)
            {
                MessageBox.Show("Trình độ lý luận chính trị không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTrinhDoLyLuanChinhTri.Focus();
                return;
            }

            if (txbThanhPhanCoCau.Text.Length > 50)
            {
                MessageBox.Show("Thành phần cơ cấu không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbThanhPhanCoCau.Focus();
                return;
            }

            if ((int)cmbNamThamGiaCongTac.SelectedValue < 1700 || (int)cmbNamThamGiaCongTac.SelectedValue > 3000)
            {
                MessageBox.Show("Năm tham gia công tác không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbThanhPhanCoCau.Focus();
                return;
            }


            if (type == TYPE.ADD)
            {
                thong_tin_ban_chap_hanh newo = new thong_tin_ban_chap_hanh();
                newo.id_thanh_vien = Convert.ToInt32(cmbHoTen.SelectedValue);
                newo.dan_toc = txbDanToc.Text;
                newo.ton_giao = txbTonGiao.Text;
                newo.nghe_nghiep = txbNgheNghiep.Text;
                newo.don_vi_cong_tac = txbDonViCongTac.Text;
                newo.trinh_do_hoc_van = txbTrinhDoHocVan.Text;
                newo.trinh_do_chuyen_mon = txbTrinhDoChuyenMon.Text;
                newo.trinh_do_ly_luan_chinh_tri = txbTrinhDoLyLuanChinhTri.Text;
                newo.nam_tham_gia_cong_tac = Convert.ToInt32(cmbNamThamGiaCongTac.SelectedItem);
                newo.dang_vien = ckbDangVien.IsChecked;
                newo.cap_uy_vien = ckbCapUyVien.IsChecked;
                newo.bch_nhiem_ki_truoc = ckbBCHNhiemKiTruoc.IsChecked;
                newo.thanh_phan_co_cau = txbThanhPhanCoCau.Text;

                if (banChapHanhDAO.Add(newo))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbDanToc.Clear();
                    txbTonGiao.Clear();
                    txbNgheNghiep.Clear();
                    txbDonViCongTac.Clear();
                    txbTrinhDoHocVan.Clear();
                    txbTrinhDoChuyenMon.Clear();
                    txbTrinhDoLyLuanChinhTri.Clear();
                    ckbDangVien.IsChecked = false;
                    ckbCapUyVien.IsChecked = false;
                    ckbBCHNhiemKiTruoc.IsChecked = false;
                    txbThanhPhanCoCau.Clear();
                    LoadDefaultData();
                }
                cmbHoTen.Focus();
            }
            else if (type == TYPE.EDIT)
            {
                o.id_thanh_vien = Convert.ToInt32(cmbHoTen.SelectedValue);
                o.dan_toc = txbDanToc.Text;
                o.ton_giao = txbTonGiao.Text;
                o.nghe_nghiep = txbNgheNghiep.Text;
                o.don_vi_cong_tac = txbDonViCongTac.Text;
                o.trinh_do_hoc_van = txbTrinhDoHocVan.Text;
                o.trinh_do_chuyen_mon = txbTrinhDoChuyenMon.Text;
                o.trinh_do_ly_luan_chinh_tri = txbTrinhDoLyLuanChinhTri.Text;
                o.nam_tham_gia_cong_tac = Convert.ToInt32(cmbNamThamGiaCongTac.SelectedItem);
                o.dang_vien = ckbDangVien.IsChecked;
                o.cap_uy_vien = ckbCapUyVien.IsChecked;
                o.bch_nhiem_ki_truoc = ckbBCHNhiemKiTruoc.IsChecked;
                o.thanh_phan_co_cau = txbThanhPhanCoCau.Text;

                if (banChapHanhDAO.Update(o))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                cmbHoTen.Focus();
            }
        }

        //end class
    }
}
