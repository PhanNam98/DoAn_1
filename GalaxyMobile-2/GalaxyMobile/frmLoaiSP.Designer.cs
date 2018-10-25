namespace GalaxyMobile
{
    partial class frmLoaiSP
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
            this.btnSua = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.dgvLSP = new System.Windows.Forms.DataGridView();
            this.maLSPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenLSPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiSPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiSPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(144, 248);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(112, 24);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(144, 284);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 24);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(15, 248);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(109, 24);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(144, 314);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 24);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Quay Về";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(15, 317);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(109, 24);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(15, 284);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(109, 24);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.txtMa);
            this.panel.Controls.Add(this.txtTenLoai);
            this.panel.Location = new System.Drawing.Point(15, 215);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(244, 27);
            this.panel.TabIndex = 16;
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
            // dgvLSP
            // 
            this.dgvLSP.AllowUserToAddRows = false;
            this.dgvLSP.AllowUserToDeleteRows = false;
            this.dgvLSP.AutoGenerateColumns = false;
            this.dgvLSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maLSPDataGridViewTextBoxColumn,
            this.tenLSPDataGridViewTextBoxColumn});
            this.dgvLSP.DataSource = this.loaiSPBindingSource;
            this.dgvLSP.Location = new System.Drawing.Point(12, 12);
            this.dgvLSP.Name = "dgvLSP";
            this.dgvLSP.ReadOnly = true;
            this.dgvLSP.Size = new System.Drawing.Size(244, 197);
            this.dgvLSP.TabIndex = 9;
            this.dgvLSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLSP_CellClick);
            // 
            // maLSPDataGridViewTextBoxColumn
            // 
            this.maLSPDataGridViewTextBoxColumn.DataPropertyName = "MaLSP";
            this.maLSPDataGridViewTextBoxColumn.HeaderText = "MaLSP";
            this.maLSPDataGridViewTextBoxColumn.Name = "maLSPDataGridViewTextBoxColumn";
            this.maLSPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tenLSPDataGridViewTextBoxColumn
            // 
            this.tenLSPDataGridViewTextBoxColumn.DataPropertyName = "TenLSP";
            this.tenLSPDataGridViewTextBoxColumn.HeaderText = "TenLSP";
            this.tenLSPDataGridViewTextBoxColumn.Name = "tenLSPDataGridViewTextBoxColumn";
            this.tenLSPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loaiSPBindingSource
            // 
            this.loaiSPBindingSource.DataSource = typeof(Model.LoaiSP);
            // 
            // LoaiSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 356);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.dgvLSP);
            this.Name = "LoaiSP";
            this.Text = "LoaiSP";
            this.Load += new System.EventHandler(this.LoaiSP_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiSPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.DataGridView dgvLSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLSPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenLSPDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource loaiSPBindingSource;
    }
}