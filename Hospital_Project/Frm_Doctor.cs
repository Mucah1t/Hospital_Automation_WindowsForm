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
    public partial class Frm_Doctor : Form
    {
        public Frm_Doctor()
        {
            InitializeComponent();
        }
        public string sTc;
        private void Frm_Doctor_Load(object sender, EventArgs e)
        {
            //Assigning ID number from previous form by means of property of this form 
            lbl_TC.Text = sTc;

            //Taking name of doctor via LinQ
            var vTc = Conn.db.Tbl_Doctor.FirstOrDefault(x => x.Doctor_TC == sTc);
            lbl_Name.Text = vTc.Doctor_Name + " " + vTc.Doctor_LastName;

            //CRUD Operaions (Listing) appointment acc. to related doctor
            var query = from item in Conn.db.Tbl_Appoinment.Where(x => x.Appointment_Doctor == lbl_Name.Text)
                        select new
                        {
                            item.Appoinment_Date,
                            item.Appointment_Time,
                            item.Patient_Symptom
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Frm_DoctorUpdate fr = new Frm_DoctorUpdate();
            fr.sTC = lbl_TC.Text;
            fr.Show();
            
        }

        private void btn_Announcement_Click(object sender, EventArgs e)
        {
            Frm_Annoncument fr = new Frm_Annoncument();
            fr.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rtxtbox_Symptom.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
