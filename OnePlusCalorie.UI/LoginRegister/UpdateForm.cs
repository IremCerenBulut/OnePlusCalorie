using OnePlusCalorie.DAL.Context;
using OnePlusCalorie.DATA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace OnePlusCalorie.UI.LoginRegister
{
    public partial class UpdateForm : Form
    {
        ProjectContext db;
        public UpdateForm()
        {
            InitializeComponent();

            HepsiniGizleKapat();
            db = new ProjectContext();

        }

        private void HepsiniGizleKapat()
        {
            txtAd.Enabled = false;
            txtSoyad.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefon.Enabled = false;

            txtAd.Hide();
            txtSoyad.Hide();
            txtEmail.Hide();
            txtTelefon.Hide();
            btnGuncelle.Hide();
        }

        private void HepsiniAc()
        {
            txtAd.Enabled = true;
            txtSoyad.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefon.Enabled = true;

            txtAd.Show();
            txtSoyad.Show();
            txtEmail.Show();
            txtTelefon.Show();
            btnGuncelle.Show();
        }


        private void UpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKullaniciAdi.Text == "" && txtSifre.Text == "")
                {
                    MessageBox.Show("Kullanıcı Adı ve Şifre giriniz!!");
                }
                else if (txtKullaniciAdi.Text == "" && txtSifre.Text != string.Empty)
                {
                    MessageBox.Show("Kullanıcı Adınızı giriniz!!");
                }
                else if (txtKullaniciAdi.Text != string.Empty && txtSifre.Text == "")
                {
                    MessageBox.Show("Şifrenizi giriniz!!");
                }
                else if (db.Kullanicilar.FirstOrDefault(user => user.KullaniciAdi == txtKullaniciAdi.Text && user.Sifre == txtSifre.Text) != null)
                {
                    HepsiniAc();
                    txtKullaniciAdi.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş Yaptınız!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA!!" + ex.Message);
            }
            
            btnGirisYap.Enabled = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Kullanici kullanici;
            kullanici = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == txtKullaniciAdi.Text);

            if (kullanici != null) 
            {
                kullanici.Adi = txtAd.Text;
                kullanici.Soyad = txtSoyad.Text;
                kullanici.Email = txtEmail.Text;
                kullanici.Telefon = txtTelefon.Text;
                kullanici.Sifre = txtSifre.Text;
                kullanici.GuncellemeTarihi = DateTime.Now;

                MessageBox.Show("Güncelleme Başarıyla Tamamlandı!!");

            }
            else
            {
                MessageBox.Show("Seçilen kullanıcı güncelenememektedir.");
            }
            db.SaveChanges();

            //LoginForm girisForm = new LoginForm();

            LoginForm loginForm = (LoginForm)Application.OpenForms["LoginForm"];

            loginForm.Show();
            this.Close();            
        }
    }
}
