using System;
using System.Windows.Forms;
using System.Collections.Generic;

using KantinX.Model;
using RestSharp;

namespace KantinX.Forms
{
    public partial class BakiyeSorgula : Form
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

        AnaMenu anamenu;
        public BakiyeSorgula(AnaMenu anamenu)
        {
            InitializeComponent();
            this.anamenu = anamenu;
        }

        private void FormRefresh()
        {
            panelIslemTamamlandi.Visible = false;
            labelBakiye.Text = "0,0 ₺";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            anamenu.Enabled = true;
            this.Close();
        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNumber.Text.Length == 10)
            {
                FormRefresh();
                OGRENCI ogrenci = GetOgrenci(txtCardNumber.Text);

                if (ogrenci != null)
                {
                    panelIslemTamamlandi.Visible = true;
                    labelKartSahibi.Text = ogrenci.OGRENCI_ADI + " " + ogrenci.OGRENCI_SOYADI;
                    labelBakiye.Text = ogrenci.BAKIYE.Format();

                    txtCardNumber.Clear();
                }
            }
        }

        private OGRENCI GetOgrenci(string KartID)
        {
            anamenu.Request.Parameters.Clear();
            anamenu.Request.Resource = "getOgrenciler.php";
            anamenu.Request.AddParameter("kartID", KartID);
            IRestResponse<List<OGRENCI>> Response = anamenu.Client.Execute<List<OGRENCI>>(anamenu.Request);

            if (!Response.IsSuccessful)
            {
                MessageBox.Show(Response.ErrorMessage);
                return null;
            }
            return Response.Data[0];
        }
    }
}

