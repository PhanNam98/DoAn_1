namespace GalaxyMobile
{
    partial class LNhanVIen
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
            this.components = new System.ComponentModel.Container();
            this.dgvLNV = new System.Windows.Forms.DataGridView();
            this.maLoaiNVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenLoaiNVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiNVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.galaxyMobileDataSet = new GalaxyMobile.GalaxyMobileDataSet();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.loaiNVTableAdapter = new GalaxyMobile.GalaxyMobileDataSetTableAdapters.LoaiNVTableAdapter();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiNVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galaxyMobileDataSet)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLNV
            // 
            this.dgvLNV.AutoGenerateColumns = false;
            this.dgvLNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLNV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maLoaiNVDataGridViewTextBoxColumn,
            this.tenLoaiNVDataGridViewTextBoxColumn});
            this.dgvLNV.DataSource = this.loaiNVBindingSource;
            this.dgvLNV.Location = new System.Drawing.Point(12, 12);
            this.dgvLNV.Name = "dgvLNV";
            this.dgvLNV.Size = new System.Drawing.Size(244, 197);
            this.dgvLNV.TabIndex = 0;
            this.dgvLNV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLNV_CellClick);
            // 
            // maLoaiNVDataGridViewTextBoxColumn
            // 
            this.maLoaiNVDataGridViewTextBoxColumn.DataPropertyName = "MaLoaiNV";
            this.maLoaiNVDataGridViewTextBoxColumn.HeaderText = "Ma";
            this.maLoaiNVDataGridViewTextBoxColumn.Name = "maLoaiNVDataGridViewTextBoxColumn";
            this.maLoaiNVDataGridViewTextBoxColumn.Width = 50;
            // 
            // tenLoaiNVDataGridViewTextBoxColumn
            // 
            this.tenLoaiNVDataGridViewTextBoxColumn.DataPropertyName = "TenLoaiNV";
            this.tenLoaiNVDataGridViewTextBoxColumn.HeaderText = "TenLoaiNV";
            this.tenLoaiNVDataGridViewTextBoxColumn.Name = "tenLoaiNVDataGridViewTextBoxColumn";
            this.tenLoaiNVDataGridViewTextBoxColumn.Width = 150;
            // 
            // loaiNVBindingSource
            // 
            this.loaiNVBindingSource.DataMember = "LoaiNV";
            this.loaiNVBindingSource.DataSource = this.galaxyMobileDataSet;
            // 
            // galaxyMobileDataSet
            // 
            this.galaxyMobileDataSet.DataSetName = "GalaxyMobileDataSet";
            this.galaxyMobileDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(15, 248);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(109, 24);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(144, 248);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 24);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(15, 284);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(109, 24);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnDelLNV_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(144, 284);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 24);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnCancelLNV_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(144, 314);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 24);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Quay Về";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // loaiNVTableAdapter
            // 
            this.loaiNVTableAdapter.ClearBeforeFill = true;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(0, 3);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(89, 20);
            this.txtMa.TabIndex = 6;
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.Location = new System.Drawing.Point(92, 3);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(149, 20);
            this.txtTenLoai.TabIndex = 7;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.txtMa);
            this.panel.Controls.Add(this.txtTenLoai);
            this.panel.Location = new System.Drawing.Point(15, 215);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(244, 27);
            this.panel.TabIndex = 8;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(15, 317);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(109, 24);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // LNhanVIen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 360);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.dgvLNV);
            this.Name = "LNhanVIen";
            this.Text = "LNhanVIen";
            this.Load += new System.EventHandler(this.LNhanVIen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiNVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galaxyMobileDataSet)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLNV;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnBack;
        private GalaxyMobileDataSet galaxyMobileDataSet;
        private System.Windows.Forms.BindingSource loaiNVBindingSource;
        private GalaxyMobileDataSetTableAdapters.LoaiNVTableAdapter loaiNVTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLoaiNVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenLoaiNVDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnLuu;
    }
}