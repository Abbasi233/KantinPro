using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KantinPro.Database;

namespace KantinPro.Forms
{
    public partial class Odeme : Form
    {
        // FOR SHADOW
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        KantinProDataContext dc;
        List<OGRENCILER> listOgrenciler;
        decimal tutar;

        public Odeme(string tutar)
        {
            InitializeComponent();

            try
            {
                this.tutar = Convert.ToDecimal(tutar.Split(' ')[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dc = SingletonContext.nesne();
            listOgrenciler = dc.OGRENCILER.ToList();
        }

        private void txtCardNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCardNumber.Text.Length == 10)
            {
                FormRefresh();
                OGRENCILER ogrenci = listOgrenciler.Where(x => x.CARD_ID == txtCardNumber.Text).Single();

                if (ogrenci.BAKIYE >= tutar)
                    panelIslemTamamlandi.Visible = true;
                else
                    panelBakiyeYetersiz.Visible = true;


                txtCardNumber.Text = "";
            }
        }

        private void FormRefresh()
        {
            panelIslemTamamlandi.Visible = panelBakiyeYetersiz.Visible = false;
            labelTutar.Text = "0,0 ₺";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
