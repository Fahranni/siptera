namespace siptera.view
{
    partial class pekerjaan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nama_Txt = new System.Windows.Forms.TextBox();
            this.hapus_btn = new System.Windows.Forms.Button();
            this.pekerjaan_dgv = new System.Windows.Forms.DataGridView();
            this.id_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.simpan_btn = new System.Windows.Forms.Button();
            this.cari_Txt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.namaPekerjaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pekerjaan_dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // nama_Txt
            // 
            this.nama_Txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nama_Txt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nama_Txt.Location = new System.Drawing.Point(251, 88);
            this.nama_Txt.Name = "nama_Txt";
            this.nama_Txt.Size = new System.Drawing.Size(402, 37);
            this.nama_Txt.TabIndex = 4;
            this.nama_Txt.TextChanged += new System.EventHandler(this.nama_Txt_TextChanged);
            // 
            // hapus_btn
            // 
            this.hapus_btn.BackColor = System.Drawing.Color.Red;
            this.hapus_btn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hapus_btn.ForeColor = System.Drawing.Color.White;
            this.hapus_btn.Location = new System.Drawing.Point(251, 139);
            this.hapus_btn.Name = "hapus_btn";
            this.hapus_btn.Size = new System.Drawing.Size(193, 59);
            this.hapus_btn.TabIndex = 21;
            this.hapus_btn.Text = "Hapus";
            this.hapus_btn.UseVisualStyleBackColor = false;
            this.hapus_btn.Click += new System.EventHandler(this.hapus_btn_Click);
            // 
            // pekerjaan_dgv
            // 
            this.pekerjaan_dgv.AllowUserToAddRows = false;
            this.pekerjaan_dgv.AllowUserToDeleteRows = false;
            this.pekerjaan_dgv.BackgroundColor = System.Drawing.Color.White;
            this.pekerjaan_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pekerjaan_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.pekerjaan_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pekerjaan_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.namaPekerjaan});
            this.pekerjaan_dgv.Location = new System.Drawing.Point(26, 116);
            this.pekerjaan_dgv.Name = "pekerjaan_dgv";
            this.pekerjaan_dgv.ReadOnly = true;
            this.pekerjaan_dgv.RowHeadersWidth = 62;
            this.pekerjaan_dgv.RowTemplate.Height = 28;
            this.pekerjaan_dgv.Size = new System.Drawing.Size(1365, 381);
            this.pekerjaan_dgv.TabIndex = 24;
            this.pekerjaan_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pekerjaan_dgv_CellClick);
            this.pekerjaan_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pekerjaan_dgv_CellContentClick);
            // 
            // id_txt
            // 
            this.id_txt.Location = new System.Drawing.Point(0, 0);
            this.id_txt.Name = "id_txt";
            this.id_txt.ReadOnly = true;
            this.id_txt.Size = new System.Drawing.Size(89, 26);
            this.id_txt.TabIndex = 25;
            this.id_txt.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(726, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(429, 56);
            this.label6.TabIndex = 27;
            this.label6.Text = "DATA PEKERJAAN";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(231, 119);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(729, 249);
            this.panel3.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nama_Txt);
            this.groupBox2.Controls.Add(this.simpan_btn);
            this.groupBox2.Controls.Add(this.hapus_btn);
            this.groupBox2.Location = new System.Drawing.Point(22, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(683, 215);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(197, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 43);
            this.label5.TabIndex = 29;
            this.label5.Text = "Form Pekerjaan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 30);
            this.label2.TabIndex = 25;
            this.label2.Text = "Nama Pekerjaan :";
            // 
            // simpan_btn
            // 
            this.simpan_btn.BackColor = System.Drawing.Color.Blue;
            this.simpan_btn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpan_btn.ForeColor = System.Drawing.Color.White;
            this.simpan_btn.Location = new System.Drawing.Point(460, 139);
            this.simpan_btn.Name = "simpan_btn";
            this.simpan_btn.Size = new System.Drawing.Size(193, 59);
            this.simpan_btn.TabIndex = 20;
            this.simpan_btn.Text = "Simpan";
            this.simpan_btn.UseVisualStyleBackColor = false;
            this.simpan_btn.Click += new System.EventHandler(this.simpan_btn_Click_1);
            // 
            // cari_Txt
            // 
            this.cari_Txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cari_Txt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cari_Txt.Location = new System.Drawing.Point(228, 84);
            this.cari_Txt.Name = "cari_Txt";
            this.cari_Txt.Size = new System.Drawing.Size(391, 37);
            this.cari_Txt.TabIndex = 19;
            this.cari_Txt.TextChanged += new System.EventHandler(this.cari_Txt_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(981, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 249);
            this.panel1.TabIndex = 34;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cari_Txt);
            this.groupBox1.Controls.Add(this.id_txt);
            this.groupBox1.Location = new System.Drawing.Point(22, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 215);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(228, 143);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(391, 55);
            this.button1.TabIndex = 29;
            this.button1.Text = "Reset Filter";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(285, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 43);
            this.label1.TabIndex = 29;
            this.label1.Text = "Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 30);
            this.label4.TabIndex = 25;
            this.label4.Text = "Cari Pekerjaan :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(231, 393);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1465, 567);
            this.panel2.TabIndex = 34;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.pekerjaan_dgv);
            this.groupBox3.Location = new System.Drawing.Point(22, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1417, 527);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(26, 143);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 55);
            this.button2.TabIndex = 30;
            this.button2.Text = "< Kembali";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // namaPekerjaan
            // 
            this.namaPekerjaan.DataPropertyName = "nama_pekerjaan";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.namaPekerjaan.DefaultCellStyle = dataGridViewCellStyle6;
            this.namaPekerjaan.HeaderText = "NAMA PEKERJAAN";
            this.namaPekerjaan.MinimumWidth = 8;
            this.namaPekerjaan.Name = "namaPekerjaan";
            this.namaPekerjaan.ReadOnly = true;
            this.namaPekerjaan.Width = 1300;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(574, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 43);
            this.label3.TabIndex = 31;
            this.label3.Text = "Data Pekerjaan";
            // 
            // pekerjaan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(1852, 1040);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label6);
            this.Name = "pekerjaan";
            this.Text = "pekerjaan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.pekerjaan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pekerjaan_dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nama_Txt;
        private System.Windows.Forms.Button hapus_btn;
        private System.Windows.Forms.DataGridView pekerjaan_dgv;
        private System.Windows.Forms.TextBox id_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cari_Txt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button simpan_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaPekerjaan;
        private System.Windows.Forms.Label label3;
    }
}