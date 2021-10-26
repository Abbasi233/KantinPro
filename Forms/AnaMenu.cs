using System;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Deployment.Application;
using DevExpress.XtraEditors;

using KantinX.Forms;
using KantinX.Model;
using RestSharp;

namespace KantinX
{
    public partial class AnaMenu : XtraForm
    {
        public List<UrunHesap> listHesap;

        KULLANICI Kullanici;
        List<URUN> ListUrun;
        List<KATEGORI> ListKategori;
        DataGridViewButtonColumn artirColumn;
        DataGridViewButtonColumn eksiltColumn;

        public RestClient Client;
        public RestRequest Request;

        public AnaMenu(KULLANICI Kullanici)
        {
            InitializeComponent();
            this.Kullanici = Kullanici;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                labelBaslik.Text += " (v" + ad.CurrentVersion.ToString() + ")";
                labelBaslik2.Text = "| Anasayfa - " + Kullanici.USERNAME;
            }

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Client = new RestClient("https://kantinx.insoft.com.tr/kantin/API/");
            Request = new RestRequest(Method.GET);
            Request.RequestFormat = DataFormat.Json;
            Request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json; charset=UTF-8"; };

            GetKategoriler();

            ListUrun = new List<URUN>();
            listHesap = new List<UrunHesap>();
            #region DATAGRİD COLUMNS
            artirColumn = new DataGridViewButtonColumn();
            artirColumn.CellTemplate = new DataGridViewButtonCell();
            artirColumn.UseColumnTextForButtonValue = true;
            artirColumn.HeaderText = "Artır";
            artirColumn.Text = "+";

            eksiltColumn = new DataGridViewButtonColumn();
            eksiltColumn.CellTemplate = new DataGridViewButtonCell();
            eksiltColumn.UseColumnTextForButtonValue = true;
            eksiltColumn.HeaderText = "Eksilt";
            eksiltColumn.Text = "-";
            #endregion
        }

        public void GetKategoriler()
        {
            Request.Resource = "getKategoriler.php";
            IRestResponse<List<KATEGORI>> Response = Client.Execute<List<KATEGORI>>(Request);

            if (Response.IsSuccessful)
            {
                ListKategori = Response.Data;
                KategorileriListele();
            }
            else
                MessageBox.Show(Response.ErrorMessage);
        }
        private List<URUN> GetUrunler(string parameterID, string parameter)
        {
            Request.Resource = "getUrunler.php";
            Request.Parameters.Clear();
            Request.AddParameter(parameterID, parameter);
            IRestResponse<List<URUN>> Response = Client.Execute<List<URUN>>(Request);

            if (!Response.IsSuccessful)
            {
                MessageBox.Show(Response.ErrorMessage);
                return null;
            }
            return Response.Data;
        }

        private void KategorileriListele()
        {
            tableKategoriler.Controls.Clear();
            foreach (KATEGORI kategori in ListKategori)
            {
                SimpleButton btnKategori = new SimpleButton();
                btnKategori.Name = "btnKategori" + kategori.ID;
                btnKategori.Text = kategori.KATEGORI_ADI;
                btnKategori.ShowToolTips = false;
                btnKategori.ToolTip = kategori.ID.ToString();
                btnKategori.Font = new Font("Trebuchet MS", 14);
                btnKategori.Dock = DockStyle.Fill;
                btnKategori.Click += btnKategori_Click;
                tableKategoriler.Controls.Add(btnKategori);
            }
        }

        private void AnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz?", "Çıkış", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            e.Cancel = (sonuc == DialogResult.Cancel);
        }

        private void AnaMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton kategori = sender as SimpleButton;
                flowUrunler.Controls.Clear();
                ListUrun = GetUrunler("kategoriID", kategori.ToolTip);

                foreach (URUN urun in ListUrun)
                {
                    SimpleButton btnUrun = new SimpleButton();
                    btnUrun.Name = "btnUrun" + urun.ID;
                    btnUrun.Text = urun.URUN_ADI + "\n" + urun.BIRIM_FIYATI.Format() + " ₺";
                    btnUrun.ShowToolTips = false;
                    btnUrun.ToolTip = urun.ID.ToString();
                    btnUrun.Font = new Font("Trebuchet MS", 14);
                    btnUrun.Size = new Size(200, 100);
                    btnUrun.Click += Urun_Click;
                    flowUrunler.Controls.Add(btnUrun);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Urun_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton button = sender as SimpleButton;
                URUN urun = ListUrun.Where(x => x.ID.ToString() == button.ToolTip).Single();
                UrunHesap urunHesap = new UrunHesap(urun, 1);

                ListUrunEkle(urunHesap);
                DataGridDuzenle();
                LabelTutarGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListUrunEkle(UrunHesap urunHesap)
        {
            int findIndex = listHesap.FindIndex(x => x.ID == urunHesap.ID);

            if (findIndex != -1)
            {
                listHesap[findIndex].Adet++;
                listHesap[findIndex].ToplamFiyat = listHesap[findIndex].BirimFiyat * listHesap[findIndex].Adet;
            }
            else
                listHesap.Add(urunHesap);
        }

        public void DataGridDuzenle()
        {
            dgwHesap.Columns.Clear();
            dgwHesap.DataSource = null;
            dgwHesap.DataSource = listHesap;

            dgwHesap.Columns.Insert(3, artirColumn);
            dgwHesap.Columns.Insert(5, eksiltColumn);

            dgwHesap.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgwHesap.RowCount > 0)
                dgwHesap.FirstDisplayedScrollingRowIndex = dgwHesap.RowCount - 1;
        }

        private void LabelTutarGuncelle()
        {
            decimal ToplamTutar = listHesap.Sum(x => x.ToplamFiyat);
            labelTutar.Text = ToplamTutar.Format() + " ₺";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTanimlama_Click(object sender, EventArgs e)
        {
            if (Kullanici.YETKI == 0)
            {
                Enabled = false;
                Islemler islemler = new Islemler(this);
                islemler.Show();
            }
            else
                MessageBox.Show("Bu işlemi gerçekleştirebilmek için yetkiniz bulunmamaktadır.", "Geçersiz Yetki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnHesapTemizle_Click(object sender, EventArgs e)
        {
            labelTutar.Text = "0,0 ₺";
            listHesap.Clear();
            dgwHesap.Columns.Clear();
            dgwHesap.DataSource = null;
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (listHesap.Count > 0)
            {
                Enabled = false;
                Odeme odeme = new Odeme(this, Kullanici.ID, labelTutar.Text);
                odeme.Show();
            }
        }

        private void btnBakiyeSorgula_Click(object sender, EventArgs e)
        {
            Enabled = false;
            BakiyeSorgula bakiyeSorgula = new BakiyeSorgula(this);
            bakiyeSorgula.Show();
        }

        private void btnIslemIade_Click(object sender, EventArgs e)
        {
            Enabled = false;
            IslemIade bakiyeSorgula = new IslemIade(this, Kullanici.ID);
            bakiyeSorgula.Show();
        }

        private void btnRaporlama_Click(object sender, EventArgs e)
        {
            if (Kullanici.YETKI == 0)
            {
                MessageBox.Show("Çok yakında...");
            }
            else
                MessageBox.Show("Bu işlemi gerçekleştirebilmek için yetkiniz bulunmamaktadır.", "Geçersiz Yetki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgwHesap_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    bool itemRemoved = false;
                    string selectedValue = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    UrunHesap urunKaydi = listHesap[e.RowIndex];

                    if (selectedValue == "+")
                        urunKaydi.Adet++;
                    else if (selectedValue == "-")
                    {
                        if (urunKaydi.Adet > 1)
                            urunKaydi.Adet--;
                        else
                        {
                            listHesap.Remove(urunKaydi);
                            itemRemoved = true;
                        }
                    }

                    if (listHesap.Count > 0 && !itemRemoved)
                        urunKaydi.ToplamFiyat = urunKaydi.Adet * urunKaydi.BirimFiyat;

                    DataGridDuzenle();
                    LabelTutarGuncelle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {
            if (txtBarkod.Text.Length >= 13)
            {
                try
                {
                    List<URUN> urunler = GetUrunler("barkodNo", txtBarkod.Text);
                    if (urunler.Count == 1)
                    {
                        //listHesap.Add(new UrunHesap(urunler[0], 1));
                        UrunHesap urunHesap = new UrunHesap(urunler[0], 1);
                        ListUrunEkle(urunHesap);
                        DataGridDuzenle();
                        LabelTutarGuncelle();
                        txtBarkod.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}