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
    public partial class BesinForm : Form
    {
        ProjectContext _db;
        private Kullanici _kullanici;
        public BesinForm(Kullanici kullanici)
        {
            InitializeComponent();
            _db = new ProjectContext();
            _kullanici = kullanici;
            KategoriDoldur();
            
            
        }

        private void KategoriDoldur()
        {
            cmbKategori.DataSource = _db.Kategorilerler.ToList();
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
           var kategori = _db.Kategorilerler.FirstOrDefault(x=>x.KullaniciID==_kullanici.ID);
            if (kategori==null)
            {
                kategori = new Kategori();
                kategori.KategoriAd=txtKategori.Text;
                _db.Kategorilerler.Add(kategori);
                _db.SaveChanges();
                lstKategoriler.Items.Add(kategori);
            }
            else
            {
                MessageBox.Show("Aynı isimde kategori ekleyemezsiniz...");
            }
           
        }


        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            Besin besin = _db.Besinler.FirstOrDefault(x => x.KullaniciID== _kullanici.ID);
            if (besin == null)
            {
                besin = new Besin();
                besin.KategoriID = cmbKategori.SelectedIndex;
                besin.BesinAdi = txtBesinAdi.Text;
                besin.Porsiyon = Convert.ToDouble(txtPorsiyon.Text);

                if (rdKalori.Checked == true)
                {
                    besin.Kalori = Convert.ToInt32(nuKalori.Value);
                }
                else if (rdProtein.Checked == true)
                {
                    besin.Protein = Convert.ToInt32(nuProtein.Value);
                }
                else if (rdoKarbonhidrat.Checked == true)
                {
                    besin.KarbonHidrat = Convert.ToInt32(nuKarbonhidrat.Value);
                }
                else if (rdYag.Checked == true)
                {
                    besin.Yag = Convert.ToInt32(nuYag.Value);
                }

                _db.Besinler.Add(besin);
                _db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Aynı isimde besin ekleyemezsiniz...");
            }
        }

        private void BesinForm_Load(object sender, EventArgs e)
        {

        }
    }
}
