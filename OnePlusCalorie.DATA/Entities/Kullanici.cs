using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePlusCalorie.DATA.Entities
{
    public class Kullanici
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Adınızı giriniz!!")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyadınızı giriniz!!")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Epostanızı giriniz!!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefonunuzu giriniz!!")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Giriniz!!")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre Belirleyiniz!!")]
        public string Sifre { get; set; }

        public DateTime UyelikTarihi { get; set; }

        public DateTime GuncellemeTarihi { get; set; }

        //navigation property
        public virtual ProfilBilgisi ProfilBilgisi { get; set; }
        public List<Besin> KullanicininGirdiğiBesinler { get; set; }
        public List<Kategori> KullanicininGirdiğiKategoriler { get; set; }

    }
}
