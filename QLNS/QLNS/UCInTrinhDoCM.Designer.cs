namespace QLNS
{
    partial class UCInTrinhDoCM
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
            this.View_InTrinhDoCMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUANLYNHANSUDataSet = new QLNS.QUANLYNHANSUDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.View_InTrinhDoCMTableAdapter = new QLNS.QUANLYNHANSUDataSetTableAdapters.View_InTrinhDoCMTableAdapter();
            this.cbbTrinhDo = new System.Windows.Forms.ComboBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.View_InTrinhDoCMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHANSUDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // View_InTrinhDoCMBindingSource
            // 
            this.View_InTrinhDoCMBindingSource.DataMember = "View_InTrinhDoCM";
            this.View_InTrinhDoCMBindingSource.DataSource = this.QUANLYNHANSUDataSet;
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
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 542);
            this.panel1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.View_InTrinhDoCMBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNS.RpInTrinhDoCM.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1044, 542);
            this.reportViewer1.TabIndex = 0;
            // 
            // View_InTrinhDoCMTableAdapter
            // 
            this.View_InTrinhDoCMTableAdapter.ClearBeforeFill = true;
            // 
            // cbbTrinhDo
            // 
            this.cbbTrinhDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrinhDo.FormattingEnabled = true;
            this.cbbTrinhDo.Location = new System.Drawing.Point(311, 12);
            this.cbbTrinhDo.Name = "cbbTrinhDo";
            this.cbbTrinhDo.Size = new System.Drawing.Size(121, 21);
            this.cbbTrinhDo.TabIndex = 1;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(456, 10);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(75, 23);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // UCInTrinhDoCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.cbbTrinhDo);
            this.Controls.Add(this.panel1);
            this.Name = "UCInTrinhDoCM";
            this.Size = new System.Drawing.Size(1044, 591);
            this.Load += new System.EventHandler(this.UCInTrinhDoCM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_InTrinhDoCMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHANSUDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_InTrinhDoCMBindingSource;
        private QUANLYNHANSUDataSet QUANLYNHANSUDataSet;
        private QUANLYNHANSUDataSetTableAdapters.View_InTrinhDoCMTableAdapter View_InTrinhDoCMTableAdapter;
        private System.Windows.Forms.ComboBox cbbTrinhDo;
        private System.Windows.Forms.Button btnThongKe;
    }
}
