using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UyeKayitBilgeAdam.Entiti.Models
{
   public class Uye
    {
        public long UyeID  { get; set; }
        public string UyeAdi { get; set; }
        public string UyeSoyadi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public bool Admin { get; set; }
        public long UyeTipiID { get; set; }

        public virtual UyeTipi UyeTipi { get; set; }
    }
}
