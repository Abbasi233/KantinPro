using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using KantinPro.Database;

namespace KantinPro
{
    public partial class Giris : Form
    {
        KantinProDataContext db;
        List<KULLANICILAR> tumKulanicilar;

        public Giris()
        {
            InitializeComponent();
            db = SingletonContext.nesne();
            tumKulanicilar = db.KULLANICILAR.ToList();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //txtSifre.Focus();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == tumKulanicilar.Where(x => x.USERNAME == txtUsername.Text).FirstOrDefault().PASSWORD)
            {
                AnaMenu anaMenu = new AnaMenu();
                this.Hide();
                anaMenu.Show();
            }
            else if (txtSifre.Text.Length == 0)
                MessageBox.Show("Şifre girmediniz.", "Giriş işlemi.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Yanlış şifre girdiniz.", "Giriş işlemi.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region btnClick
        private void btn0_Click(object sender, EventArgs e)
        {
            numaratorClick("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            numaratorClick("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            numaratorClick("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            numaratorClick("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            numaratorClick("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            numaratorClick("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            numaratorClick("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            numaratorClick("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            numaratorClick("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            numaratorClick("9");
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtSifre.Text = "";
        }
        #endregion 

        void numaratorClick(string text)
        {
            txtSifre.Text += text;
        }

        private void cbKullaniciAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSifre.Text = "";
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                BtnGiris.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}