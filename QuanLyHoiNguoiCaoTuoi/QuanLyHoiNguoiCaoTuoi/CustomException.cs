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
            if (ex.ToString().ToLower().Contains("conflicted with the reference constraint") || ex.ToString().ToLower().Contains("the relationship could not be changed because one or more of the foreign-key properties is non-nullable"))
            {
                Console.WriteLine("\n###Exception: " + ex);
                //MessageBox.Show("Dữ liệu đang được sử dụng không thể xóa", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Console.WriteLine("\n###Exception: " + ex);
            //MessageBox.Show(ex.InnerException.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void UnknownException(Exception ex)
        {
            Console.WriteLine("\n###Exception: " + ex);
            MessageBox.Show(ex.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //end class
    }
}
