using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DATA
{
    public class KhuPhoDAO
    {
        private hoi_nguoi_cao_tuoiEntities db = new hoi_nguoi_cao_tuoiEntities();

        public void Them(khu_pho o)
        {
            try
            {
                db.khu_pho.Add(o);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n###Exception: " + ex);
            }
        }





        //end class
    }
}
