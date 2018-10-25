namespace GalaxyMobile
{
    partial class frmThongTinGiaoHang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaCH = new System.Windows.Forms.TextBox();
            this.comboBoxMaNVGH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMaHD = new System.Windows.Forms.TextBox();
            this.dateTimeGiaoHang = new System.Windows.Forms.DateTimePicker();
            this.textBoxNgayGiaoHang = new System.Windows.Forms.TextBox();
            this.btnGiaoHang = new System.Windows.Forms.Button();
            this.checkBoxGiaoHang = new System.Windows.Forms.CheckBox();
            this.btnHuyGiaoHang = new System.Windows.Forms.Button();
            this.textBoxTinhTrangGiaoHang = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTinhTrangGiaoHang);
            this.groupBox1.Controls.Add(this.checkBoxGiaoHang);
            this.groupBox1.Controls.Add(this.textBoxNgayGiaoHang);
            this.groupBox1.Controls.Add(this.dateTimeGiaoHang);
            this.groupBox1.Controls.Add(this.comboBoxMaNVGH);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxMaHD);
            this.groupBox1.Controls.Add(this.textBoxMaCH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Giao Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hóa Đơn:";
            // 
            // textBoxMaCH
            // 
            this.textBoxMaCH.Location = new System.Drawing.Point(185, 102);
            this.textBoxMaCH.Name = "textBoxMaCH";
            this.textBoxMaCH.ReadOnly = true;
            this.textBoxMaCH.Size = new System.Drawing.Size(129, 20);
            this.textBoxMaCH.TabIndex = 1;
            // 
            // comboBoxMaNVGH
            // 
            this.comboBoxMaNVGH.FormattingEnabled = true;
            this.comboBoxMaNVGH.Location = new System.Drawing.Point(185, 139);
            this.comboBoxMaNVGH.Name = "comboBoxMaNVGH";
            this.comboBoxMaNVGH.Size = new System.Drawing.Size(129, 21);
            this.comboBoxMaNVGH.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Cửa Hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày Giao Hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tình Trạng Giao Hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhân Viên Giao Hàng:";
            // 
            // textBoxMaHD
            // 
            this.textBoxMaHD.Location = new System.Drawing.Point(185, 58);
            this.textBoxMaHD.Name = "textBoxMaHD";
            this.textBoxMaHD.ReadOnly = true;
            this.textBoxMaHD.Size = new System.Drawing.Size(129, 20);
            this.textBoxMaHD.TabIndex = 1;
            // 
            // dateTimeGiaoHang
            // 
            this.dateTimeGiaoHang.CustomFormat = "dd/MM/yyyy";
            this.dateTimeGiaoHang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeGiaoHang.Location = new System.Drawing.Point(185, 181);
            this.dateTimeGiaoHang.Name = "dateTimeGiaoHang";
            this.dateTimeGiaoHang.Size = new System.Drawing.Size(129, 20);
            this.dateTimeGiaoHang.TabIndex = 3;
            // 
            // textBoxNgayGiaoHang
            // 
            this.textBoxNgayGiaoHang.Location = new System.Drawing.Point(185, 181);
            this.textBoxNgayGiaoHang.Name = "textBoxNgayGiaoHang";
            this.textBoxNgayGiaoHang.ReadOnly = true;
            this.textBoxNgayGiaoHang.Size = new System.Drawing.Size(129, 20);
            this.textBoxNgayGiaoHang.TabIndex = 4;
            this.textBoxNgayGiaoHang.Visible = false;
            // 
            // btnGiaoHang
            // 
            this.btnGiaoHang.Location = new System.Drawing.Point(193, 301);
            this.btnGiaoHang.Name = "btnGiaoHang";
            this.btnGiaoHang.Size = new System.Drawing.Size(75, 23);
            this.btnGiaoHang.TabIndex = 1;
            this.btnGiaoHang.Text = "Lưu";
            this.btnGiaoHang.UseVisualStyleBackColor = true;
            this.btnGiaoHang.Click += new System.EventHandler(this.btnGiaoHang_Click);
            // 
            // checkBoxGiaoHang
            // 
            this.checkBoxGiaoHang.AutoSize = true;
            this.checkBoxGiaoHang.Location = new System.Drawing.Point(185, 225);
            this.checkBoxGiaoHang.Name = "checkBoxGiaoHang";
            this.checkBoxGiaoHang.Size = new System.Drawing.Size(94, 17);
            this.checkBoxGiaoHang.TabIndex = 5;
            this.checkBoxGiaoHang.Text = "Đã Giao Hàng";
            this.checkBoxGiaoHang.UseVisualStyleBackColor = true;
            // 
            // btnHuyGiaoHang
            // 
            this.btnHuyGiaoHang.Location = new System.Drawing.Point(274, 301);
            this.btnHuyGiaoHang.Name = "btnHuyGiaoHang";
            this.btnHuyGiaoHang.Size = new System.Drawing.Size(98, 23);
            this.btnHuyGiaoHang.TabIndex = 2;
            this.btnHuyGiaoHang.Text = "Hủy Giao Hàng";
            this.btnHuyGiaoHang.UseVisualStyleBackColor = true;
            this.btnHuyGiaoHang.Click += new System.EventHandler(this.btnHuyGiaoHang_Click);
            // 
            // textBoxTinhTrangGiaoHang
            // 
            this.textBoxTinhTrangGiaoHang.Location = new System.Drawing.Point(185, 225);
            this.textBoxTinhTrangGiaoHang.Name = "textBoxTinhTrangGiaoHang";
            this.textBoxTinhTrangGiaoHang.ReadOnly = true;
            this.textBoxTinhTrangGiaoHang.Size = new System.Drawing.Size(129, 20);
            this.textBoxTinhTrangGiaoHang.TabIndex = 6;
            this.textBoxTinhTrangGiaoHang.Text = "Đã Giao Hàng";
            // 
            // frmThongTinGiaoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 336);
            this.Controls.Add(this.btnHuyGiaoHang);
            this.Controls.Add(this.btnGiaoHang);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongTinGiaoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Giao Hàng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxMaNVGH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMaCH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeGiaoHang;
        private System.Windows.Forms.TextBox textBoxMaHD;
        private System.Windows.Forms.CheckBox checkBoxGiaoHang;
        private System.Windows.Forms.TextBox textBoxNgayGiaoHang;
        private System.Windows.Forms.Button btnGiaoHang;
        private System.Windows.Forms.Button btnHuyGiaoHang;
        private System.Windows.Forms.TextBox textBoxTinhTrangGiaoHang;
    }
}