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
    public partial class Frm_DoctorMain : Form
    {
        public Frm_DoctorMain()
        {
            InitializeComponent();
        }

        private void Frm_DoctorMain_Load(object sender, EventArgs e)
        {

        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            var vTc = Conn.db.Tbl_Doctor.FirstOrDefault(x => x.Doctor_TC == msk_TC.Text);
            if (vTc!=null)
            {
                if (vTc.Doctor_Password==txt_Password.Text)
                {
                    Frm_Doctor fr = new Frm_Doctor();
                    fr.sTc = msk_TC.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı şifre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bütün alanları eksiksiz doldurunuz.");
            }
        }
    }
}
