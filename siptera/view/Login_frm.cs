using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using siptera.model;

namespace siptera.view
{
    public partial class Login_frm : Form
    {
        Penduduk_cls penduduk = new Penduduk_cls();
        public Login_frm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void validasiLogin()
        {

            //string user = username_textbox.Text;
            //string pw = password_textbox.Text;

            //var pengguna = new siptera.model.Pengguna_cls();


            //if (pengguna.LoginValid(user, pw))
            //{
            //    Penduduk_frm dash = new Penduduk_frm(user);
            //    dash.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("User atau password salah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    username_textbox.SelectAll();
            //    username_textbox.Focus();
            //}
            //void validasiLogin()
                string user = username_textbox.Text;
                string pw = password_textbox.Text;

                var pengguna = new siptera.model.Pengguna_cls();
                string role = pengguna.CekLoginDanAmbilRole(user, pw);
                string idPenduduk = pengguna.AmbilIdPenduduk(user, pw); // Ambil ID

                if (role != null && idPenduduk != null)
                {
                    if (role == "admin")
                    {
                        Dashboard Dashboard = new Dashboard(); // bisa tambahkan id kalau perlu
                        Dashboard.Show();
                    }
                    else if (role == "penduduk")
                    {
                    string username;
                    username = penduduk.ambilUsername(idPenduduk);
                        Penduduk penggunaForm = new Penduduk(idPenduduk, username); // lewatkan id_penduduk ke form
                        penggunaForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Role tidak dikenali!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    username_textbox.SelectAll();
                    username_textbox.Focus();
                }
            

        }


        private void login_button_Click(object sender, EventArgs e)
        {
            validasiLogin();
        }

        private void Login_frm_Load(object sender, EventArgs e)
        {
            username_textbox.Focus();
            // Ubah background label menjadi warna #007ACC
            header_label.BackColor = ColorTranslator.FromHtml("#007ACC");
            des_label.BackColor = ColorTranslator.FromHtml("#007ACC");
            pictureBox2.BackColor = ColorTranslator.FromHtml("#007ACC");
            this.AcceptButton = login_button;
            this.KeyPreview = true;
            this.KeyDown += Login_frm_KeyDown;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
            {
                // Ctrl+L untuk login
                login_button.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                Application.Exit(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
