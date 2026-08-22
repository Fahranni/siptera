using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using siptera.model;
using siptera.view;

namespace siptera
{
    public partial class Penduduk : Form
    {
        Penduduk_cls user = new Penduduk_cls();

        string idPenduduk;
        string usr;
        public Penduduk(string id, string user)
        {
            InitializeComponent();
            idPenduduk = id;
            usr = user;
        }
        void TampilkanDataPribadi()
        {
            DataTable data = user.tampilDataPengguna(idPenduduk);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                string gender;
                nama_label.Text = row["nama"].ToString();
                nik_label.Text = row["nik"].ToString();
                if (row["jenis_kelamin"].ToString() == "L")
                {
                    gender = "Laki-laki";
                }
                else
                {
                    gender = "Perempuan";
                }
                gender_label.Text = gender;
                ttl_label.Text = row["tempat_tanggal_lahir"].ToString();
                agama_label.Text = row["agama"].ToString();
                statusPerkawinan_label.Text = row["status_perkawinan"].ToString();
                pekerjaan_label.Text = row["pekerjaan"].ToString();
                alamat_label.Text = row["alamat_lengkap"].ToString();
            }
        }


public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 20; // Bisa diubah saat pakai di Form

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.FromArgb(0, 122, 204);
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath path = GetRoundedPath(rect, BorderRadius))
            {
                this.Region = new Region(path);
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Draw text center
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, rect, this.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }
}

        private void setTransparent()
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }
        void tampilPengajuan(string id)
        {
            riwayat_dgv.DataSource = user.tampilPengajuanPenduduk(id);
        }

        private void Penduduk_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = ColorTranslator.FromHtml("#F5F7FA");
            username_text.Text = usr;
            TampilkanDataPribadi();
            setTransparent();
            username_text.ForeColor = ColorTranslator.FromHtml("#2affd9");
            //this.BackColor = ColorTranslator.FromHtml("#F5F7FA");
            this.BackColor = ColorTranslator.FromHtml("#3399FF");
            tampilPengajuan(idPenduduk);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id_penduduk = idPenduduk.ToString();
            string username = username_text.Text;
            Pengajuan pengajuanForm = new Pengajuan(id_penduduk, username);
            pengajuanForm.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            reset_grb.Visible = true;
            panel3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string new_password = newpas_textbox.Text;
            //int id_penduduk = Convert.ToInt16(idpenduduk_lbl.Text);
            int id_penduduk = Convert.ToInt32(idPenduduk);

            int hasil = user.resetPassword(new_password, id_penduduk);

            if (hasil > 0)
            {
                MessageBox.Show("Password berhasil direset");
            }
            else
            {
                MessageBox.Show("Gagal reset password");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reset_grb.Visible=false;
            panel3.Visible=false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void ajukan_button_MouseEnter(object sender, EventArgs e)
        {
            ajukan_button.BackColor = ColorTranslator.FromHtml("#3300ff");
            ajukan_button.ForeColor = Color.White;
        }

        private void ajukan_button_MouseLeave(object sender, EventArgs e)
        {
            ajukan_button.BackColor = ColorTranslator.FromHtml("#ffff");
            ajukan_button.ForeColor = Color.Black;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = ColorTranslator.FromHtml("#1f009b");
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = ColorTranslator.FromHtml("#9d0000");
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = ColorTranslator.FromHtml("#0000ff");
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = ColorTranslator.FromHtml("#ff0000");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login_frm login = new Login_frm();
            login.Show();
            this.Close();
        }
    }
}
