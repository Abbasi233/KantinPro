using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Data.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraTab;
using Microsoft.VisualBasic;

using KantinX.Model;
using RestSharp;

namespace KantinX
{
    public partial class Islemler : Form
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
        string SecilenIslem;
        XtraTabPage SelectedTabPage;

        List<URUN> ListUrunler;
        List<URUN> FilteredUrunler;
        List<OGRENCI> ListOgrenciler;
        List<OGRENCI> FilteredOgrenciler;
        List<KATEGORI> ListKategoriler;
        List<KATEGORI> FilteredKategoriler;

        public Islemler(AnaMenu anamenu)
        {
            InitializeComponent();

            this.anamenu = anamenu;
            ListUrunler = getUrunler();
            FilteredUrunler = new List<URUN>();
            ListOgrenciler = getOgrenciler();
            FilteredOgrenciler = new List<OGRENCI>();
            ListKategoriler = getKategoriler();
            FilteredKategoriler = new List<KATEGORI>();
        }

        #region CONTROLLERS
        private List<URUN> getUrunler()
        {
            anamenu.Request.Parameters.Clear();
            anamenu.Request.Resource = "getUrunler.php";
            IRestResponse<List<URUN>> Response = anamenu.Client.Execute<List<URUN>>(anamenu.Request);

            if (!Response.IsSuccessful)
            {
                MessageBox.Show(Response.ErrorMessage);
                return null;
            }
            return Response.Data;
        }

        private List<KATEGORI> getKategoriler()
        {
            anamenu.Request.Parameters.Clear();
            anamenu.Request.Resource = "getKategoriler.php";
            IRestResponse<List<KATEGORI>> Response = anamenu.Client.Execute<List<KATEGORI>>(anamenu.Request);

            if (!Response.IsSuccessful)
            {
                MessageBox.Show(Response.ErrorMessage);
                return null;
            }
            return Response.Data;
        }

        private List<OGRENCI> getOgrenciler()
        {
            anamenu.Request.Parameters.Clear();
            anamenu.Request.Resource = "getOgrenciler.php";
            IRestResponse<List<OGRENCI>> Response = anamenu.Client.Execute<List<OGRENCI>>(anamenu.Request);

            if (!Response.IsSuccessful)
            {
                MessageBox.Show(Response.ErrorMessage);
                return null;
            }
            return Response.Data;
        }
        #endregion

        #region ISLEMLER FORM
        private void Islemler_Load(object sender, EventArgs e)
        {
            SelectedTabPage = tabIslemler.SelectedTabPage;
            dgwUrunler.DataSource = ListUrunler;
            dgwOgrenciler.DataSource = ListOgrenciler;
            dgwKategoriler.DataSource = ListKategoriler;

            cmbUrunKategori.DataSource = ListKategoriler;
            cmbUrunKategori.ValueMember = "KATEGORI_ADI";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //ChangeSet changes = anamenu.DB.GetChangeSet();
            //if (changes.Inserts.Count > 0 || changes.Updates.Count > 0 || changes.Deletes.Count > 0)
            //{
            //    DialogResult dialog = MessageBox.Show("Değişiklikler mevcut. Kaydetmeden çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dialog == DialogResult.No)
            //        return;
            //}
            anamenu.GetKategoriler();
            anamenu.Enabled = true;
            this.Close();
        }

        private void tabIslemler_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (SecilenIslem != null)
            {
                e.Cancel = true;
                MessageBox.Show("Kayıt üzerinde değişiklik yaparken sekme değiştiremezsiniz. Öncelikle yaptığınız işlemi tamamlayın veya iptal edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabIslemler_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            SelectedTabPage = e.Page;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SecilenIslem = "New";
            PassiveForm(SecilenIslem, true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SecilenIslem = "Update";
            PassiveForm(SecilenIslem, true);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                switch (SelectedTabPage.Name)
                {
                    case "tabUrunler":
                        if (labelUrunID.Text != "")
                        {
                            DialogResult dialog = MessageBox.Show("Seçilen ürünü silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {
                                RestRequest postRequest = new RestRequest("setUrunler.php", Method.POST);
                                postRequest.RequestFormat = DataFormat.Json;
                                Dictionary<string, object> Body = new Dictionary<string, object>() {
                                    { "islem", "Delete" },
                                    { "body", labelUrunID.Text }
                                };
                                postRequest.AddJsonBody(SimpleJson.SerializeObject(Body));
                                IRestResponse yeniResponse = anamenu.Client.Execute(postRequest);

                                if (yeniResponse.Content == "1")
                                {
                                    URUN urun = ListUrunler.Where(x => x.ID.ToString() == labelUrunID.Text).FirstOrDefault();
                                    ListUrunler.Remove(urun);
                                    FilteredUrunler.Remove(urun);
                                    DgwRefresh();
                                    PassiveForm("New", false);
                                    MessageBox.Show("Ürün başarıyla silindi.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Ürün silinirken bir hata oluştu.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                            MessageBox.Show("Öncelikle bir kayıt seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "tabKategoriler":
                        if (labelKategoriID.Text != "")
                        {
                            DialogResult dialog = MessageBox.Show("Seçilen kategoriyi silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {
                                RestRequest postRequest = new RestRequest("setKategoriler.php", Method.POST);
                                postRequest.RequestFormat = DataFormat.Json;
                                Dictionary<string, object> Body = new Dictionary<string, object>() {
                                    { "islem", "Delete" },
                                    { "body", labelKategoriID.Text }
                                };
                                postRequest.AddJsonBody(SimpleJson.SerializeObject(Body));
                                IRestResponse yeniResponse = anamenu.Client.Execute(postRequest);

                                if (yeniResponse.Content == "1")
                                {
                                    KATEGORI kategori = ListKategoriler.Where(x => x.ID.ToString() == labelKategoriID.Text).FirstOrDefault();
                                    ListKategoriler.Remove(kategori);
                                    FilteredKategoriler.Remove(kategori);
                                    DgwRefresh();
                                    PassiveForm("New", false);
                                    MessageBox.Show("Kategori başarıyla silindi.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Kategori silinirken bir hata oluştu.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                            MessageBox.Show("Öncelikle bir kayıt seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "tabOgrenciler":
                        if (labelOgrenciID.Text != "")
                        {
                            DialogResult dialog = MessageBox.Show("Seçilen öğrenciyi silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {
                                RestRequest postRequest = new RestRequest("setOgrenciler.php", Method.POST);
                                postRequest.RequestFormat = DataFormat.Json;
                                Dictionary<string, object> Body = new Dictionary<string, object>() {
                                    { "islem", "Delete" },
                                    { "body", labelOgrenciID.Text }
                                };
                                postRequest.AddJsonBody(SimpleJson.SerializeObject(Body));
                                IRestResponse yeniResponse = anamenu.Client.Execute(postRequest);

                                if (yeniResponse.Content == "1")
                                {
                                    OGRENCI ogrenci = ListOgrenciler.Where(x => x.ID.ToString() == labelOgrenciID.Text).FirstOrDefault();
                                    ListOgrenciler.Remove(ogrenci);
                                    FilteredOgrenciler.Remove(ogrenci);
                                    DgwRefresh();
                                    PassiveForm("New", false);
                                    MessageBox.Show("Öğrenci başarıyla silindi.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Öğrenci silinirken bir hata oluştu.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                            MessageBox.Show("Öncelikle bir kayıt seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region BASE METHODS
        private void DgwRefresh()
        {
            switch (SelectedTabPage.Name)
            {
                case "tabUrunler":
                    dgwUrunler.DataSource = null;
                    dgwUrunler.DataSource = FilteredUrunler.Count > 0 ? FilteredUrunler : ListUrunler;
                    break;
                case "tabKategoriler":
                    dgwKategoriler.DataSource = null;
                    dgwKategoriler.DataSource = FilteredKategoriler.Count > 0 ? FilteredKategoriler : ListKategoriler;
                    break;
                case "tabOgrenciler":
                    dgwOgrenciler.DataSource = null;
                    dgwOgrenciler.DataSource = FilteredOgrenciler.Count > 0 ? FilteredOgrenciler : ListOgrenciler;
                    break;
            }
        }

        private void PassiveForm(string sender, bool value)
        {
            topPanel.Enabled = !value;
            switch (SelectedTabPage.Name)
            {
                case "tabUrunler":
                    if (sender == "New")
                    {
                        labelUrunID.Text = null;
                        txtUrunBirimFiyat.Text = "";
                        cmbUrunKategori.Text = txtUrunAdi.Text = txtUrunBarkodNumarasi.Text = "";
                    }
                    else
                    {
                        txtUrunBirimFiyat.Text = (value) ? txtUrunBirimFiyat.Text.Split(' ')[0] : txtUrunBirimFiyat.Text + " ₺";
                    }
                    grupUrunBilgileri.Enabled = tableUrunTamamVazgec.Enabled = value;
                    grupFiltreUrun.Enabled = dgwUrunler.Enabled = tableBottomBar.Enabled = !value;
                    break;
                case "tabKategoriler":
                    if (sender == "New")
                    {
                        labelKategoriID.Text = null;
                        txtKategoriAdi.Text = "";
                    }
                    tableKategoriBilgileri.Enabled = value;
                    grupFiltreKategori.Enabled = dgwKategoriler.Enabled = tableBottomBar.Enabled = !value;
                    break;
                case "tabOgrenciler":
                    if (sender == "New")
                    {
                        labelOgrenciID.Text = null;
                        txtOgrenciBakiye.Text = "0,00 ₺";
                        txtOgrenciAdi.Text = txtOgrenciSoyadi.Text = txtKartNumarasi.Text = "";
                    }
                    else
                    {
                        txtOgrenciBakiye.Text = (value) ? txtOgrenciBakiye.Text.Split(' ')[0] : txtOgrenciBakiye.Text + " ₺";
                    }
                    grupOgrenciBilgileri.Enabled = tableTamamVazgec.Enabled = value;
                    grupFilter.Enabled = dgwOgrenciler.Enabled = tableBottomBar.Enabled = !value;
                    break;
            }
            if (!value)
                SecilenIslem = null;
        }
        #endregion

        #region URUNLER PAGE
        private void chkFiltreUrunBarkodNumarasi_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFiltreUrunBarkodNumarasi.Checked)
            {
                cmbFiltreUrunKategori.ValueMember = "KATEGORI_ADI";
                cmbFiltreUrunKategori.DataSource = ListKategoriler;
                chkFiltreUrunBarkodNumarasi.Appearance.BackColor = Color.Gray;
            }
            else
            {
                cmbFiltreUrunKategori.DataSource = null;
                cmbFiltreUrunKategori.ValueMember = null;
                dgwUrunler.DataSource = ListUrunler;
                chkFiltreUrunBarkodNumarasi.Appearance.BackColor = Color.LightBlue;
            }

            txtFiltreUrunBarkodNo.Enabled = chkFiltreUrunBarkodNumarasi.Checked;
            cmbFiltreUrunKategori.Enabled = txtFiltreUrunAdi.Enabled = txtFiltreUrunBirimFiyati.Enabled = !chkFiltreUrunBarkodNumarasi.Checked;
        }

        private void cmbFiltreUrunKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltreUrunKategori.SelectedIndex >= 0)
            {
                int kategoriID = ListKategoriler[cmbFiltreUrunKategori.SelectedIndex].ID;
                FilteredUrunler = ListUrunler.Where(x => x.KATEGORI_ID == kategoriID).ToList();
                dgwUrunler.DataSource = FilteredUrunler;
            }
        }

        private void txtFiltreUrunBarkodNo_TextChanged(object sender, EventArgs e)
        {
            //if (txtFiltreUrunBarkodNo.Text.Length > 5)
            //{
            FilteredUrunler = ListUrunler.Where(x => x.BARKOD_NO.ToString() == txtFiltreUrunBarkodNo.Text).ToList();
            dgwUrunler.DataSource = FilteredUrunler;

            //txtFiltreUrunBarkodNo.Clear();
            //}
        }

        private void txtFiltreUrunAdi_KeyUp(object sender, KeyEventArgs e)
        {
            dgwUrunler.DataSource = UrunFilter("UrunAdi", e);
        }

        private void txtFiltreUrunBirimFiyati_KeyUp(object sender, KeyEventArgs e)
        {
            dgwUrunler.DataSource = UrunFilter("BarkodNo", e);
        }

        private void btnUrunTamam_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrunAdi.Text.Trim() != "" && txtUrunBarkodNumarasi.Text.Trim() != "")
                {
                    RestRequest postRequest = new RestRequest("setUrunler.php", Method.POST);
                    postRequest.RequestFormat = DataFormat.Json;

                    switch (SecilenIslem)
                    {
                        case "New":
                            URUN yeniUrun = new URUN();
                            decimal yeniBirimFiyat;
                            int yeniStok;
                            if (!decimal.TryParse(txtUrunBirimFiyat.Text, out yeniBirimFiyat))
                            {
                                MessageBox.Show("Birim fiyatı kısmına doğru bir değer girmediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (!int.TryParse(txtUrunStok.Text, out yeniStok))
                            {
                                MessageBox.Show("Stok adeti kısmına doğru bir değer girmediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            yeniUrun.ID = 0;
                            yeniUrun.KATEGORI_ID = ListKategoriler[cmbUrunKategori.SelectedIndex].ID;
                            yeniUrun.URUN_ADI = txtUrunAdi.Text;
                            yeniUrun.BARKOD_NO = txtUrunBarkodNumarasi.Text;
                            yeniUrun.BIRIM_FIYATI = yeniBirimFiyat;
                            yeniUrun.STOK = yeniStok;

                            Dictionary<string, object> yeniBody = new Dictionary<string, object>() {
                                { "islem", SecilenIslem },
                                { "body", yeniUrun }
                            };
                            postRequest.AddJsonBody(SimpleJson.SerializeObject(yeniBody));
                            IRestResponse yeniResponse = anamenu.Client.Execute(postRequest);

                            ListUrunler.Add(yeniUrun);
                            if (yeniResponse.Content == "1")
                                MessageBox.Show("Kayıt başarıyla eklendi.", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Kayıt eklenirken bir hata oluştu.", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case "Update":
                            URUN urun = ListUrunler.Where(x => x.ID.ToString() == labelUrunID.Text).FirstOrDefault();
                            decimal birimFiyat;
                            int stok;
                            if (!decimal.TryParse(txtUrunBirimFiyat.Text, out birimFiyat))
                            {
                                MessageBox.Show("Birim fiyatı kısmına doğru bir değer girmediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (!int.TryParse(txtUrunStok.Text, out stok))
                            {
                                MessageBox.Show("Stok adeti kısmına doğru bir değer girmediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            urun.ID = int.Parse(labelUrunID.Text);
                            urun.KATEGORI_ID = ListKategoriler[cmbUrunKategori.SelectedIndex].ID;
                            urun.URUN_ADI = txtUrunAdi.Text;
                            urun.BARKOD_NO = txtUrunBarkodNumarasi.Text;
                            urun.BIRIM_FIYATI = birimFiyat;
                            urun.STOK = stok;

                            Dictionary<string, object> body = new Dictionary<string, object>() {
                                { "islem", SecilenIslem },
                                { "body", urun }
                            };
                            postRequest.AddJsonBody(SimpleJson.SerializeObject(body));
                            IRestResponse Response = anamenu.Client.Execute(postRequest);

                            if (Response.Content == "1")
                                MessageBox.Show("Kayıt başarıyla güncellendi.", "Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                throw new Exception("Kayıt güncellenirken bir hata oluştu.");
                            break;
                    }
                    DgwRefresh();
                    PassiveForm(SecilenIslem, false);
                }
                else
                    MessageBox.Show("Tüm alanları doldurmanız gerekmektedir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kayıt Eklenirken Bir Sorun Oluştu");
            }
        }

        private void btnUrunVazgec_Click(object sender, EventArgs e)
        {
            PassiveForm(SecilenIslem, false);
        }

        private void dgwUrunler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cmbUrunKategori.DataSource = ListKategoriler;
                cmbUrunKategori.ValueMember = "KATEGORI_ADI";

                URUN urun = FilteredUrunler.Count == 0 ? ListUrunler[e.RowIndex] : FilteredUrunler[e.RowIndex];
                labelUrunID.Text = urun.ID.ToString();
                cmbUrunKategori.SelectedIndex = ListKategoriler.FindIndex(x => x.ID == urun.KATEGORI_ID);
                txtUrunAdi.Text = urun.URUN_ADI;
                txtUrunBarkodNumarasi.Text = urun.BARKOD_NO.ToString();
                txtUrunBirimFiyat.Text = urun.BIRIM_FIYATI.Format() + " ₺";
                txtUrunStok.Text = urun.STOK.ToString();
                //labelUrunBirimFiyati.Text = urun.BIRIM_FIYATI.Format() + " ₺";
            }
        }

        private List<URUN> UrunFilter(string textbox, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back)
            {
                switch (textbox)
                {
                    case "UrunAdi":
                        if (FilteredUrunler.Count == 0)
                            FilteredUrunler = ListUrunler.Where(x => x.URUN_ADI.ToLower().Contains(txtFiltreUrunAdi.Text)).ToList();
                        else
                            FilteredUrunler = FilteredUrunler.Where(x => x.URUN_ADI.ToLower().Contains(txtFiltreUrunAdi.Text)).ToList();
                        break;
                    case "BarkodNo":
                        if (FilteredUrunler.Count == 0)
                            FilteredUrunler = ListUrunler.Where(x => x.BIRIM_FIYATI.ToString().Contains(txtFiltreUrunBirimFiyati.Text)).ToList();
                        else
                            FilteredUrunler = FilteredUrunler.Where(x => x.BIRIM_FIYATI.ToString().Contains(txtFiltreUrunBirimFiyati.Text)).ToList();
                        break;
                }
            }
            else
            {
                if (txtFiltreUrunAdi.Text.Length != 0 || txtFiltreUrunBarkodNo.Text.Length != 0)
                    FilteredUrunler = ListUrunler
                        .Where(x => x.URUN_ADI.ToLower().Contains(txtFiltreUrunAdi.Text))
                        .Where(x => x.BARKOD_NO.ToString().Contains(txtFiltreUrunBarkodNo.Text))
                        .Where(x => x.KATEGORI_ID == ListKategoriler[cmbFiltreUrunKategori.SelectedIndex].ID)
                        .ToList();
                else
                {
                    FilteredUrunler = ListUrunler.Where(x => x.KATEGORI_ID == ListKategoriler[cmbFiltreUrunKategori.SelectedIndex].ID).ToList();
                }
            }
            return FilteredUrunler;
        }
        #endregion

        #region OGRENCILER PAGE
        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {            
            if (!chkOgrenciKartNumarasi.Checked)
            {
                chkFiltreUrunBarkodNumarasi.Appearance.BackColor = Color.Gray;
            }
            else
            {
                dgwOgrenciler.DataSource = ListOgrenciler;
                chkOgrenciKartNumarasi.Appearance.BackColor = Color.LightBlue;
            }
            txtFiltreOgrenciKartNumarasi.Enabled = chkOgrenciKartNumarasi.Checked;
            txtFiltreOgrenciAdi.Enabled = txtFiltreOgrenciSoyadi.Enabled = !chkOgrenciKartNumarasi.Checked;
        }

        private void txtFiltreKartNumarasi_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltreOgrenciKartNumarasi.Text.Length == 10)
            {
                FilteredOgrenciler = ListOgrenciler.Where(x => x.KART_ID == txtFiltreOgrenciKartNumarasi.Text).ToList();
                dgwOgrenciler.DataSource = FilteredOgrenciler;

                txtFiltreOgrenciKartNumarasi.Clear();
            }
        }

        private void txtFiltreOgrenciAdi_KeyUp(object sender, KeyEventArgs e)
        {
            dgwOgrenciler.DataSource = OgrenciFilter("Name", e);
        }

        private void txtFiltreOgrenciSoyadi_KeyUp(object sender, KeyEventArgs e)
        {
            dgwOgrenciler.DataSource = OgrenciFilter("Surname", e);
        }

        private List<OGRENCI> OgrenciFilter(string textbox, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back)
            {
                switch (textbox)
                {
                    case "Name":
                        if (FilteredOgrenciler.Count == 0)
                            FilteredOgrenciler = ListOgrenciler.Where(x => x.OGRENCI_ADI.ToLower().Contains(txtFiltreOgrenciAdi.Text)).ToList();
                        else
                            FilteredOgrenciler = FilteredOgrenciler.Where(x => x.OGRENCI_ADI.ToLower().Contains(txtFiltreOgrenciAdi.Text)).ToList();
                        break;
                    case "Surname":
                        if (FilteredOgrenciler.Count == 0)
                            FilteredOgrenciler = ListOgrenciler.Where(x => x.OGRENCI_SOYADI.ToLower().Contains(txtFiltreOgrenciSoyadi.Text)).ToList();
                        else
                            FilteredOgrenciler = FilteredOgrenciler.Where(x => x.OGRENCI_SOYADI.ToLower().Contains(txtFiltreOgrenciSoyadi.Text)).ToList();
                        break;
                }
            }
            else
            {
                if (txtFiltreOgrenciAdi.Text.Length != 0 || txtFiltreOgrenciSoyadi.Text.Length != 0)
                    FilteredOgrenciler = ListOgrenciler
                        .Where(x => x.OGRENCI_ADI.ToLower().Contains(txtFiltreOgrenciAdi.Text))
                        .Where(x => x.OGRENCI_SOYADI.ToLower().Contains(txtFiltreOgrenciSoyadi.Text))
                        .ToList();
                else
                {
                    FilteredOgrenciler.Clear();
                    return ListOgrenciler;
                }
            }
            return FilteredOgrenciler;
        }

        private void dgwOgrenciler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OGRENCI ogrenci = FilteredOgrenciler.Count == 0 ? ListOgrenciler[e.RowIndex] : FilteredOgrenciler[e.RowIndex];
                labelOgrenciID.Text = ogrenci.ID.ToString();
                txtOgrenciAdi.Text = ogrenci.OGRENCI_ADI;
                txtOgrenciSoyadi.Text = ogrenci.OGRENCI_SOYADI;
                txtKartNumarasi.Text = ogrenci.KART_ID;
                txtOgrenciBakiye.Text = ogrenci.BAKIYE.Format() + " ₺";
            }
        }

        private void btnOgrenciTamam_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOgrenciAdi.Text.Trim() != "" && txtOgrenciSoyadi.Text.Trim() != "" && txtKartNumarasi.Text.Trim() != "")
                {
                    RestRequest postRequest = new RestRequest("setOgrenciler.php", Method.POST);
                    postRequest.RequestFormat = DataFormat.Json;

                    switch (SecilenIslem)
                    {
                        case "New":
                            OGRENCI yeniOgrenci = new OGRENCI();
                            decimal yeniBirimFiyat;
                            if (!decimal.TryParse(txtOgrenciBakiye.Text, out yeniBirimFiyat))
                            {
                                MessageBox.Show("Doğru bir değer girmediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            yeniOgrenci.KART_ID = txtKartNumarasi.Text;
                            yeniOgrenci.OGRENCI_ADI = txtOgrenciAdi.Text;
                            yeniOgrenci.OGRENCI_SOYADI = txtOgrenciSoyadi.Text;
                            yeniOgrenci.BAKIYE = yeniBirimFiyat;

                            Dictionary<string, object> yeniBody = new Dictionary<string, object>() {
                                { "islem", SecilenIslem },
                                { "body", yeniOgrenci }
                            };
                            postRequest.AddJsonBody(SimpleJson.SerializeObject(yeniBody));
                            IRestResponse yeniResponse = anamenu.Client.Execute(postRequest);

                            ListOgrenciler.Add(yeniOgrenci);
                            if (yeniResponse.Content == "1")
                                MessageBox.Show("Kayıt başarıyla eklendi.", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Kayıt eklenirken bir hata oluştu.", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case "Update":
                            decimal birimFiyat;
                            if (!decimal.TryParse(txtOgrenciBakiye.Text, out birimFiyat))
                            {
                                MessageBox.Show("Doğru bir para birimi girmediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            OGRENCI ogrenci = ListOgrenciler.Where(x => x.ID.ToString() == labelOgrenciID.Text).FirstOrDefault();
                            ogrenci.KART_ID = txtKartNumarasi.Text;
                            ogrenci.OGRENCI_ADI = txtOgrenciAdi.Text;
                            ogrenci.OGRENCI_SOYADI = txtOgrenciSoyadi.Text;
                            ogrenci.BAKIYE = birimFiyat;

                            Dictionary<string, object> body = new Dictionary<string, object>() {
                                { "islem", SecilenIslem },
                                { "body", ogrenci }
                            };
                            postRequest.AddJsonBody(SimpleJson.SerializeObject(body));
                            IRestResponse Response = anamenu.Client.Execute(postRequest);

                            if (Response.Content == "1")
                                MessageBox.Show("Kayıt başarıyla güncellendi.", "Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Kayıt güncellenirken bir hata oluştu.", "Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    DgwRefresh();
                    PassiveForm(SecilenIslem, false);
                }
                else
                {
                    MessageBox.Show("Tüm alanları doldurmanız gerekmektedir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kayıt Eklenirken Bir Sorun Oluştu");
            }
        }

        private void btnOgrenciVazgec_Click(object sender, EventArgs e)
        {
            PassiveForm(SecilenIslem, false);
        }
        #endregion

        #region KATEGORILER PAGE
        private void txtFiltreKategoriAdi_KeyUp(object sender, KeyEventArgs e)
        {
            dgwKategoriler.DataSource = KategoriFilter(e);
        }

        private List<KATEGORI> KategoriFilter(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back)
            {
                if (FilteredKategoriler.Count == 0)
                    FilteredKategoriler = ListKategoriler.Where(x => x.KATEGORI_ADI.ToLower().Contains(txtFiltreKategoriAdi.Text)).ToList();
                else
                    FilteredKategoriler = FilteredKategoriler.Where(x => x.KATEGORI_ADI.ToLower().Contains(txtFiltreKategoriAdi.Text)).ToList();
            }
            else
            {
                if (txtFiltreKategoriAdi.Text.Length != 0)
                    FilteredKategoriler = ListKategoriler
                        .Where(x => x.KATEGORI_ADI.ToLower().Contains(txtFiltreKategoriAdi.Text)).ToList();
                else
                {
                    FilteredKategoriler.Clear();
                    return ListKategoriler;
                }
            }
            return FilteredKategoriler;
        }

        private void btnKategoriTamam_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKategoriAdi.Text.Trim() != "")
                {
                    RestRequest postRequest = new RestRequest("setKategoriler.php", Method.POST);
                    postRequest.RequestFormat = DataFormat.Json;

                    switch (SecilenIslem)
                    {
                        case "New":
                            KATEGORI yeniKategori = new KATEGORI();
                            yeniKategori.KATEGORI_ADI = txtKategoriAdi.Text;
                            Dictionary<string, object> yeniBody = new Dictionary<string, object>() {
                                { "islem", SecilenIslem },
                                { "body", yeniKategori }
                            };
                            postRequest.AddJsonBody(SimpleJson.SerializeObject(yeniBody));
                            IRestResponse yeniResponse = anamenu.Client.Execute(postRequest);
                            ListKategoriler.Add(yeniKategori);

                            if (yeniResponse.Content == "1")
                                MessageBox.Show("Kayıt başarıyla eklendi.", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Kayıt eklenirken bir hata oluştu.", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case "Update":
                            KATEGORI kategori = ListKategoriler.Where(x => x.ID.ToString() == labelKategoriID.Text).FirstOrDefault();
                            kategori.KATEGORI_ADI = txtKategoriAdi.Text;

                            Dictionary<string, object> body = new Dictionary<string, object>() {
                                { "islem", SecilenIslem },
                                { "body", kategori }
                            };
                            postRequest.AddJsonBody(SimpleJson.SerializeObject(body));
                            IRestResponse Response = anamenu.Client.Execute(postRequest);

                            if (Response.Content == "1")
                                MessageBox.Show("Kayıt başarıyla güncellendi.", "Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Kayıt güncellenirken bir hata oluştu.", "Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    DgwRefresh();
                    PassiveForm(SecilenIslem, false);
                }
                else
                {
                    MessageBox.Show("Tüm alanları doldurmanız gerekmektedir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kayıt Eklenirken Bir Sorun Oluştu");
            }
        }

        private void btnKategoriVazgec_Click(object sender, EventArgs e)
        {
            PassiveForm(SecilenIslem, false);
        }

        private void dgwKategoriler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                KATEGORI kategori = FilteredKategoriler.Count == 0 ? ListKategoriler[e.RowIndex] : FilteredKategoriler[e.RowIndex];
                labelKategoriID.Text = kategori.ID.ToString();
                txtKategoriAdi.Text = kategori.KATEGORI_ADI;
            }
        }
        #endregion
    }
}
