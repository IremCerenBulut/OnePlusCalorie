using OnePlusCalorie.DAL.Context;
using OnePlusCalorie.DATA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePlusCalorie.UI.Forms
{
    public partial class ProfilForm : Form
    {
        ProjectContext db;
        private Kullanici _kullanici;
        public ProfilForm(Kullanici kullanici)
        {
            InitializeComponent();
            db = new ProjectContext();
            _kullanici = kullanici;
        }
        
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            var profilBilgisi = db.ProfilBilgileri.FirstOrDefault(x => x.KullaniciID == _kullanici.ID);

            if (profilBilgisi == null)
            {
                profilBilgisi = new ProfilBilgisi();
                profilBilgisi.Ad = txtAd.Text;
                profilBilgisi.Soyad = txtSoyad.Text;
                profilBilgisi.Kilo = Convert.ToDouble(txtKilo.Text);
                profilBilgisi.Boy = Convert.ToDouble(txtBoy.Text);
                profilBilgisi.GuncellemeTarihi = DateTime.Now;
                profilBilgisi.Yas = Convert.ToInt32(txtYas.Text);
                profilBilgisi.YasamTarzi = cmbYasamTarzi.SelectedItem.ToString();
                profilBilgisi.Cinsiyet = txtCinsiyet.Text == "Kadın" ? true : false;
                profilBilgisi.KullaniciID = _kullanici.ID;


                db.ProfilBilgileri.Add(profilBilgisi);
                db.SaveChanges();
            }

            lblVucutKitleEndeksi.Text=Convert.ToString(VucutKitleEndeksiHesapla());
            profilBilgisi.VucutKitleEndeksi = Convert.ToDouble(lblVucutKitleEndeksi.Text);
            db.Add(profilBilgisi);
            db.SaveChanges();
        }
        public double VucutKitleEndeksiHesapla()
        {
            double boy= Convert.ToDouble(txtBoy.Text);
            double kilo= Convert.ToDouble(txtKilo.Text);
            double VKE = kilo / (boy * boy);

            return VKE;
        }
        private void ProfilForm_Load(object sender, EventArgs e)
        {

        }
    }
}
