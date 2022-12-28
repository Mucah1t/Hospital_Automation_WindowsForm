using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Hospital_Project
{
    public partial class Frm_Patient : Form
    {
        public Frm_Patient()
        {
            InitializeComponent();
        }

        private void lnk_Sign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_PatienceRegister fr = new Frm_PatienceRegister();
            fr.Show();

        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
           
            var vTC = Conn.db.Tbl_Patient.FirstOrDefault(x=>x.Patient_Tc==msk_TC.Text);
            //var vPass = Conn.db.Tbl_Patient.FirstOrDefault(x => x.Patient_Password ==txt_Password.Text);

            if (vTC!=null)
            {
                if (vTC.Patient_Password== txt_Password.Text)
                {
                    Frm_PatientControl fr = new Frm_PatientControl();
                    fr.tc = msk_TC.Text;
                    fr.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı şifre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                MessageBox.Show("Lütfen bütün alanları eksiksiz doldurunuz.");
            }

        }

        private void Frm_Patient_Load(object sender, EventArgs e)
        {

        }
    }
}
