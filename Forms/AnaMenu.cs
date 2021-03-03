using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;

using KantinPro.Database;
using KantinPro.Forms;

namespace KantinPro
{
    public partial class AnaMenu : XtraForm
    {
        KantinProDataContext db;
        List<URUNLER> listUrunler;
        List<UrunKaydi> listHesap;
        List<KATEGORILER> listKategoriler;
        DataGridViewButtonColumn artirColumn;
        DataGridViewButtonColumn eksiltColumn;

        public AnaMenu()
        {
            InitializeComponent();
            db = SingletonContext.nesne();
            listKategoriler = db.KATEGORILER.ToList();
            listUrunler = db.URUNLER.ToList();
            listHesap = new List<UrunKaydi>();

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
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            foreach (KATEGORILER kategori in listKategoriler)
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
            SimpleButton kategori = sender as SimpleButton;
            UrunleriGetir(int.Parse(kategori.ToolTip));
        }

        private void UrunleriGetir(int KategoriID)
        {
            try
            {
                flowUrunler.Controls.Clear();
                List<URUNLER> urunler = listUrunler.Where(x => x.KATEGORI_ID == KategoriID).ToList();

                foreach (URUNLER urun in urunler)
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
            SimpleButton button = sender as SimpleButton;
            URUNLER urun = listUrunler.Where(x => x.ID.ToString() == button.ToolTip).FirstOrDefault();
            listHesap.Add(new UrunKaydi(urun.URUN_ADI, urun.BIRIM_FIYATI, 1));

            DataGridDuzenle();
            LabelTutarGuncelle();
        }

        private void DataGridDuzenle()
        {
            dgwHesap.Columns.Clear();
            dgwHesap.DataSource = null;
            dgwHesap.DataSource = listHesap;

            dgwHesap.Columns.Insert(3, artirColumn);
            dgwHesap.Columns.Insert(5, eksiltColumn);

            dgwHesap.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LabelTutarGuncelle()
        {
            decimal ToplamTutar = listHesap.Sum(x => x.ToplamFiyat);
            labelTutar.Text = ToplamTutar.Format() + " ₺";
        }

        private void dgwHesap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    bool itemRemoved = false;
                    string selectedValue = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    UrunKaydi urunKaydi = listHesap[e.RowIndex];

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTanimlama_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Islemler islemler = new Islemler(this);
            islemler.Show();
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (listHesap.Count > 0)
            {
                Enabled = false;
                Odeme odeme = new Odeme(this, labelTutar.Text);
                odeme.Show();
            }
        }
    }

    class UrunKaydi
    {
        public string Isim { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
        public int Adet { get; set; }

        public UrunKaydi(string Isim, decimal BirimFiyat, int Adet)
        {
            this.Isim = Isim;
            this.BirimFiyat = BirimFiyat;
            this.ToplamFiyat = Adet * BirimFiyat;
            this.Adet = Adet;
        }
    }
}