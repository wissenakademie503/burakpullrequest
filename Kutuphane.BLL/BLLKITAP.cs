using Kutuphane.EntityLayer;
using Kutuphane.FacadeLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.BLL
{
    public class BLLKITAP
    {
        public static int Insert(EKITAP item)
        {
            if (item.ADI != null && item.ADI.Trim().Length > 0 &&
                item.KATEGORIID > 0 && item.SAYFASAYISI > 0)
            {

                return FKITAP.Insert(item);
            }
            return -1;
        }

        public static bool Update(EKITAP item)
        {
            if (item.ID > 0 && item.ADI != null && item.ADI.Trim().Length > 0 && 
                item.KATEGORIID>0 && item.SAYFASAYISI>0)
            {

                return FKITAP.Update(item);
            }
            return false;
        }
        public static bool Delete(int _ID)
        {
            if (_ID > 0)
            {
                return FKITAP.Delete(_ID);
            }

            return false;
        }

        public static EKITAP Select(int _ID)
        {
            if (_ID > 0)
            {
                return FKITAP.Select(_ID);
            }

            return null;
        }

        public static List<EKITAP> SelectList()
        {
            return FKITAP.SelectList();
            //Console.WriteLine("BİZDEN NE OLUR:((");
        }
    }
}
  

