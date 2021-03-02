using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using KantinPro.Database;

namespace KantinPro
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

        KantinProDataContext db;
        List<OGRENCILER> listOgrenciler;
        List<OGRENCILER> filteredOgrenciler;

        public Islemler()
        {
            InitializeComponent();
            db = SingletonContext.nesne();
            listOgrenciler = db.OGRENCILER.ToList();
            filteredOgrenciler = new List<OGRENCILER>();
        }

        private void Islemler_Load(object sender, EventArgs e)
        {
            dgwOgrenciler.DataSource = listOgrenciler;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {
            txtCardNumber.Enabled = chkCard.Checked;
            txtName.Enabled = txtSurname.Enabled = !chkCard.Checked;
        }

        private void txtCardNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCardNumber.Text.Length == 10)
            {
                dgwOgrenciler.DataSource = listOgrenciler
                        .Where(x => x.CARD_ID == txtCardNumber.Text).ToList();
                txtCardNumber.Text = "";
            }
            else if (txtCardNumber.Text.Length == 0)
                dgwOgrenciler.DataSource = listOgrenciler;
        }

        private List<OGRENCILER> Filter(String textbox, KeyEventArgs e)
        {
            MessageBox.Show(((char)e.KeyValue).ToString());
            //if (filteredOgrenciler.Count == 0)
            //    filteredOgrenciler = listOgrenciler;

            //if (e.KeyCode != Keys.Back)
            //{
            //    switch (textbox)
            //    {
            //        case "CardNumber":
            //            filteredOgrenciler = filteredOgrenciler.Where(x => x.CARD_ID.ToString().Contains(txtCardNumber.Text)).ToList();
            //            break;
            //        case "Name":
            //            filteredOgrenciler = filteredOgrenciler.Where(x => x.OGRENCI_ADI.ToString().Contains(txtName.Text)).ToList();
            //            break;
            //        case "Surname":
            //            filteredOgrenciler = filteredOgrenciler.Where(x => x.OGRENCI_SOYADI.ToString().Contains(txtSurname.Text)).ToList();
            //            break;
            //    }
            //}
            //else
            //{
            //    filteredOgrenciler = listOgrenciler
            //        .Where(x => x.CARD_ID.Contains(txtCardNumber.Text))
            //        .Where(x => x.OGRENCI_ADI.Contains(txtName.Text))
            //        .Where(x => x.OGRENCI_SOYADI.Contains(txtSurname.Text))
            //        .ToList();
            //}
            return filteredOgrenciler;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            dgwOgrenciler.DataSource = Filter("asdf", e);
        }
    }
}
