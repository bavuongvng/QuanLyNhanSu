namespace QLNS
{
    partial class UCInThongKeTrinhDoNN
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
            this.View_ThongKeTrinhDoNgoaiNguBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUANLYNHANSUDataSet = new QLNS.QUANLYNHANSUDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.View_ThongKeTrinhDoNgoaiNguTableAdapter = new QLNS.QUANLYNHANSUDataSetTableAdapters.View_ThongKeTrinhDoNgoaiNguTableAdapter();
            this.cbbNgoaiNgu = new System.Windows.Forms.ComboBox();
            this.btnThongKeNN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.View_ThongKeTrinhDoNgoaiNguBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHANSUDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // View_ThongKeTrinhDoNgoaiNguBindingSource
            // 
            this.View_ThongKeTrinhDoNgoaiNguBindingSource.DataMember = "View_ThongKeTrinhDoNgoaiNgu";
            this.View_ThongKeTrinhDoNgoaiNguBindingSource.DataSource = this.QUANLYNHANSUDataSet;
            // 
            // QUANLYNHANSUDataSet
            // 
            this.QUANLYNHANSUDataSet.DataSetName = "QUANLYNHANSUDataSet";
            this.QUANLYNHANSUDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.View_ThongKeTrinhDoNgoaiNguBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNS.RpInTrinhDoNN.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(300, 3, 3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1044, 551);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 551);
            this.panel1.TabIndex = 1;
            // 
            // View_ThongKeTrinhDoNgoaiNguTableAdapter
            // 
            this.View_ThongKeTrinhDoNgoaiNguTableAdapter.ClearBeforeFill = true;
            // 
            // cbbNgoaiNgu
            // 
            this.cbbNgoaiNgu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNgoaiNgu.FormattingEnabled = true;
            this.cbbNgoaiNgu.Location = new System.Drawing.Point(330, 9);
            this.cbbNgoaiNgu.Name = "cbbNgoaiNgu";
            this.cbbNgoaiNgu.Size = new System.Drawing.Size(155, 21);
            this.cbbNgoaiNgu.TabIndex = 2;
            // 
            // btnThongKeNN
            // 
            this.btnThongKeNN.Location = new System.Drawing.Point(507, 9);
            this.btnThongKeNN.Name = "btnThongKeNN";
            this.btnThongKeNN.Size = new System.Drawing.Size(75, 23);
            this.btnThongKeNN.TabIndex = 3;
            this.btnThongKeNN.Text = "Thống kê";
            this.btnThongKeNN.UseVisualStyleBackColor = true;
            this.btnThongKeNN.Click += new System.EventHandler(this.btnThongKeNN_Click);
            // 
            // UCInThongKeTrinhDoNN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnThongKeNN);
            this.Controls.Add(this.cbbNgoaiNgu);
            this.Controls.Add(this.panel1);
            this.Name = "UCInThongKeTrinhDoNN";
            this.Size = new System.Drawing.Size(1044, 591);
            this.Load += new System.EventHandler(this.UCInThongKeTrinhDoNN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_ThongKeTrinhDoNgoaiNguBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHANSUDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource View_ThongKeTrinhDoNgoaiNguBindingSource;
        private QUANLYNHANSUDataSet QUANLYNHANSUDataSet;
        private QUANLYNHANSUDataSetTableAdapters.View_ThongKeTrinhDoNgoaiNguTableAdapter View_ThongKeTrinhDoNgoaiNguTableAdapter;
        private System.Windows.Forms.ComboBox cbbNgoaiNgu;
        private System.Windows.Forms.Button btnThongKeNN;
    }
}
