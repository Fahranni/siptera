using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using siptera.connection;
using siptera.model;
using siptera.koneksi;
using siptera.model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;

namespace siptera.view
{
    public partial class LihatPengajuan : Form
    {
        LihatPengajuan_cls model = new LihatPengajuan_cls(); 
        string query;
        public LihatPengajuan()
        {
            InitializeComponent();
        }

        private void loadPieChart()
        {
            LihatPengajuan_cls pengajuan = new LihatPengajuan_cls();
            DataTable dt = pengajuan.getJumlahStatus();

            // Bersihkan chart
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            // Tambah legend (namanya boleh apa saja)
            Legend legend = new Legend("Legenda");
            chart1.Legends.Add(legend);

            // Series
            Series series = new Series("Status");
            series.ChartType = SeriesChartType.Pie;
            series.Legend = "Legenda"; // Penting: cocokkan dengan nama legend

            foreach (DataRow row in dt.Rows)
            {
                string jenis = row["status"].ToString();
                int jumlah = Convert.ToInt32(row["jumlah"]);
                series.Points.AddXY(jenis, jumlah);
            }

            // Label dan Legend Text
            series.Label = "#VALX: #VAL";
            series.LegendText = "#VALX";

            chart1.Series.Add(series);
            chart1.Titles.Add("Distribusi Data Status");
        }
        private void LihatPengajuan_Load(object sender, EventArgs e)
        {
            loadPieChart();
            loadChartPerBulan();
            dataGridViewPengajuan.DataSource = model.GetSemuaPengajuan();
            this.BackColor = ColorTranslator.FromHtml("#3399FF");

            if (dataGridViewPengajuan.Columns.Contains("id_pengajuan"))
            {
                dataGridViewPengajuan.Columns["id_pengajuan"].Visible = false;
            }
        }

        private void loadChartPerBulan()
        {
            LihatPengajuan_cls pengajuan = new LihatPengajuan_cls();
            DataTable dt = pengajuan.getJumlahPerBulan();

            chart2.Series.Clear();
            chart2.Titles.Clear();
            chart2.Legends.Clear();

            // Tambah Legend
            Legend legend = new Legend("Legenda");
            chart2.Legends.Add(legend);

            // Tambah Series
            Series series = new Series("Pengajuan Per Bulan");
            series.ChartType = SeriesChartType.Column; // Bisa Column, Line, dll
            series.Legend = "Legenda";

            foreach (DataRow row in dt.Rows)
            {
                string bulan = row["Bulan"].ToString();
                int jumlah = Convert.ToInt32(row["Jumlah"]);
                series.Points.AddXY(bulan, jumlah);
            }

            series.Label = "#VAL";         // Tampilkan jumlah di atas bar
            series.LegendText = "Jumlah";  // Nama di legend

            chart2.Series.Add(series);
            chart2.Titles.Add("Pengajuan Per Bulan");
        }




        private void dataGridViewPengajuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewPengajuan_CellClick(object sender, DataGridViewCellEventArgs e)//saat setuju/tolak diklik
        {
            if (e.RowIndex < 0) return;//jika user klik bukan baris data tidak akan menjalankan apapun(mencegah eror) 

            // Ambil nilai ID dari baris
            string idPengajuan = dataGridViewPengajuan.Rows[e.RowIndex].Cells["id_pengajuan"].Value?.ToString();//ambil id_pengajuan dan status untuk data yg diklik
            string status = dataGridViewPengajuan.Rows[e.RowIndex].Cells["status"].Value?.ToString().ToLower();

            if (status == "disetujui" || status == "ditolak")//jika status sudah disetujui/tolak maka:
            {
                MessageBox.Show("Pengajuan ini sudah dikonfirmasi dan tidak dapat diubah lagi", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kolom tombol "Setujui"
            if (dataGridViewPengajuan.Columns[e.ColumnIndex].Name == "setujui")//jika klik setuju
            {
                DialogResult confirm = MessageBox.Show("Setujui pengajuan ini?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    updateStatusPengajuan(idPengajuan, "disetujui");//update statu
                }
            }

            if (dataGridViewPengajuan.Columns[e.ColumnIndex].Name == "tolak")
            {
                Alasan_Penolakan formAlasan = new Alasan_Penolakan();
                if (formAlasan.ShowDialog() == DialogResult.OK)
                {
                    string alasan = formAlasan.Alasan;//tampilkan form alasan penolakan
                    updateStatusPengajuan(idPengajuan, "ditolak", alasan);
                }
            }
        }
        private void LoadDataPengajuan()//menampilkan data ke datagrid
        {
            dataGridViewPengajuan.DataSource = model.GetSemuaPengajuan();//mengambil data pengajuan dari database kemudian ditampilkan ke dalam datagrid

            if (dataGridViewPengajuan.Columns.Contains("id_pengajuan"))
            {
                dataGridViewPengajuan.Columns["id_pengajuan"].Visible = false;
            }
        }


        private void updateStatusPengajuan(string idPengajuan, string statusBaru, string alasan = null)//mengubah status pengajuan
        {
            var row = model.GetPengajuanById(idPengajuan);//cek apakah data pemgajuan ada?

            if (row != null)//jika pengajuan ada(tidak kosong)
            {
                if (statusBaru == "disetujui")//jika disetujui
                {
                    bool sinkron = model.SinkronKePenduduk(row);//menyingkronkan data dari pengajuan ke tabel penduduk
                    if (!sinkron)//jika gagal
                    {
                        MessageBox.Show("NIK tidak ditemukan di tabel penduduk.");
                        return;
                    }
                }

                bool sukses = model.UpdateStatus(idPengajuan, statusBaru, alasan); //ika status berhasil
                if (sukses)
                {
                    MessageBox.Show("Status berhasil diubah menjadi: " + statusBaru);
                    LoadDataPengajuan();
                }
                else//jika gagal
                {
                    MessageBox.Show("Gagal mengubah status.");
                }
            }
            else//jika data tidak ditemukan
            {
                MessageBox.Show("Data pengajuan tidak ditemukan.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cariAlamat_TextChanged(object sender, EventArgs e)
        {
            dataGridViewPengajuan.DataSource = model.GetPengajuanByAlamat(cariAlamat.Text);//memangggil fungsi dari model untuk mengambil data
        }

        private void button2_Click(object sender, EventArgs e)//fungsi refresh
        {
            penduduk_cmb.SelectedIndex = -1;
            cariAlamat.Text = "";
            cariKK.Text = "";
            dataGridViewPengajuan.DataSource = model.GetSemuaPengajuan();
        }

        private void cariKK_TextChanged(object sender, EventArgs e)
        {
            dataGridViewPengajuan.DataSource = model.GetPengajuanByNama(cariKK.Text);
        }

        private void penduduk_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string statusDipilih = penduduk_cmb.SelectedItem?.ToString();
            dataGridViewPengajuan.DataSource = model.GetPengajuanByStatus(statusDipilih);
        }

        private void kembali_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }
    }
}
