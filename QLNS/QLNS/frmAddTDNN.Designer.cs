namespace QLNS
{
    partial class frmAddTDNN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddTDNN));
            this.cbbManv = new System.Windows.Forms.ComboBox();
            this.btnThemTDNN = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuCustomLabel31 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnHuyTDNN = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuCustomLabel29 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtTrinhDo = new System.Windows.Forms.TextBox();
            this.cboNgoaiNgu = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel30 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtTenNV = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel26 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel28 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.SuspendLayout();
            // 
            // cbbManv
            // 
            this.cbbManv.FormattingEnabled = true;
            this.cbbManv.Location = new System.Drawing.Point(154, 137);
            this.cbbManv.Name = "cbbManv";
            this.cbbManv.Size = new System.Drawing.Size(200, 21);
            this.cbbManv.TabIndex = 202;
            this.cbbManv.SelectionChangeCommitted += new System.EventHandler(this.cbbManv_SelectionChangeCommitted_1);
            // 
            // btnThemTDNN
            // 
            this.btnThemTDNN.ActiveBorderThickness = 1;
            this.btnThemTDNN.ActiveCornerRadius = 20;
            this.btnThemTDNN.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnThemTDNN.ActiveForecolor = System.Drawing.Color.White;
            this.btnThemTDNN.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnThemTDNN.BackColor = System.Drawing.SystemColors.Control;
            this.btnThemTDNN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThemTDNN.BackgroundImage")));
            this.btnThemTDNN.ButtonText = "Thêm";
            this.btnThemTDNN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemTDNN.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTDNN.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnThemTDNN.IdleBorderThickness = 1;
            this.btnThemTDNN.IdleCornerRadius = 20;
            this.btnThemTDNN.IdleFillColor = System.Drawing.Color.White;
            this.btnThemTDNN.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnThemTDNN.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnThemTDNN.Location = new System.Drawing.Point(285, 283);
            this.btnThemTDNN.Margin = new System.Windows.Forms.Padding(5);
            this.btnThemTDNN.Name = "btnThemTDNN";
            this.btnThemTDNN.Size = new System.Drawing.Size(110, 41);
            this.btnThemTDNN.TabIndex = 201;
            this.btnThemTDNN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThemTDNN.Click += new System.EventHandler(this.btnThemTDNN_Click_1);
            // 
            // bunifuCustomLabel31
            // 
            this.bunifuCustomLabel31.AutoSize = true;
            this.bunifuCustomLabel31.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuCustomLabel31.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel31.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bunifuCustomLabel31.Location = new System.Drawing.Point(245, 43);
            this.bunifuCustomLabel31.Name = "bunifuCustomLabel31";
            this.bunifuCustomLabel31.Size = new System.Drawing.Size(305, 31);
            this.bunifuCustomLabel31.TabIndex = 200;
            this.bunifuCustomLabel31.Text = "Thêm trình độ ngoại ngữ";
            // 
            // btnHuyTDNN
            // 
            this.btnHuyTDNN.ActiveBorderThickness = 1;
            this.btnHuyTDNN.ActiveCornerRadius = 20;
            this.btnHuyTDNN.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btnHuyTDNN.ActiveForecolor = System.Drawing.Color.White;
            this.btnHuyTDNN.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btnHuyTDNN.BackColor = System.Drawing.SystemColors.Control;
            this.btnHuyTDNN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHuyTDNN.BackgroundImage")));
            this.btnHuyTDNN.ButtonText = "Hủy";
            this.btnHuyTDNN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyTDNN.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyTDNN.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnHuyTDNN.IdleBorderThickness = 1;
            this.btnHuyTDNN.IdleCornerRadius = 20;
            this.btnHuyTDNN.IdleFillColor = System.Drawing.Color.White;
            this.btnHuyTDNN.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btnHuyTDNN.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btnHuyTDNN.Location = new System.Drawing.Point(421, 283);
            this.btnHuyTDNN.Margin = new System.Windows.Forms.Padding(5);
            this.btnHuyTDNN.Name = "btnHuyTDNN";
            this.btnHuyTDNN.Size = new System.Drawing.Size(110, 41);
            this.btnHuyTDNN.TabIndex = 199;
            this.btnHuyTDNN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHuyTDNN.Click += new System.EventHandler(this.btnHuyTDNN_Click);
            // 
            // bunifuCustomLabel29
            // 
            this.bunifuCustomLabel29.AutoSize = true;
            this.bunifuCustomLabel29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel29.Location = new System.Drawing.Point(421, 196);
            this.bunifuCustomLabel29.Name = "bunifuCustomLabel29";
            this.bunifuCustomLabel29.Size = new System.Drawing.Size(66, 20);
            this.bunifuCustomLabel29.TabIndex = 198;
            this.bunifuCustomLabel29.Text = "Trình độ";
            // 
            // txtTrinhDo
            // 
            this.txtTrinhDo.Location = new System.Drawing.Point(573, 198);
            this.txtTrinhDo.Name = "txtTrinhDo";
            this.txtTrinhDo.Size = new System.Drawing.Size(200, 20);
            this.txtTrinhDo.TabIndex = 197;
            // 
            // cboNgoaiNgu
            // 
            this.cboNgoaiNgu.FormattingEnabled = true;
            this.cboNgoaiNgu.Location = new System.Drawing.Point(154, 198);
            this.cboNgoaiNgu.Name = "cboNgoaiNgu";
            this.cboNgoaiNgu.Size = new System.Drawing.Size(200, 21);
            this.cboNgoaiNgu.TabIndex = 196;
            // 
            // bunifuCustomLabel30
            // 
            this.bunifuCustomLabel30.AutoSize = true;
            this.bunifuCustomLabel30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel30.Location = new System.Drawing.Point(28, 199);
            this.bunifuCustomLabel30.Name = "bunifuCustomLabel30";
            this.bunifuCustomLabel30.Size = new System.Drawing.Size(81, 20);
            this.bunifuCustomLabel30.TabIndex = 195;
            this.bunifuCustomLabel30.Text = "Ngoại ngữ";
            // 
            // txtTenNV
            // 
            this.txtTenNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Location = new System.Drawing.Point(573, 127);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(200, 25);
            this.txtTenNV.TabIndex = 194;
            // 
            // bunifuCustomLabel26
            // 
            this.bunifuCustomLabel26.AutoSize = true;
            this.bunifuCustomLabel26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel26.Location = new System.Drawing.Point(421, 131);
            this.bunifuCustomLabel26.Name = "bunifuCustomLabel26";
            this.bunifuCustomLabel26.Size = new System.Drawing.Size(108, 20);
            this.bunifuCustomLabel26.TabIndex = 193;
            this.bunifuCustomLabel26.Text = "Tên nhân viên";
            // 
            // bunifuCustomLabel28
            // 
            this.bunifuCustomLabel28.AutoSize = true;
            this.bunifuCustomLabel28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel28.Location = new System.Drawing.Point(28, 135);
            this.bunifuCustomLabel28.Name = "bunifuCustomLabel28";
            this.bunifuCustomLabel28.Size = new System.Drawing.Size(103, 20);
            this.bunifuCustomLabel28.TabIndex = 192;
            this.bunifuCustomLabel28.Text = "Mã nhân viên";
            // 
            // frmAddTDNN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 366);
            this.Controls.Add(this.cbbManv);
            this.Controls.Add(this.btnThemTDNN);
            this.Controls.Add(this.bunifuCustomLabel31);
            this.Controls.Add(this.btnHuyTDNN);
            this.Controls.Add(this.bunifuCustomLabel29);
            this.Controls.Add(this.txtTrinhDo);
            this.Controls.Add(this.cboNgoaiNgu);
            this.Controls.Add(this.bunifuCustomLabel30);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.bunifuCustomLabel26);
            this.Controls.Add(this.bunifuCustomLabel28);
            this.Name = "frmAddTDNN";
            this.Text = "Thêm";
            this.Load += new System.EventHandler(this.frmAddTDNN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbManv;
        private Bunifu.Framework.UI.BunifuThinButton2 btnThemTDNN;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel31;
        private Bunifu.Framework.UI.BunifuThinButton2 btnHuyTDNN;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel29;
        private System.Windows.Forms.TextBox txtTrinhDo;
        private System.Windows.Forms.ComboBox cboNgoaiNgu;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel30;
        private Bunifu.Framework.UI.BunifuCustomLabel txtTenNV;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel26;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel28;
    }
}