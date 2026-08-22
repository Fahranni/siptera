using System;
using System.Collections;
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
    public partial class keluarga : Form
    {
        Keluarga_cls kel = new Keluarga_cls();
        public keluarga()
        {
            InitializeComponent();
        }

        void tampilkanGrid()
        {
            //if (cari_Txt.Text.Length == 0)
            //keluarga_dgv.Columns["id_keluarga"].Visible = false;
            keluarga_dgv.DataSource = kel.tampilSemua();
            //keluarga_dgv.Columns["id_keluarga"].Visible = false;
            //}
            //else
            //{
            //    keluarga_dgv.DataSource = kel.tampilByNomer(cari_Txt.Text);
            //}
            //gridBelang(keluarga_dgv);
        }
        
        private void keluarga_Load(object sender, EventArgs e)
        {
            tampilkanGrid();
            this.BackColor = ColorTranslator.FromHtml("#3399FF");
        }
        private void cari_Txt_TextChanged(object sender, EventArgs e)
        {
            tampilkanGrid();
        }
        //private void idKel_Txt_TextChanged(object sender, EventArgs e)
        //{
        //    if (idK_Txt.Text.Length == 2)
        //    {
        //        noKK_Txt.Text = kel.ambilnoKK(idKel_Txt.Text);
        //    }
        //    else
        //    {
        //        noKK_Txt.Clear();
        //    }
        //}

        private void simpan_btn_Click(object sender, EventArgs e)
        {
            if (!kel.isExist(noKK_Txt.Text))
                {
                //kel.Id_keluarga = idKel_Txt.Text;
                kel.No_kk = noKK_Txt.Text;
                kel.Alamat = alamat_Txt.Text;
                kel.RT = rt_Txt.Text;
                kel.RW = rw_Txt.Text;
                if (kel.saveData() > 0)
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
            }else
            {
                if (kel.isExist(noKK_Txt.Text) == true)
                {
                    kel.No_kk = noKK_Txt.Text;
                    kel.Alamat = alamat_Txt.Text;
                    kel.RT = rt_Txt.Text;
                    kel.RW = rw_Txt.Text;
                    //kel.Id_kecamatan = kecDrop.SelectedValue.ToString();

                    if (kel.updateData(noKK_Txt.Text) > 0)
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
                    noKK_Txt.Focus();
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            ////kel.Id_keluarga = idKel_Txt.Text;
            //kel.No_kk = noKK_Txt.Text;
            //kel.Alamat = alamat_Txt.Text;
            //kel.RT = rt_Txt.Text;
            //kel.RW = rw_Txt.Text;
            //if (kel.updateData(noKK_Txt.Text) > 0)
            //{
            //    MessageBox.Show("Data berhasil diedit",
            //        "Simpan data",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information);
            //    tampilkanGrid();
            //}
            //else
            //{
            //    MessageBox.Show("Data gagal diUpdate",
            //        "Gagal disimpan",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}
            //noKK_Txt.Focus();
        }
        private void hapus_btn_Click(object sender, EventArgs e)
        {
            if (kel.isExist(noKK_Txt.Text) == true)
            {
                //kel.Id_keluarga = idKel_Txt.Text;
                kel.No_kk = noKK_Txt.Text;
                kel.Alamat = alamat_Txt.Text;
                kel.RT = rt_Txt.Text;
                kel.RW = rw_Txt.Text;
                if (kel.deleteData(noKK_Txt.Text) > 0)
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
                noKK_Txt.Focus();
            }
            else
            {
                MessageBox.Show("Data yang anda inputkan tidak ada");
            }
        }
        private void keluarga_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{
            //    DataGridViewRow baris = this.keluarga_dgv.Rows[e.RowIndex];
            //    idKel_Txt.Text = baris.Cells[0].Value.ToString();
            //    noKK_Txt.Text = baris.Cells[1].Value.ToString();
            //    alamat_Txt.Text = baris.Cells[2].Value.ToString();
            //    rt_Txt.Text = baris.Cells[3].Value.ToString();
            //    rw_Txt.Text = baris.Cells[4].Value.ToString();
            //}
        }

        private void keluarga_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow baris = this.keluarga_dgv.Rows[e.RowIndex];
                //idKel_Txt.Text = baris.Cells[0].Value.ToString();
                noKK_Txt.Text = baris.Cells[0].Value.ToString();
                alamat_Txt.Text = baris.Cells[1].Value.ToString();
                rt_Txt.Text = baris.Cells[2].Value.ToString();
                rw_Txt.Text = baris.Cells[3].Value.ToString();
            }

            modalbox.Visible = true;
            panel4.Visible = true;
            string no_kk;
            no_kk = noKK_Txt.Text;
            anggota_dgv.DataSource = kel.tampilAnggotaKeluarga(no_kk);

        }

        private void clear_Txt_Click(object sender, EventArgs e)
        {
            noKK_Txt.Text = "";
            alamat_Txt.Text = "";
            rt_Txt.Text = "";
            rt_Txt.Text = "";
            noKK_Txt.Focus();
        }

        private void kembali_btn_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void noKK_Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                alamat_Txt.Focus();
            }
        }

        private void alamat_Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rt_Txt.Focus();
            }
        }

        private void rt_Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rw_Txt.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kel.isExist(noKK_Txt.Text) == true)
            {
                //kel.Id_keluarga = idKel_Txt.Text;
                kel.No_kk = noKK_Txt.Text;
                kel.Alamat = alamat_Txt.Text;
                kel.RT = rt_Txt.Text;
                kel.RW = rw_Txt.Text;
                if (kel.deleteData(noKK_Txt.Text) > 0)
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
                noKK_Txt.Focus();
            }
            else
            {
                MessageBox.Show("Data yang anda inputkan tidak ada");
            }
        }

        private void tambah_btn_Click(object sender, EventArgs e)
        {
            if (!kel.isExist(noKK_Txt.Text))
            {
                //kel.Id_keluarga = idKel_Txt.Text;
                kel.No_kk = noKK_Txt.Text;
                kel.Alamat = alamat_Txt.Text;
                kel.RT = rt_Txt.Text;
                kel.RW = rw_Txt.Text;
                if (kel.saveData() > 0)
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
                if (kel.isExist(noKK_Txt.Text) == true)
                {
                    kel.No_kk = noKK_Txt.Text;
                    kel.Alamat = alamat_Txt.Text;
                    kel.RT = rt_Txt.Text;
                    kel.RW = rw_Txt.Text;
                    //kel.Id_kecamatan = kecDrop.SelectedValue.ToString();

                    if (kel.updateData(noKK_Txt.Text) > 0)
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
                    noKK_Txt.Focus();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cariKK_TextChanged(object sender, EventArgs e)
        {
            keluarga_dgv.DataSource = kel.tampilByNomer(cariKK.Text);
        }

        private void cariAlamat_TextChanged(object sender, EventArgs e)
        {
            keluarga_dgv.DataSource = kel.tampilByAlamat(cariAlamat.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tampilkanGrid();
            cariAlamat.Text = "";
            cariKK.Text = "";
        }

        private void tutup_btn_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            modalbox.Visible = false;
            panel4.Visible = false;
        }
    }
}

