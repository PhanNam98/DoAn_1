namespace GalaxyMobile
{
    partial class frmPhanChiaSP
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBoxSP = new System.Windows.Forms.ComboBox();
            this.comboBoxMaKieu = new System.Windows.Forms.ComboBox();
            this.textBoxSLTonKieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.maKieuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maCuaHangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khoHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxDSP = new System.Windows.Forms.ComboBox();
            this.comboBoxNXS = new System.Windows.Forms.ComboBox();
            this.textBoxSLTonCHPP = new System.Windows.Forms.TextBox();
            this.comboBoxCHNhan = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.numericUpDownThemBotSL = new System.Windows.Forms.NumericUpDown();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxSLTonCHNhan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxCHPP = new System.Windows.Forms.ComboBox();
            this.textBoxMaKieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThemBotSL)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxNXS);
            this.groupBox1.Controls.Add(this.comboBoxDSP);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBoxSP);
            this.groupBox1.Controls.Add(this.comboBoxMaKieu);
            this.groupBox1.Controls.Add(this.textBoxSLTonKieu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(31, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cơ bản";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(308, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Màu Sắc:";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tên Sản Phẩm:";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(296, 219);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(133, 21);
            this.comboBox4.TabIndex = 2;
            this.comboBox4.Visible = false;
            // 
            // comboBoxSP
            // 
            this.comboBoxSP.FormattingEnabled = true;
            this.comboBoxSP.Location = new System.Drawing.Point(117, 116);
            this.comboBoxSP.Name = "comboBoxSP";
            this.comboBoxSP.Size = new System.Drawing.Size(158, 21);
            this.comboBoxSP.TabIndex = 2;
            this.comboBoxSP.SelectedIndexChanged += new System.EventHandler(this.comboBoxSP_SelectedIndexChanged);
            // 
            // comboBoxMaKieu
            // 
            this.comboBoxMaKieu.FormattingEnabled = true;
            this.comboBoxMaKieu.Location = new System.Drawing.Point(117, 169);
            this.comboBoxMaKieu.Name = "comboBoxMaKieu";
            this.comboBoxMaKieu.Size = new System.Drawing.Size(158, 21);
            this.comboBoxMaKieu.TabIndex = 2;
            this.comboBoxMaKieu.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaKieu_SelectedIndexChanged);
            // 
            // textBoxSLTonKieu
            // 
            this.textBoxSLTonKieu.Location = new System.Drawing.Point(118, 224);
            this.textBoxSLTonKieu.Name = "textBoxSLTonKieu";
            this.textBoxSLTonKieu.ReadOnly = true;
            this.textBoxSLTonKieu.Size = new System.Drawing.Size(158, 20);
            this.textBoxSLTonKieu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số Lượng Tồn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Kiểu:";
            // 
            // dgvKho
            // 
            this.dgvKho.AllowUserToAddRows = false;
            this.dgvKho.AllowUserToDeleteRows = false;
            this.dgvKho.AutoGenerateColumns = false;
            this.dgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maKieuDataGridViewTextBoxColumn,
            this.maCuaHangDataGridViewTextBoxColumn,
            this.soLuongDataGridViewTextBoxColumn});
            this.dgvKho.DataSource = this.khoHangBindingSource;
            this.dgvKho.Location = new System.Drawing.Point(40, 310);
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.ReadOnly = true;
            this.dgvKho.Size = new System.Drawing.Size(429, 150);
            this.dgvKho.TabIndex = 2;
            this.dgvKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKho_CellClick);
            // 
            // maKieuDataGridViewTextBoxColumn
            // 
            this.maKieuDataGridViewTextBoxColumn.DataPropertyName = "MaKieu";
            this.maKieuDataGridViewTextBoxColumn.HeaderText = "Mã Kiểu Sản Phẩm";
            this.maKieuDataGridViewTextBoxColumn.Name = "maKieuDataGridViewTextBoxColumn";
            this.maKieuDataGridViewTextBoxColumn.ReadOnly = true;
            this.maKieuDataGridViewTextBoxColumn.Width = 150;
            // 
            // maCuaHangDataGridViewTextBoxColumn
            // 
            this.maCuaHangDataGridViewTextBoxColumn.DataPropertyName = "MaCuaHang";
            this.maCuaHangDataGridViewTextBoxColumn.HeaderText = "Mã Cửa Hàng";
            this.maCuaHangDataGridViewTextBoxColumn.Name = "maCuaHangDataGridViewTextBoxColumn";
            this.maCuaHangDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // soLuongDataGridViewTextBoxColumn
            // 
            this.soLuongDataGridViewTextBoxColumn.DataPropertyName = "SoLuong";
            this.soLuongDataGridViewTextBoxColumn.HeaderText = "Số Lượng";
            this.soLuongDataGridViewTextBoxColumn.Name = "soLuongDataGridViewTextBoxColumn";
            this.soLuongDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // khoHangBindingSource
            // 
            this.khoHangBindingSource.DataSource = typeof(Model.KhoHang);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(296, 28);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(122, 162);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dòng Sản Phẩm:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Nhà Cung Cấp:";
            // 
            // comboBoxDSP
            // 
            this.comboBoxDSP.FormattingEnabled = true;
            this.comboBoxDSP.Location = new System.Drawing.Point(117, 68);
            this.comboBoxDSP.Name = "comboBoxDSP";
            this.comboBoxDSP.Size = new System.Drawing.Size(158, 21);
            this.comboBoxDSP.TabIndex = 5;
            this.comboBoxDSP.SelectedIndexChanged += new System.EventHandler(this.comboBoxDSP_SelectedIndexChanged);
            // 
            // comboBoxNXS
            // 
            this.comboBoxNXS.FormattingEnabled = true;
            this.comboBoxNXS.Location = new System.Drawing.Point(118, 26);
            this.comboBoxNXS.Name = "comboBoxNXS";
            this.comboBoxNXS.Size = new System.Drawing.Size(157, 21);
            this.comboBoxNXS.TabIndex = 5;
            this.comboBoxNXS.SelectedIndexChanged += new System.EventHandler(this.comboBoxNXS_SelectedIndexChanged);
            // 
            // textBoxSLTonCHPP
            // 
            this.textBoxSLTonCHPP.Location = new System.Drawing.Point(205, 209);
            this.textBoxSLTonCHPP.Name = "textBoxSLTonCHPP";
            this.textBoxSLTonCHPP.ReadOnly = true;
            this.textBoxSLTonCHPP.Size = new System.Drawing.Size(102, 20);
            this.textBoxSLTonCHPP.TabIndex = 1;
            // 
            // comboBoxCHNhan
            // 
            this.comboBoxCHNhan.FormattingEnabled = true;
            this.comboBoxCHNhan.Location = new System.Drawing.Point(162, 66);
            this.comboBoxCHNhan.Name = "comboBoxCHNhan";
            this.comboBoxCHNhan.Size = new System.Drawing.Size(145, 21);
            this.comboBoxCHNhan.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tên Cửa Hàng Nhận:";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(124, 306);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 39);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // numericUpDownThemBotSL
            // 
            this.numericUpDownThemBotSL.Location = new System.Drawing.Point(174, 252);
            this.numericUpDownThemBotSL.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownThemBotSL.Name = "numericUpDownThemBotSL";
            this.numericUpDownThemBotSL.Size = new System.Drawing.Size(133, 20);
            this.numericUpDownThemBotSL.TabIndex = 3;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(232, 306);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 39);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Số Lượng Tồn:";
            // 
            // textBoxSLTonCHNhan
            // 
            this.textBoxSLTonCHNhan.Location = new System.Drawing.Point(205, 104);
            this.textBoxSLTonCHNhan.Name = "textBoxSLTonCHNhan";
            this.textBoxSLTonCHNhan.ReadOnly = true;
            this.textBoxSLTonCHNhan.Size = new System.Drawing.Size(102, 20);
            this.textBoxSLTonCHNhan.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 259);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Thêm/Giảm SL:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxMaKieu);
            this.groupBox2.Controls.Add(this.comboBoxCHPP);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBoxSLTonCHNhan);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnHuy);
            this.groupBox2.Controls.Add(this.numericUpDownThemBotSL);
            this.groupBox2.Controls.Add(this.btnLuu);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxCHNhan);
            this.groupBox2.Controls.Add(this.textBoxSLTonCHPP);
            this.groupBox2.Location = new System.Drawing.Point(475, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 363);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cửa Hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên Cửa Hàng Phân Phối:";
            // 
            // comboBoxCHPP
            // 
            this.comboBoxCHPP.FormattingEnabled = true;
            this.comboBoxCHPP.Location = new System.Drawing.Point(162, 164);
            this.comboBoxCHPP.Name = "comboBoxCHPP";
            this.comboBoxCHPP.Size = new System.Drawing.Size(145, 21);
            this.comboBoxCHPP.TabIndex = 8;
            this.comboBoxCHPP.SelectedIndexChanged += new System.EventHandler(this.comboBoxCHPP_SelectedIndexChanged);
            // 
            // textBoxMaKieu
            // 
            this.textBoxMaKieu.Location = new System.Drawing.Point(162, 29);
            this.textBoxMaKieu.Name = "textBoxMaKieu";
            this.textBoxMaKieu.ReadOnly = true;
            this.textBoxMaKieu.Size = new System.Drawing.Size(145, 20);
            this.textBoxMaKieu.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mã Kiểu Sản Phẩm:";
            // 
            // frmPhanChiaSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 494);
            this.Controls.Add(this.dgvKho);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPhanChiaSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân Phối Sản Phẩm";
            this.Load += new System.EventHandler(this.frmPhanChiaSP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThemBotSL)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxMaKieu;
        private System.Windows.Forms.TextBox textBoxSLTonKieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBoxSP;
        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKieuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maCuaHangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource khoHangBindingSource;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox comboBoxNXS;
        private System.Windows.Forms.ComboBox comboBoxDSP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSLTonCHPP;
        private System.Windows.Forms.ComboBox comboBoxCHNhan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.NumericUpDown numericUpDownThemBotSL;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxSLTonCHNhan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxCHPP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMaKieu;
    }
}