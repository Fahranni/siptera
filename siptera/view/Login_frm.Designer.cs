namespace siptera.view
{
    partial class Login_frm
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
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.header_label = new System.Windows.Forms.Label();
            this.des_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // password_textbox
            // 
            this.password_textbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_textbox.Location = new System.Drawing.Point(1428, 472);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.PasswordChar = '*';
            this.password_textbox.Size = new System.Drawing.Size(312, 37);
            this.password_textbox.TabIndex = 2;
            this.password_textbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // username_textbox
            // 
            this.username_textbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_textbox.Location = new System.Drawing.Point(1428, 406);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(312, 37);
            this.username_textbox.TabIndex = 1;
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.Color.DodgerBlue;
            this.login_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.ForeColor = System.Drawing.SystemColors.Control;
            this.login_button.Location = new System.Drawing.Point(1280, 588);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(460, 59);
            this.login_button.TabIndex = 2;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1275, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1275, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1221, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(594, 94);
            this.label3.TabIndex = 7;
            this.label3.Text = "Silahkan login terlebih dahulu\r\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.BackColor = System.Drawing.Color.Gray;
            this.header_label.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.header_label.ForeColor = System.Drawing.SystemColors.Control;
            this.header_label.Location = new System.Drawing.Point(182, 617);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(670, 59);
            this.header_label.TabIndex = 9;
            this.header_label.Text = "Selamat Datang di SIPTERA";
            // 
            // des_label
            // 
            this.des_label.AutoSize = true;
            this.des_label.BackColor = System.Drawing.Color.Gray;
            this.des_label.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.des_label.ForeColor = System.Drawing.SystemColors.Control;
            this.des_label.Location = new System.Drawing.Point(184, 694);
            this.des_label.Name = "des_label";
            this.des_label.Size = new System.Drawing.Size(713, 43);
            this.des_label.TabIndex = 10;
            this.des_label.Text = "(Sistem Informasi Penduduk Terintegrasi)\r\n";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1280, 667);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(460, 59);
            this.button1.TabIndex = 11;
            this.button1.Text = "Keluar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::siptera.Properties.Resources.Black_and_White_Futuristic_Tech_Presentation__3_;
            this.pictureBox2.Location = new System.Drawing.Point(192, 300);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(567, 297);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::siptera.Properties.Resources.Black_and_White_Futuristic_Tech_Presentation;
            this.pictureBox1.Location = new System.Drawing.Point(-694, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(3320, 1118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Login_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1946, 1106);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.des_label);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "Login_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Login_frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_frm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.Label des_label;
        private System.Windows.Forms.Button button1;
    }
}