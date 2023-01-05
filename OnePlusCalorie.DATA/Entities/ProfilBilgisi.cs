using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePlusCalorie.DATA.Entities
{
    public class ProfilBilgisi
    {
        public int ID { get; set; }

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public double Boy { get; set; }
        public double Kilo { get; set; }
        public bool Cinsiyet { get; set; }
        public string YasamTarzi { get; set; } //hareketli harekesiz
        public double? VucutKitleEndeksi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }

        //navigation property
        public virtual Kullanici Kullanici { get; set; }
        public int KullaniciID { get; set; }
    }
}
