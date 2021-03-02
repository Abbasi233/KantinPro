
namespace KantinPro.Forms
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCardNumber = new DevExpress.XtraEditors.TextEdit();
            this.panelIslemTamamlandi = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelBakiyeYetersiz = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelTutar = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelIslemTamamlandi)).BeginInit();
            this.panelIslemTamamlandi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBakiyeYetersiz)).BeginInit();
            this.panelBakiyeYetersiz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(43, 97);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(374, 35);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "ÖDEME İÇİN KARTI OKUTUNUZ.";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(43, 162);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Properties.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCardNumber.Properties.Appearance.Options.UseFont = true;
            this.txtCardNumber.Size = new System.Drawing.Size(374, 42);
            this.txtCardNumber.TabIndex = 0;
            this.txtCardNumber.EditValueChanged += new System.EventHandler(this.txtCardNumber_EditValueChanged);
            // 
            // panelIslemTamamlandi
            // 
            this.panelIslemTamamlandi.Controls.Add(this.panelBakiyeYetersiz);
            this.panelIslemTamamlandi.Controls.Add(this.labelControl2);
            this.panelIslemTamamlandi.Location = new System.Drawing.Point(43, 232);
            this.panelIslemTamamlandi.Name = "panelIslemTamamlandi";
            this.panelIslemTamamlandi.Size = new System.Drawing.Size(374, 66);
            this.panelIslemTamamlandi.TabIndex = 18;
            this.panelIslemTamamlandi.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl2.ImageOptions.Image")));
            this.labelControl2.Location = new System.Drawing.Point(78, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(208, 32);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "       İŞLEM TAMAMLANDI";
            // 
            // panelBakiyeYetersiz
            // 
            this.panelBakiyeYetersiz.Controls.Add(this.labelTutar);
            this.panelBakiyeYetersiz.Controls.Add(this.labelControl4);
            this.panelBakiyeYetersiz.Location = new System.Drawing.Point(0, 0);
            this.panelBakiyeYetersiz.Name = "panelBakiyeYetersiz";
            this.panelBakiyeYetersiz.Size = new System.Drawing.Size(374, 66);
            this.panelBakiyeYetersiz.TabIndex = 19;
            this.panelBakiyeYetersiz.Visible = false;
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
            // labelTutar
            // 
            this.labelTutar.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTutar.Appearance.Options.UseFont = true;
            this.labelTutar.Location = new System.Drawing.Point(217, 16);
            this.labelTutar.Name = "labelTutar";
            this.labelTutar.Size = new System.Drawing.Size(58, 29);
            this.labelTutar.TabIndex = 1;
            this.labelTutar.Text = "0,0 ₺";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.panelControl1.Controls.Add(this.topPanel);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.panelIslemTamamlandi);
            this.panelControl1.Controls.Add(this.txtCardNumber);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(463, 358);
            this.panelControl1.TabIndex = 19;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.LightGray;
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Controls.Add(this.labelControl3);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(2, 2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(10);
            this.topPanel.Size = new System.Drawing.Size(459, 53);
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
            this.btnClose.Size = new System.Drawing.Size(84, 33);
            this.btnClose.TabIndex = 12;
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
            // Odeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 358);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Odeme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odeme";
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelIslemTamamlandi)).EndInit();
            this.panelIslemTamamlandi.ResumeLayout(false);
            this.panelIslemTamamlandi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBakiyeYetersiz)).EndInit();
            this.panelBakiyeYetersiz.ResumeLayout(false);
            this.panelBakiyeYetersiz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCardNumber;
        private DevExpress.XtraEditors.PanelControl panelIslemTamamlandi;
        private DevExpress.XtraEditors.PanelControl panelBakiyeYetersiz;
        private DevExpress.XtraEditors.LabelControl labelTutar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel topPanel;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}