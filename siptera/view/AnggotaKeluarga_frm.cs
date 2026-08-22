using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sipen.koneksi;
using siptera.connection;
using siptera.koneksi;
using siptera.model;

namespace siptera.view
{

    public partial class AnggotaKeluarga_frm : Form
    {
        KonekServer_cls server = new KonekServer_cls();

        public AnggotaKeluarga_frm()
        {
            InitializeComponent();
        }
        AnggotaKeluarga_cls angkel = new AnggotaKeluarga_cls();
        private void tambah_btn_Click(object sender, EventArgs e)
        {
            if (!angkel.isExist(id_hidden.Text))
            {



                angkel.Id_keluarga = keluarga_cmb.SelectedValue.ToString();
                angkel.Id_penduduk = penduduk_cmb.SelectedValue.ToString();
                angkel.Hubungan_dalam_keluarga = cmb_hubungan.SelectedItem?.ToString();

                if (angkel.saveData() > 0)
                {
                    MessageBox.Show("Data Berhasil disimpan^^",
                        "SIMPAN DATA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    tampilkanGrid();
                    loadComboPenduduk();
                    loadPieChart();
                }
                else
                {
                    MessageBox.Show("Data GAGAL disimpan :(",
                        "SIMPAN DATA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                angkel.Id_keluarga = keluarga_cmb.SelectedValue.ToString();
                angkel.New_penduduk = new_idPenduduk.ToString();
                angkel.Hubungan_dalam_keluarga = cmb_hubungan.SelectedItem?.ToString();

                if (angkel.updateData(id_hidden.Text) > 0)
                {
                    MessageBox.Show("Data berhasil diubah^^",
                        "UBAH DATA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    tampilkanGrid();
                    loadComboPenduduk();
                    loadPieChart();
                }
                else
                {
                    MessageBox.Show("Data gagal diubah :(",
                        "UBAH DATA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                keluarga_cmb.Focus();
            }
                keluarga_cmb.Focus();
        }
        void tampilkanGrid()
        {
            dataGridView1.DataSource = angkel.tampilSemua();
            dataGridView1.Columns["id_keluarga"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;
            gridBelang(dataGridView1);
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

        private void hapus_btn_Click(object sender, EventArgs e)
        {

            angkel.Id_keluarga = keluarga_cmb.SelectedValue.ToString();
            angkel.Id_penduduk = penduduk_cmb.SelectedValue.ToString();
            angkel.Hubungan_dalam_keluarga = cmb_hubungan.SelectedItem?.ToString();

            if (angkel.deleteData(id_hidden.Text) > 0)
            {
                MessageBox.Show("Data berhasil dihapus^^",
                    "HAPUS DATA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                tampilkanGrid();
                loadComboPenduduk();
                loadPieChart();
            }
            else
            {
                MessageBox.Show("Data gagal dihapus :(",
                    "HAPUS DATA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            keluarga_cmb.Focus();
        }

        private void batal_btn_Click(object sender, EventArgs e)
        {
            {
                bersihkan();
                keluarga_cmb.Focus();
                penduduk_cmb.Focus();
                cmb_hubungan.Focus();
            }
            void bersihkan()
            {
                keluarga_cmb.SelectedIndex = -1;
                penduduk_cmb.SelectedIndex = -1;
                cmb_hubungan.SelectedIndex = -1;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow baris = this.dataGridView1.Rows[e.RowIndex];

                id_hidden.Text = baris.Cells[4].Value.ToString();

                keluarga_cmb.SelectedValue = baris.Cells[0].Value.ToString();   // id_keluarga
                new_idPenduduk.Text = baris.Cells[2].Value.ToString();            // nama penduduk
                cmb_hubungan.Text = baris.Cells[3].Value.ToString();

            }

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tampilkanGrid();
        }

        private void AnggotaKeluarga_frm_Click(object sender, EventArgs e)
        {
            tampilkanGrid();
        }

        private void cari_txt_TextChanged(object sender, EventArgs e)
        {
            //tampilkanGrid();
            dataGridView1.DataSource = angkel.tampilByNama(cari_txt.Text);
        }

        private void tutup_btn_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }

        private void AnggotaKeluarga_frm_Load(object sender, EventArgs e)
        {
            loadPieChart();
            tampilkanGrid();
            loadComboKeluarga();
            loadComboPenduduk();
            id_hidden.Visible = false;
            this.BackColor = ColorTranslator.FromHtml("#3399FF");
        }
        private void loadPieChart()
        {
            AnggotaKeluarga_cls angkel = new AnggotaKeluarga_cls();
            DataTable dt = angkel.getJumlahHub();

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
                string jenis = row["hubungan_dalam_keluarga"].ToString();
                int jumlah = Convert.ToInt32(row["jumlah"]);
                series.Points.AddXY(jenis, jumlah);
            }

            // Label dan Legend Text
            series.Label = "#VALX: #PERCENT";
            series.LegendText = "#VALX";

            chart1.Series.Add(series);
            chart1.Titles.Add("Distribusi Jenis Kelamin Penduduk");
        }
        void loadComboPenduduk(string id_keluarga)
        {
            string query = @"
        SELECT p.id_penduduk, p.nama 
        FROM anggota_keluarga ak
        JOIN penduduk p ON ak.id_penduduk = p.id_penduduk
        WHERE ak.id_keluarga = '" + id_keluarga + @"'
        ORDER BY p.nama ASC"; // ✅ Urut berdasarkan abjad A-Z

            DataTable dt = server.eksekusiQuery(query);

            penduduk_cmb.DataSource = dt;
            penduduk_cmb.DisplayMember = "nama";         // yang ditampilkan di ComboBox
            penduduk_cmb.ValueMember = "id_penduduk";    // yang jadi value-nya
        }

        void loadComboKeluarga(string id_penduduk)
        {
            string query = @"
        SELECT p.id_keluarga, p.nama 
        FROM anggota_keluarga ak
        JOIN keluarga p ON ak.id_keluarga = p.id_keluarga
        WHERE ak.id_keluarga = '" + id_penduduk + "'";

            DataTable dt = server.eksekusiQuery(query);

            penduduk_cmb.DataSource = dt;
            penduduk_cmb.DisplayMember = "nama";         // tampilkan nama
            penduduk_cmb.ValueMember = "id_keluarga";    // ambil id_penduduk
        }

        void loadComboPenduduk()
        {
            string query = @"
        SELECT id_penduduk, nama 
        FROM penduduk 
        WHERE id_penduduk NOT IN (
            SELECT id_penduduk FROM anggota_keluarga
        )";

            DataTable dt = server.eksekusiQuery(query);
            penduduk_cmb.DataSource = dt;
            penduduk_cmb.DisplayMember = "nama";          // yang ditampilkan di combo box
            penduduk_cmb.ValueMember = "id_penduduk";     // value yang digunakan (ID)
        }

        void loadComboKeluarga()
        {
            DataTable dt = server.eksekusiQuery("SELECT id_keluarga, no_kk FROM keluarga");
            keluarga_cmb.DataSource = dt;
            keluarga_cmb.DisplayMember = "no_kk";         // ✅ ganti dari 'nama' ke 'no_kk'
            keluarga_cmb.ValueMember = "id_keluarga";     // value yang diambil
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cariNIK_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = angkel.tampilByNIK(cariNIK.Text);
            dataGridView1.Columns["id_keluarga"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = angkel.tampilSemua();
            cariNIK.Text = "";
            cari_txt.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void cariNIK_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = angkel.tampilByNIK(cariNIK.Text);
            dataGridView1.Columns["id_keluarga"].Visible = false;
            //dataGridView1.Columns["id"].Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hubungan = comboBox1.SelectedItem?.ToString();
            dataGridView1.DataSource = angkel.tampilByHub(hubungan);
            dataGridView1.Columns["id_keluarga"].Visible = false;
            //dataGridView1.Columns["id"].Visible = false;
        }
    }
    }
