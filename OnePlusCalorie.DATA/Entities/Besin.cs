using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePlusCalorie.DATA.Entities
{
    public class Besin
    {
        public int ID { get; set; }
        public string BesinAdi { get; set; }
        public double Porsiyon { get; set; }
        public int Kalori { get; set; }
        public double Protein { get; set; }
        public double KarbonHidrat { get; set; }
        public double Yag { get; set; }
        public virtual Kategori Kategori { get; set; }
        public int KategoriID { get; set; }
        //public virtual Admin Admin { get; set; }
        //public int AdminID { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public int KullaniciID { get; set; }

    }

}
