using System;
using System.Windows.Forms;
using System.Collections.Generic;

using KantinX.Model;
using RestSharp;

namespace KantinX.Forms
{
    public partial class IslemIade : Form
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
        int KullaniciID;
        public IslemIade(AnaMenu anamenu, int KullaniciID)
        {
            InitializeComponent();
            this.anamenu = anamenu;
            this.KullaniciID = KullaniciID;
        }

        private void FormRefresh()
        {
            panelIslemTamamlandi.Visible = false;
            panelIstemTamamlanamadi.Visible = false;
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
                try
                {
                    OGRENCI ogrenci = GetOgrenci(txtCardNumber.Text);

                    ISLEM islem = new ISLEM();
                    islem.ISLEM_YAPAN_ID = KullaniciID;
                    islem.OGRENCI_ID = ogrenci.ID;
                    islem.ISLEM_TARIHI = DateTime.Now.AddHours(3);

                    var requestBody = new Dictionary<string, object>() {
                        { "islem", "İade" },
                        { "body", islem }
                    };

                    RestRequest postRequest = new RestRequest("setIslemler.php", Method.POST);
                    postRequest.RequestFormat = DataFormat.Json;
                    postRequest.AddJsonBody(SimpleJson.SerializeObject(requestBody));
                    IRestResponse Response = anamenu.Client.Execute(postRequest);

                    //if (!Response.IsSuccessful) NORMALDE ÇALIŞMASINA RAĞMEN SUCCESFUL FALSE DÖNÜYOR İNTERNAL SERVER ERROR VERİYOR
                    if (Response.ErrorMessage != null)
                    {
                        MessageBox.Show(Response.ErrorMessage);
                    }

                    labelKartSahibi.Text = ogrenci.OGRENCI_ADI + " " + ogrenci.OGRENCI_SOYADI;
                    if (Response.Content == "1")
                    {
                        panelIslemTamamlandi.Visible = true;
                    }
                    else
                    {
                        panelIstemTamamlanamadi.Visible = true;
                    }
                    anamenu.labelTutar.Text = "0,0 ₺";
                    anamenu.listHesap.Clear();
                    anamenu.dgwHesap.Columns.Clear();
                    anamenu.dgwHesap.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtCardNumber.Clear();
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

