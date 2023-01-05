using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePlusCalorie.DATA.Entities
{
    public class Kategori
    {
        [Key]
        public int ID { get; set; }
        public string? KategoriAd { get; set; }
        public string? KategoriDetay { get; set; }
        public virtual List<Besin>? KategorininBesinleri { get; set; }
        //public virtual Admin Admin { get; set; }
        //public int AdminID { get; set; }
        public virtual Kullanici? Kullanici { get; set; }
        public int KullaniciID { get; set; }
    }
}
