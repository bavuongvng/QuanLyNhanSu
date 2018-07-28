namespace QLNS
{
    partial class UCInHoSo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.V_HOSONVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUANLYNHANSUDataSet = new QLNS.QUANLYNHANSUDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.V_HOSONVTableAdapter = new QLNS.QUANLYNHANSUDataSetTableAdapters.V_HOSONVTableAdapter();
            this.cbbMaNhanVien = new System.Windows.Forms.ComboBox();
            this.lbTen = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.V_HOSONVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHANSUDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // V_HOSONVBindingSource
            // 
            this.V_HOSONVBindingSource.DataMember = "V_HOSONV";
            this.V_HOSONVBindingSource.DataSource = this.QUANLYNHANSUDataSet;
            // 
            // QUANLYNHANSUDataSet
            // 
            this.QUANLYNHANSUDataSet.DataSetName = "QUANLYNHANSUDataSet";
            this.QUANLYNHANSUDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 547);
            this.panel1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.V_HOSONVBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNS.RpinHoSo1NhanVien.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1044, 547);
            this.reportViewer1.TabIndex = 0;
            // 
            // V_HOSONVTableAdapter
            // 
            this.V_HOSONVTableAdapter.ClearBeforeFill = true;
            // 
            // cbbMaNhanVien
            // 
            this.cbbMaNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaNhanVien.FormattingEnabled = true;
            this.cbbMaNhanVien.Location = new System.Drawing.Point(141, 3);
            this.cbbMaNhanVien.Name = "cbbMaNhanVien";
            this.cbbMaNhanVien.Size = new System.Drawing.Size(121, 21);
            this.cbbMaNhanVien.TabIndex = 1;
            this.cbbMaNhanVien.SelectionChangeCommitted += new System.EventHandler(this.cbbMaNhanVien_SelectionChangeCommitted);
            // 
            // lbTen
            // 
            this.lbTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTen.Location = new System.Drawing.Point(268, 3);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(121, 21);
            this.lbTen.TabIndex = 2;
            this.lbTen.Text = "label1";
            this.lbTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(408, 3);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // UCInHoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.lbTen);
            this.Controls.Add(this.cbbMaNhanVien);
            this.Controls.Add(this.panel1);
            this.Name = "UCInHoSo";
            this.Size = new System.Drawing.Size(1044, 591);
            this.Load += new System.EventHandler(this.UCInHoSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.V_HOSONVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHANSUDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource V_HOSONVBindingSource;
        private QUANLYNHANSUDataSet QUANLYNHANSUDataSet;
        private QUANLYNHANSUDataSetTableAdapters.V_HOSONVTableAdapter V_HOSONVTableAdapter;
        private System.Windows.Forms.ComboBox cbbMaNhanVien;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.Button btnThongKe;
    }
}
