using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyHoiNguoiCaoTuoi
{
    public static class CustomException
    {
        public static void SQLException(Exception ex)
        {
            Console.WriteLine("\n###Exception: " + ex);
            MessageBox.Show(ex.InnerException.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void UnknownException(Exception ex)
        {
            Console.WriteLine("\n###Exception: " + ex);
            MessageBox.Show(ex.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //end class
    }
}
