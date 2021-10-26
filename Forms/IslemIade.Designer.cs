
namespace KantinX.Forms
{
    partial class IslemIade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IslemIade));
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelIslemTamamlandi = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelKartSahibi = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.panelIstemTamamlanamadi = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelIslemTamamlandi)).BeginInit();
            this.panelIslemTamamlandi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelIstemTamamlanamadi)).BeginInit();
            this.panelIstemTamamlanamadi.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCardNumber.Location = new System.Drawing.Point(40, 177);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(374, 39);
            this.txtCardNumber.TabIndex = 0;
            this.txtCardNumber.TextChanged += new System.EventHandler(this.txtCardNumber_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(118, 87);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(226, 70);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "İADE EDECEĞİNİZ\r\nKARTI OKUTUNUZ.";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.LightGray;
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Controls.Add(this.labelControl3);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(10);
            this.topPanel.Size = new System.Drawing.Size(459, 58);
            this.topPanel.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClose.Location = new System.Drawing.Point(365, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnClose.Size = new System.Drawing.Size(84, 38);
            this.btnClose.TabIndex = 12;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl3.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelControl3.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(10, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(349, 29);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "İŞLEM İADE";
            // 
            // panelIslemTamamlandi
            // 
            this.panelIslemTamamlandi.Controls.Add(this.labelControl2);
            this.panelIslemTamamlandi.Location = new System.Drawing.Point(40, 291);
            this.panelIslemTamamlandi.Name = "panelIslemTamamlandi";
            this.panelIslemTamamlandi.Size = new System.Drawing.Size(374, 49);
            this.panelIslemTamamlandi.TabIndex = 18;
            this.panelIslemTamamlandi.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl2.ImageOptions.Image")));
            this.labelControl2.Location = new System.Drawing.Point(78, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(208, 32);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "       İŞLEM TAMAMLANDI";
            // 
            // labelKartSahibi
            // 
            this.labelKartSahibi.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKartSahibi.Appearance.Options.UseFont = true;
            this.labelKartSahibi.Location = new System.Drawing.Point(153, 224);
            this.labelKartSahibi.Name = "labelKartSahibi";
            this.labelKartSahibi.Size = new System.Drawing.Size(36, 29);
            this.labelKartSahibi.TabIndex = 4;
            this.labelKartSahibi.Text = "....";
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(52, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kart Sahibi:";
            // 
            // panelIstemTamamlanamadi
            // 
            this.panelIstemTamamlanamadi.Controls.Add(this.labelControl5);
            this.panelIstemTamamlanamadi.Controls.Add(this.labelControl4);
            this.panelIstemTamamlanamadi.Location = new System.Drawing.Point(40, 258);
            this.panelIstemTamamlanamadi.Name = "panelIstemTamamlanamadi";
            this.panelIstemTamamlanamadi.Size = new System.Drawing.Size(374, 105);
            this.panelIstemTamamlanamadi.TabIndex = 20;
            this.panelIstemTamamlanamadi.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(86, 55);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(208, 48);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "DAHA ÖNCE SON İŞLEMİ\r\n   İÇİN İADE YAPILMIŞ";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl4.ImageOptions.Image")));
            this.labelControl4.Location = new System.Drawing.Point(65, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(244, 32);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "       İŞLEM TAMAMLANAMADI";
            // 
            // IslemIade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 375);
            this.ControlBox = false;
            this.Controls.Add(this.labelKartSahibi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelIslemTamamlandi);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelIstemTamamlanamadi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "IslemIade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelIslemTamamlandi)).EndInit();
            this.panelIslemTamamlandi.ResumeLayout(false);
            this.panelIslemTamamlandi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelIstemTamamlanamadi)).EndInit();
            this.panelIstemTamamlanamadi.ResumeLayout(false);
            this.panelIstemTamamlanamadi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCardNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel topPanel;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelIslemTamamlandi;
        private DevExpress.XtraEditors.LabelControl labelKartSahibi;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelIstemTamamlanamadi;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}