using System;
using System.Windows.Forms;
using System.Collections.Generic;

using KantinX.Model;
using RestSharp;

namespace KantinX.Forms
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

        int KullaniciID;
        decimal Tutar;
        AnaMenu anamenu;

        public Odeme(AnaMenu anamenu, int KullaniciID, string Tutar)
        {
            InitializeComponent();
            try
            {
                this.anamenu = anamenu;
                this.KullaniciID = KullaniciID;
                this.Tutar = Convert.ToDecimal(Tutar.Split(' ')[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormRefresh()
        {
            panelIslemTamamlandi.Visible = panelBakiyeYetersiz.Visible = false;
            labelBakiyeYetersizTutar.Text = "0,0 ₺";
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
                    List<ISLEM> listIslemler = new List<ISLEM>();
                    OGRENCI ogrenci = GetOgrenci(txtCardNumber.Text);

                    if (ogrenci.BAKIYE >= Tutar)
                    {
                        ogrenci.BAKIYE -= Tutar;
                        labelIslemTamamTutar.Text = ogrenci.BAKIYE.Format();

                        anamenu.listHesap.ForEach(x =>
                        {
                            ISLEM islem = new ISLEM();
                            islem.ISLEM_YAPAN_ID = KullaniciID;
                            islem.OGRENCI_ID = ogrenci.ID;
                            islem.URUN_ID = x.ID;
                            islem.ADET = x.Adet;
                            islem.TOPLAM = x.ToplamFiyat;
                            islem.ISLEM_TARIHI = DateTime.Now.AddHours(3);

                            listIslemler.Add(islem);
                        });

                        var requestBody = new Dictionary<string, object>() {
                            { "islem", "Satış"},
                            { "body", listIslemler }
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

                        panelIslemTamamlandi.Visible = true;
                        anamenu.labelTutar.Text = "0,0 ₺";
                        anamenu.listHesap.Clear();
                        anamenu.dgwHesap.Columns.Clear();
                        anamenu.dgwHesap.DataSource = null;
                    }
                    else
                    {
                        labelBakiyeYetersizTutar.Text = ogrenci.BAKIYE.Format();
                        panelBakiyeYetersiz.Visible = true;
                    }
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
