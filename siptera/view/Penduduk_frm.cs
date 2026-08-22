using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using siptera.koneksi;

//using GUI;
using siptera.model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace siptera.view
{
    public partial class Penduduk_frm : Form
    {
        Penduduk_cls pen = new Penduduk_cls();
        string usr;
        public Penduduk_frm(string user)
        {
            InitializeComponent();
            usr = user;
        }

        private void nik_textbox_TextChanged(object sender, EventArgs e)
        {
            
        }
        void LoadPekerjaan()
        {
            pekerjaan_cmb.DataSource = pen.tampilDataPekerjaan(); // dari model kamu
            pekerjaan_cmb.DisplayMember = "nama_pekerjaan";   // tampilannya
            pekerjaan_cmb.ValueMember = "id_pekerjaan";       // ID yang akan disimpan
        }

        private void loadPieChart()
        {
            Penduduk_cls penduduk = new Penduduk_cls();
            DataTable dt = penduduk.getJumlahJenisKelamin();

            // Bersihkan chart
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            // Tambah legend (namanya boleh apa saja)
            Legend legend = new Legend("Legenda");
            chart1.Legends.Add(legend);

            // Series
            Series series = new Series("Jenis Kelamin");
            series.ChartType = SeriesChartType.Pie;
            series.Legend = "Legenda"; // Penting: cocokkan dengan nama legend

            foreach (DataRow row in dt.Rows)
            {
                string jenis = row["jenis_kelamin"].ToString();
                int jumlah = Convert.ToInt32(row["jumlah"]);
                series.Points.AddXY(jenis, jumlah);
            }

            // Label dan Legend Text
            series.Label = "#VALX: #PERCENT";
            series.LegendText = "#VALX";

            chart1.Series.Add(series);
            chart1.Titles.Add("Distribusi Jenis Kelamin Penduduk");
        }

        private void loadPieChartPerkawinan()
        {
            Penduduk_cls penduduk = new Penduduk_cls();
            DataTable dt = penduduk.getJumlahPerkawinan();

            // Bersihkan chart
            StatsPerkawinan.Series.Clear();
            StatsPerkawinan.Titles.Clear();
            StatsPerkawinan.Legends.Clear();

            // Tambah legend (namanya boleh apa saja)
            Legend legend = new Legend("Legenda");
            StatsPerkawinan.Legends.Add(legend);

            // Series
            Series series = new Series("Status Perkawinan");
            series.ChartType = SeriesChartType.Column;
            series.Legend = "Legenda"; // Penting: cocokkan dengan nama legend

            foreach (DataRow row in dt.Rows)
            {
                string jenis = row["status_perkawinan"].ToString();
                int jumlah = Convert.ToInt32(row["jumlah"]);
                series.Points.AddXY(jenis, jumlah);
            }

            // Label dan Legend Text
            series.Label = "#VALY";
            series.LegendText = "#VALX";

            StatsPerkawinan.Series.Add(series);
            StatsPerkawinan.Titles.Add("Distribusi Status Perkawinan Penduduk");
        }

        private void loadBarChartAgama()
        {
            Penduduk_cls penduduk = new Penduduk_cls();
            DataTable dt = penduduk.getJumlahAgama(); // Harusnya return kolom "agama" dan "jumlah"

            // Bersihkan chart (ganti ke chart2 jika itu chart baru)
            barChartAgama.Series.Clear();
            barChartAgama.Titles.Clear();
            barChartAgama.Legends.Clear();

            // Tambah legend
            Legend legend = new Legend("Legenda");
            barChartAgama.Legends.Add(legend);

            // Buat series baru
            Series series = new Series("Agama");
            series.ChartType = SeriesChartType.Bar;
            series.Legend = "Legenda"; // Harus sama dengan legend yang dibuat
            series.XValueType = ChartValueType.String;

            // Tambahkan data dari datatable
            foreach (DataRow row in dt.Rows)
            {
                string agama = row["agama"].ToString();
                int jumlah = Convert.ToInt32(row["jumlah"]);
                series.Points.AddXY(agama, jumlah);
            }

            // Label dan teks legend
            series.Label = "#VALY";         // Label pada batangnya
            series.LegendText = "#VALX";    // Teks legenda

            barChartAgama.Series.Add(series);
            barChartAgama.Titles.Add("Distribusi Agama Penduduk");
        }
        private void loadBarChartPekerjaan()
        {
            Penduduk_cls penduduk = new Penduduk_cls();
            DataTable dt = penduduk.getJumlahPekerjaan(); // Harusnya return kolom "agama" dan "jumlah"

            // Bersihkan chart (ganti ke chart2 jika itu chart baru)
            barChartPekerjaan.Series.Clear();
            barChartPekerjaan.Titles.Clear();
            barChartPekerjaan.Legends.Clear();

            // Tambah legend
            Legend legend = new Legend("Legenda");
            barChartPekerjaan.Legends.Add(legend);

            // Buat series baru
            Series series = new Series("Pekerjaan");
            series.ChartType = SeriesChartType.Column;
            series.Legend = "Legenda"; // Harus sama dengan legend yang dibuat
            series.XValueType = ChartValueType.String;

            // Tambahkan data dari datatable
            foreach (DataRow row in dt.Rows)
            {
                string agama = row["pekerjaan"].ToString();
                int jumlah = Convert.ToInt32(row["jumlah"]);
                series.Points.AddXY(agama, jumlah);
            }

            // Label dan teks legend
            series.Label = "#VALY";         // Label pada batangnya
            series.LegendText = "#VALX";    // Teks legenda

            barChartPekerjaan.Series.Add(series);
            barChartPekerjaan.Titles.Add("Distribusi Pekerjaan Penduduk");
        }
        private void Penduduk_frm_Load(object sender, EventArgs e)
        {
            loadBarChartPekerjaan();
            loadPieChart();
            loadBarChartAgama();
            loadPieChartPerkawinan();
            tampilGrid();
            LoadPekerjaan();
            user.Text = usr;

            agama_combobox.Items.Add("Islam");
            agama_combobox.Items.Add("Kristen");
            agama_combobox.Items.Add("Katolik");
            agama_combobox.Items.Add("Hindu");
            agama_combobox.Items.Add("Buddha");
            agama_combobox.Items.Add("Konghucu");

            cmbStatusPerkawinan.Items.Add("Sudah Kawin");
            cmbStatusPerkawinan.Items.Add("Belum Kawin");
            cmbStatusPerkawinan.Items.Add("Cerai Hidup");
            cmbStatusPerkawinan.Items.Add("Cerai Mati");
        }
        void tampilGrid()
        {
            // Menentukan sumber data berdasarkan kondisi pencarian
            if (cari_textbox.Text.Length == 0)
            {
                penduduk_dgv.DataSource = pen.tampilSemua();
            }
            else
            {
                penduduk_dgv.DataSource = pen.tampilBynama(cari_textbox.Text);
            }
            if (penduduk_dgv.Columns.Count >= 14)
            {
                penduduk_dgv.Columns[8].Visible = false;  // tempat_lahir
                penduduk_dgv.Columns[9].Visible = false;  // tanggal_lahir
                penduduk_dgv.Columns[10].Visible = false; // alamat
                penduduk_dgv.Columns[11].Visible = false; // rt
                penduduk_dgv.Columns[12].Visible = false; // rw
                penduduk_dgv.Columns[13].Visible = false; // id_pekerjaan
            }


            // Terapkan warna selang-seling
            gridBelang(penduduk_dgv);
        }



        private void penduduk_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void gridBelang(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (row.Index % 2 == 0)
                    {
                        cell.Style.BackColor = Color.White;
                    }
                    else
                    {
                        cell.Style.BackColor = Color.LightGray;
                    }
                }
            }
        }
        private void cari_textbox_TextChanged(object sender, EventArgs e)
        {
            tampilGrid();
        }

        private void nik_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && nik_textbox.Text.Length >= 10)
            {
                nama_textbox.Focus(); // Pindah ke nama_textbox
            }
        }

        private void nama_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tempatlahir_textbox.Focus(); // Pindah ke TextBox berikutnya
            }
        }

        private void tempatlahir_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pekerjaan_cmb.Focus(); 
            }
        }

        private void pekerjaan_cmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                alamat_textbox.Focus();
            }
        }

        private void alamat_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                laki_radiobutton.Focus();
            }
        }
        
        private void laki_radiobutton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tanggallahir_datepicker.Focus();
            }
        }
        
        private void tanggallahir_datepicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agama_combobox.Focus();
            }
        }
        
        private void agama_combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbStatusPerkawinan.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }

        private void agama_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }

        private void cari_textbox_TextChanged_1(object sender, EventArgs e)
        {
            tampilGrid();
        }

        private void hapus_button_Click_1(object sender, EventArgs e)
        {
            if (pen.isExist(nik_textbox.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin hapus data?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (pen.deleteData(nik_textbox.Text) > 0)
                    {
                        MessageBox.Show("Data Berhasil di Hapus", "HAPUS DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tampilGrid();
                        loadBarChartPekerjaan();
                        loadPieChart();
                        loadBarChartAgama();
                        loadPieChartPerkawinan();
                        //id_textbox.Text = des.createCode();
                    }
                    else
                    {
                        MessageBox.Show("Data Gagagl di Hapus", "HAPUS DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    nik_textbox.Focus();
                }
            }
        }

        private void simpan_button_Click_1(object sender, EventArgs e)
        {
            if (!pen.isExist(nik_textbox.Text))
            {
                string jenisKelamin = "";
                string agamaDipilih = agama_combobox.SelectedItem?.ToString();

                pen.Nik = nik_textbox.Text;
                pen.Nama = nama_textbox.Text;

                if (laki_radiobutton.Checked)
                {
                    jenisKelamin = laki_radiobutton.Text;
                }
                else if (perempuan_radiobutton.Checked)
                {
                    jenisKelamin = perempuan_radiobutton.Text;
                }

                pen.Jenis_kelamin = jenisKelamin;
                pen.Tempat_lahir = tempatlahir_textbox.Text;
                pen.Tanggal_lahir = tanggallahir_datepicker.Value.ToString("yyyy-MM-dd");
                pen.Agama = agamaDipilih;

                pen.Status_perkawinan = cmbStatusPerkawinan.SelectedItem?.ToString();
                //pen.Pekerjaan = pekerjaan_cmb.Text;
                pen.Pekerjaan = pekerjaan_cmb.SelectedValue.ToString();
                pen.Alamat = alamat_textbox.Text;
                pen.Rt = rt_textbox.Text;
                pen.Rw = rw_textbox.Text;
                if (pen.saveData() > 0)
                {
                    MessageBox.Show("Data Berhasil di Simpan", "SIMPAN DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tampilGrid();
                    loadBarChartPekerjaan();
                    loadPieChart();
                    loadBarChartAgama();
                    loadPieChartPerkawinan();
                    //id_textbox.Text = des.createCode();
                }
                else
                {
                    MessageBox.Show("Data Gagal di Simpan", "SIMPAN DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                nik_textbox.Focus();
            }
            else
            {
                if (pen.isExist(nik_textbox.Text) == true)
                {
                    pen.Nik = nik_textbox.Text;
                    string jenisKelamin = "";
                    string status_perkawinan = "";
                    string agamaDipilih = agama_combobox.SelectedItem?.ToString();

                    //pen.Nik = nik_textbox.Text;
                    pen.Nama = nama_textbox.Text;

                    if (laki_radiobutton.Checked)
                    {
                        jenisKelamin = laki_radiobutton.Text;
                    }
                    else if (perempuan_radiobutton.Checked)
                    {
                        jenisKelamin = perempuan_radiobutton.Text;
                    }

                    pen.Jenis_kelamin = jenisKelamin;
                    pen.Tempat_lahir = tempatlahir_textbox.Text;
                    pen.Tanggal_lahir = tanggallahir_datepicker.Value.ToString("yyyy-MM-dd");
                    pen.Agama = agamaDipilih;

                    pen.Status_perkawinan = cmbStatusPerkawinan.SelectedItem?.ToString();
                    //pen.Pekerjaan = pekerjaan_textbox.Text;
                    pen.Pekerjaan = pekerjaan_cmb.SelectedValue.ToString();
                    pen.Alamat = alamat_textbox.Text;
                    pen.Rt = rt_textbox.Text;
                    pen.Rw = rw_textbox.Text;
                    //des.Id_kecamatan = kecamatan_cb.SelectedValue.ToString();

                    if (pen.updateData(nik_textbox.Text) > 0)
                    {
                        MessageBox.Show(
                            "Data berhasil diupdate.",
                            "UPDATE DATA",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
                        tampilGrid();
                        loadBarChartPekerjaan();
                        loadPieChart();
                        loadBarChartAgama();
                        loadPieChartPerkawinan();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Data tidak berhasil diupdate.",
                            "UPDATE DATA",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
                    }
                    nik_textbox.Focus();
                }
                else
                {
                    MessageBox.Show("Data yang anda inputkan tidak ada");
                }
            }
        }

        private void penduduk_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow baris = this.penduduk_dgv.Rows[e.RowIndex];

                // Data utama
                nik_textbox.Text = baris.Cells[0].Value.ToString();
                nama_textbox.Text = baris.Cells[1].Value.ToString();
                pekerjaan_cmb.Text = baris.Cells[6].Value.ToString();

                // Tempat & Tanggal Lahir (versi mentah)
                tempatlahir_textbox.Text = baris.Cells[8].Value.ToString();

                DateTime tanggalLahir;
                if (DateTime.TryParse(baris.Cells[9].Value.ToString(), out tanggalLahir))
                {
                    tanggallahir_datepicker.Value = tanggalLahir;
                }

                // Alamat lengkap (versi mentah)
                alamat_textbox.Text = baris.Cells[10].Value.ToString();
                rt_textbox.Text = baris.Cells[11].Value.ToString();
                rw_textbox.Text = baris.Cells[12].Value.ToString();

                // RadioButton - Jenis Kelamin
                string jenisKelamin = baris.Cells[2].Value.ToString();
                if (jenisKelamin == "L") laki_radiobutton.Checked = true;
                else if (jenisKelamin == "P") perempuan_radiobutton.Checked = true;

                // ComboBox - Agama
                agama_combobox.SelectedItem = baris.Cells[4].Value.ToString();
                cmbStatusPerkawinan.SelectedItem = baris.Cells[5].Value.ToString();
            }
        }
    }
}
