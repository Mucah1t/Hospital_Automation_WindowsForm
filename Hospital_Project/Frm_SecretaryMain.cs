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
    public partial class Frm_SecretaryMain : Form
    {
        public Frm_SecretaryMain()
        {
            InitializeComponent();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            var vTC = Conn.db.Tbl_Secretary.FirstOrDefault(x => x.Secretary_TC == msk_TC.Text);
            //var vPass = Conn.db.Tbl_Patient.FirstOrDefault(x => x.Patient_Password == txt_Password.Text);

            if (vTC != null)
            {
                if (vTC.Secretary_Password == txt_Password.Text)
                {
                    Frm_Secretary fr = new Frm_Secretary();
                    fr.sTC = msk_TC.Text;   
                    fr.Show();
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
