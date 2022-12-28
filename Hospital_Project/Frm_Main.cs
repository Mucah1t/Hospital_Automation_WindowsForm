using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Project
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Patient fr = new Frm_Patient();
            fr.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Doctor_Click(object sender, EventArgs e)
        {
            Frm_DoctorMain fr = new Frm_DoctorMain();
            fr.Show();
            this.Hide();
        }

        private void btn_Secretary_Click(object sender, EventArgs e)
        {
            Frm_SecretaryMain fr = new Frm_SecretaryMain();
            fr.Show();
            this.Hide();
        }
    }
}
