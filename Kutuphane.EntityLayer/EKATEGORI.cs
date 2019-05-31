using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.EntityLayer
{
   public  class EKATEGORI :IDisposable
    {
        private int _ID;  //CTRL-R-E 
        private string _ADI;

        public int ID { get => _ID; set => _ID = value; } 
        public string ADI { get => _ADI; set => _ADI = value; }

        public override string ToString() 
        {
            return this.ADI;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this); //Garbage class..?temizleme yapar ve arastır.
        }
    }
}
