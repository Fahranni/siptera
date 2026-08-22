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
    public partial class pekerjaan : Form
    {
        Pekerjaan_cls pekerja = new Pekerjaan_cls();
        public pekerjaan()
        {
            InitializeComponent();
        }
        void tampilkanGrid()
        {
            if (cari_Txt.Text.Length == 0)
            {
                pekerjaan_dgv.DataSource = pekerja.tampilSemua();
            }
            else
            {
                pekerjaan_dgv.DataSource = pekerja.tampilByNama(cari_Txt.Text);
            }
            if (pekerjaan_dgv.Columns.Contains("id_pekerjaan"))
            {
                pekerjaan_dgv.Columns["id_pekerjaan"].Visible = false;
            }

            //gridBelang(keluarga_dgv);
        }
        private void pekerjaan_Load(object sender, EventArgs e)
        {
            tampilkanGrid();
        }

        private void cari_Txt_TextChanged(object sender, EventArgs e)
        {
            tampilkanGrid();
        }
        private void simpan_btn_Click_1(object sender, EventArgs e)
        {
            if (!pekerja.isExist(id_txt.Text))
            {
                pekerja.Nama_pekerjaan = nama_Txt.Text;
                if (pekerja.saveData() > 0)
                {
                    MessageBox.Show("Data berhasil disimpan",
                        "Simpan data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tampilkanGrid();
                }
                else
                {
                    MessageBox.Show("Data gagal disimpan",
                        "Gagal disimpan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                    pekerja.Nama_pekerjaan = nama_Txt.Text;
                    //kel.Id_kecamatan = kecDrop.SelectedValue.ToString();

                    if (pekerja.updateData(id_txt.Text) > 0)
                    {
                        MessageBox.Show(
                            "Data berhasil diupdate.",
                            "UPDATE DATA",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
                        tampilkanGrid();
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
                    nama_Txt.Focus();
                }
        }

        private void hapus_btn_Click(object sender, EventArgs e)
        {
                //kel.Id_keluarga = idKel_Txt.Text;
                pekerja.Id_pekerjaan = id_txt.Text;
                pekerja.Nama_pekerjaan = nama_Txt.Text;
                if (pekerja.deleteData(id_txt.Text) > 0)
                {
                    MessageBox.Show(
                        "Data berhasil dihapus.",
                        "HAPUS DATA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    tampilkanGrid();
                    
                }
                else
                {
                    MessageBox.Show(
                        "Data tidak berhasil dihapus.",
                        "HAPUS DATA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                }
                nama_Txt.Focus();
        }

        private void pekerjaan_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{
            //    DataGridViewRow baris = this.pekerjaan_dgv.Rows[e.RowIndex];
            //    //idKel_Txt.Text = baris.Cells[0].Value.ToString();
            //    nama_Txt.Text = baris.Cells[0].Value.ToString();

            //}
        }

        private void clear_Txt_Click(object sender, EventArgs e)
        {
            
            nama_Txt.Text = "";
            id_txt.Text = "";
            nama_Txt.Focus();
        }

        private void pekerjaan_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow baris = this.pekerjaan_dgv.Rows[e.RowIndex];
                //idKel_Txt.Text = baris.Cells[0].Value.ToString();
                id_txt.Text = baris.Cells[0].Value.ToString();
                nama_Txt.Text = baris.Cells[1].Value.ToString();

            }
        }

        private void nama_Txt_TextChanged(object sender, EventArgs e)
        {
            tampilkanGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cari_Txt.Text = "";
            tampilkanGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }
    }
}
    

    

