﻿using System;
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

namespace QuanLyHoiNguoiCaoTuoi.UI.Quy
{
    /// <summary>
    /// Interaction logic for Duyet.xaml
    /// </summary>
    public partial class Duyet : Window
    {
        public Duyet()
        {
            InitializeComponent();

            lblTitle.Content = "Duyệt khoản chi";
        }



        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}