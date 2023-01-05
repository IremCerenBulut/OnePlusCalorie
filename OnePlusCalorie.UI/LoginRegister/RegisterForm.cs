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

namespace OnePlusCalorie.UI.LoginRegister
{
    public partial class RegisterForm : Form
    {
        ProjectContext db;
        public RegisterForm()
        {
            InitializeComponent();

            db = new ProjectContext();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {

            Kullanici yeniKullanici = new Kullanici()
            {
                Adi = txtAd.Text,
                Soyad = txtSoyad.Text,
                Email = txtEmail.Text,
                Telefon = txtTelefon.Text,
                KullaniciAdi = txtKullaniciAdi.Text,
                Sifre = txtSifre.Text,
                UyelikTarihi = DateTime.Now,
                GuncellemeTarihi = DateTime.Now
            };
            db.Add(yeniKullanici);
            db.SaveChanges();




            LoginForm girisEkrani = new LoginForm();
            this.Hide();
            girisEkrani.Show();
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm girisEkrani = new LoginForm();
            this.Hide();
            girisEkrani.Show();
        }
    }
}
