using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using siptera.koneksi;
using siptera.connection;

namespace siptera.view
{
    public partial class Alasan_Penolakan : Form
    {
        public string Alasan { get; private set; }
        public Alasan_Penolakan()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAlasan.Text)) 
            {
                MessageBox.Show("Silakan isi alasan penolakan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Alasan = txtAlasan.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Alasan_Penolakan_Click(object sender, EventArgs e)
        {

        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Alasan_Penolakan_Load(object sender, EventArgs e)
        {

        }
    }
}
