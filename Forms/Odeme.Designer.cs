
namespace KantinX.Forms
{
    partial class Odeme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Odeme));
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelIslemTamamlandi = new DevExpress.XtraEditors.PanelControl();
            this.labelIslemTamamTutar = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelBakiyeYetersiz = new DevExpress.XtraEditors.PanelControl();
            this.labelBakiyeYetersizTutar = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelIslemTamamlandi)).BeginInit();
            this.panelIslemTamamlandi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBakiyeYetersiz)).BeginInit();
            this.panelBakiyeYetersiz.SuspendLayout();
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
            this.labelControl1.Location = new System.Drawing.Point(40, 110);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(374, 35);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "ÖDEME İÇİN KARTI OKUTUNUZ.";
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
            this.labelControl3.Size = new System.Drawing.Size(98, 29);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "ÖDEME";
            // 
            // panelIslemTamamlandi
            // 
            this.panelIslemTamamlandi.Controls.Add(this.labelIslemTamamTutar);
            this.panelIslemTamamlandi.Controls.Add(this.labelControl5);
            this.panelIslemTamamlandi.Controls.Add(this.labelControl2);
            this.panelIslemTamamlandi.Location = new System.Drawing.Point(40, 234);
            this.panelIslemTamamlandi.Name = "panelIslemTamamlandi";
            this.panelIslemTamamlandi.Size = new System.Drawing.Size(374, 102);
            this.panelIslemTamamlandi.TabIndex = 18;
            this.panelIslemTamamlandi.Visible = false;
            // 
            // labelIslemTamamTutar
            // 
            this.labelIslemTamamTutar.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelIslemTamamTutar.Appearance.Options.UseFont = true;
            this.labelIslemTamamTutar.Location = new System.Drawing.Point(199, 62);
            this.labelIslemTamamTutar.Name = "labelIslemTamamTutar";
            this.labelIslemTamamTutar.Size = new System.Drawing.Size(58, 29);
            this.labelIslemTamamTutar.TabIndex = 2;
            this.labelIslemTamamTutar.Text = "0,0 ₺";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(98, 65);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(95, 22);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Kalan Bakiye:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl2.ImageOptions.Image")));
            this.labelControl2.Location = new System.Drawing.Point(81, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(208, 32);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "       İŞLEM TAMAMLANDI";
            // 
            // panelBakiyeYetersiz
            // 
            this.panelBakiyeYetersiz.Controls.Add(this.labelBakiyeYetersizTutar);
            this.panelBakiyeYetersiz.Controls.Add(this.labelControl4);
            this.panelBakiyeYetersiz.Location = new System.Drawing.Point(40, 251);
            this.panelBakiyeYetersiz.Name = "panelBakiyeYetersiz";
            this.panelBakiyeYetersiz.Size = new System.Drawing.Size(374, 66);
            this.panelBakiyeYetersiz.TabIndex = 19;
            this.panelBakiyeYetersiz.Visible = false;
            // 
            // labelBakiyeYetersizTutar
            // 
            this.labelBakiyeYetersizTutar.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBakiyeYetersizTutar.Appearance.Options.UseFont = true;
            this.labelBakiyeYetersizTutar.Location = new System.Drawing.Point(217, 16);
            this.labelBakiyeYetersizTutar.Name = "labelBakiyeYetersizTutar";
            this.labelBakiyeYetersizTutar.Size = new System.Drawing.Size(58, 29);
            this.labelBakiyeYetersizTutar.TabIndex = 1;
            this.labelBakiyeYetersizTutar.Text = "0,0 ₺";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl4.ImageOptions.Image")));
            this.labelControl4.Location = new System.Drawing.Point(5, 16);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(192, 32);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "       BAKİYE YETERSİZ:";
            // 
            // Odeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 375);
            this.ControlBox = false;
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.panelBakiyeYetersiz);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelIslemTamamlandi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Odeme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelIslemTamamlandi)).EndInit();
            this.panelIslemTamamlandi.ResumeLayout(false);
            this.panelIslemTamamlandi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBakiyeYetersiz)).EndInit();
            this.panelBakiyeYetersiz.ResumeLayout(false);
            this.panelBakiyeYetersiz.PerformLayout();
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
        private DevExpress.XtraEditors.LabelControl labelIslemTamamTutar;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelBakiyeYetersiz;
        private DevExpress.XtraEditors.LabelControl labelBakiyeYetersizTutar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}