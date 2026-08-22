using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace siptera.view
{
    public partial class Splash : Form
    {
        byte i = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 5)
            {
                timer1.Enabled = false;
                Login_frm login = new Login_frm();
                login.Show();
                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
