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
    public partial class Frm_PatienceRegister : Form
    {
        public Frm_PatienceRegister()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Tbl_Patient add = new Tbl_Patient();
            add.Patient_Name = txt_Name.Text;
            add.Patient_LastName = txt_LastName.Text;
            add.Patient_Tc = msk_TC.Text.ToString();
            add.Patient_Phone = msk_Phone.Text.ToString();
            add.Patient_Password = txt_Password.Text;
            add.Patient_Gender = cmb_Gender.SelectedItem.ToString();

            Conn.db.Tbl_Patient.Add(add);
            Conn.db.SaveChanges();
            MessageBox.Show("Kaydınız yapılmışıtr.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Frm_PatienceRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
