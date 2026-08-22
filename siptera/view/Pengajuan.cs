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
using siptera.koneksi;

namespace siptera.view
{
    public partial class Pengajuan : Form//inheritance
    {
        Penduduk_cls user = new Penduduk_cls();//buat objek dari penduduk_cls (enkapsulasi)

        //menyimpan data user yang sedang login
        string idPenduduk;
        string username_text;
        public Pengajuan(string id, string username)//membuat form pengajuan berdasarkan user yg login
        {
            InitializeComponent();
            idPenduduk = id;
            username = username;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void isiForm()
        {
            DataTable data = user.tampilDataPengguna(idPenduduk);//ambil data pengguna
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                string gender;
                textNama.Text = row["nama"].ToString();
                nama_disable.Text = row["nama"].ToString();
                textNIK.Text = row["nik"].ToString();
                if (row["jenis_kelamin"].ToString() == "L")
                {
                    rbnL.Checked = true;
                }
                else
                {
                    rbnP.Checked = true;
                }
                //dtpTanggalLahir.Text = row["tanggal_lahir"].ToString();
                dtpTanggalLahir.Value = Convert.ToDateTime(row["tanggal_lahir"]);
                //ttl_label.Text = row["tempat_tanggal_lahir"].ToString();
                cmbAgama.Text = row["agama"].ToString();
                txtTempatLahir.Text = row["tempat_lahir"].ToString();
                cmbStatusPerkawinan.Text = row["status_perkawinan"].ToString();
                cmbPekerjaan.Text = row["pekerjaan"].ToString();
                txtAlamat.Text = row["alamat"].ToString();
                txtRT.Text = row["rt"].ToString();
                txtRW.Text = row["rw"].ToString();
                // alamat_textbox.Text = row["alamat"].ToString();
                // dst...
            }
        }

        private void Pengajuan_Load(object sender, EventArgs e)//mengisi combobox pekerjaan dari database
        {
            loadPekerjaan();
            isiForm();
            this.BackColor = ColorTranslator.FromHtml("#3399FF");
        }

        private void btnAjukan_Click(object sender, EventArgs e)
        {

            Pengajuan_cls pengajuan = new Pengajuan_cls();

            // Cek apakah NIK ditemukan di tabel penduduk, nik harus sesuai
            string idPenduduk = pengajuan.cariIdPendudukDariNIK(textNIK.Text);
            if (string.IsNullOrEmpty(idPenduduk))
            {
                MessageBox.Show("NIK tidak ditemukan. Pastikan penduduk sudah terdaftar.");
                return;
            }
            
            pengajuan.Id_penduduk = pengajuan.cariIdPendudukDariNIK(textNIK.Text);
            pengajuan.NIK = textNIK.Text;
            pengajuan.Nama = textNama.Text;
            pengajuan.Jenis_kelamin = rbnL.Checked ? "L" : "P";
            pengajuan.Tempat_lahir = txtTempatLahir.Text;
            pengajuan.Tanggal_lahir = dtpTanggalLahir.Value.ToString("yyyy-MM-dd");
            pengajuan.Agama = cmbAgama.SelectedItem?.ToString();
            pengajuan.Status_perkawinan = cmbStatusPerkawinan.SelectedItem?.ToString();
            pengajuan.Pekerjaan = cmbPekerjaan.SelectedValue?.ToString();
            pengajuan.Alamat = txtAlamat.Text;
            pengajuan.RT = txtRT.Text;
            pengajuan.RW = txtRW.Text;

            int result = pengajuan.saveData();

            if (result > 0)
            {
                MessageBox.Show("Data pengajuan berhasil disimpan.");
                string usr;
                usr = nama_disable.Text;
                Penduduk pen = new Penduduk(idPenduduk, usr);
                pen.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Gagal menyimpan data pengajuan.");
            }

        }
        private void clearForm()//kosongin form
        {
            textNIK.Clear();
            textNama.Clear();
            txtTempatLahir.Clear();
            cmbPekerjaan.SelectedIndex = -1;
            txtAlamat.Clear();
            txtRT.Clear();
            txtRW.Clear();
            cmbAgama.SelectedIndex = -1;
            cmbStatusPerkawinan.SelectedIndex = -1;
            rbnL.Checked = false;
            rbnP.Checked = false;
            dtpTanggalLahir.Value = DateTime.Now;
        }//


        private void loadPekerjaan()// Dropdown Pekerjaan
        {
            KonekServer_cls koneksi = new KonekServer_cls();
            DataTable dt = koneksi.eksekusiQuery("SELECT id_pekerjaan, nama_pekerjaan FROM pekerjaan");

            cmbPekerjaan.DataSource = dt;
            cmbPekerjaan.DisplayMember = "nama_pekerjaan"; 
            cmbPekerjaan.ValueMember = "nama_pekerjaan";     
            cmbPekerjaan.SelectedIndex = -1;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pengguna = new siptera.model.Pengguna_cls();
            string user;
            string nik;
            string id;
            nik = textNIK.Text;
            id = pengguna.AmbilIdPendudukNIK(nik);
            user = nama_disable.Text;
            Penduduk pen = new Penduduk(id, user);
            pen.Show();
            this.Close();
            //procedure
        }
    }
}

