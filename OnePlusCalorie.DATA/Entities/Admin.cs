using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePlusCalorie.DATA.Entities
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string AdminAdi { get; set; }

        [Required]
        public string AdminSifre { get; set; }

        //public List<Besin> AdmininGirdiğiBesinler { get; set; }
        //public List<Kategori> AdmininGirdiğiKategoriler { get; set; }


    }
}
