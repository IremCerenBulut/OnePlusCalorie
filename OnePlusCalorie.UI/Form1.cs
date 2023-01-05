using OnePlusCalorie.DATA.Entities;
using OnePlusCalorie.UI.Classes;
using OnePlusCalorie.UI.Forms;

namespace OnePlusCalorie.UI
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private Kullanici _kullanici;
       
        public Form1(Kullanici kullanici)
        {
            InitializeComponent();
            _kullanici = kullanici;
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IdleForm anaMenu = new IdleForm();
            anaMenu.TopLevel = false;
            anaMenu.FormBorderStyle = FormBorderStyle.None;
            anaMenu.Dock = DockStyle.Fill;
            this.pnlForm.Controls.Add(anaMenu);
            this.pnlForm.Tag = anaMenu;
            anaMenu.BringToFront();
            anaMenu.Show();
            lblAnaMenu.Text = anaMenu.Text;
        }

        private Color SelectThemeColor()
        {
            int index = ThemeColor.ColorList.Count;
            string color = ThemeColor.ColorList[0];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButtons(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButtons();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = currentButton.ForeColor;
                }
            }
        }

        private void DisableButtons()
        {
            foreach (Control oncekiButon in pnlMenu.Controls)
            {
                if (oncekiButon.GetType() == typeof(Button))
                {
                    oncekiButon.BackColor = Color.FromArgb(224, 64, 106);
                    oncekiButon.ForeColor = Color.FromArgb(41, 44, 53);
                    oncekiButon.Font = oncekiButon.Font;
                }
            }
        }


        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButtons(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlForm.Controls.Add(childForm);
            this.pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblAnaMenu.Text = childForm.Text;
        }

        private void btnAnaMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.IdleForm(), sender);
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ProfilForm(_kullanici), sender);
        }

        private void btnOgunKayit_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.OgunKayitForm(), sender);
        }

        private void btnKalori_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.KaloriForm(), sender);
        }

        private void btnBesin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.BesinForm(_kullanici), sender);
        }

        private void btnHakkinda_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.HakkindaForm(), sender);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}