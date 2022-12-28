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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            lbl_totalAppoint.Text = Conn.db.Tbl_Appoinment.Count().ToString();

        }

       

        private void btn_TotDoc_Click(object sender, EventArgs e)
        {
            lbl_totalDoc.Text = Conn.db.Tbl_Doctor.Count().ToString();
        }

        private void btn_TotPat_Click(object sender, EventArgs e)
        {
            //lbl_totalPatient.Text = Conn.db.Tbl_Patient.Count().ToString();
            lbl_totalPatient.Text = Conn.db.Tbl_Patient.Where(x=>x.Patient_Gender == "Kadın").Count().ToString();

        }

        private void btn_TotSec_Click(object sender, EventArgs e)
        {
            lbl_totalSec.Text = Conn.db.Tbl_Secretary.Count().ToString();
        }

        private void btn_TotAnnoun_Click(object sender, EventArgs e)
        {
            lbl_totalAnnoun.Text = Conn.db.Tbl_Announcement.Count().ToString();

        }

        private void btn_DwMP_Click(object sender, EventArgs e)
        {
            label8.Text = Conn.db.Tbl_Doctor.Where(x => x.Doctor_Branch == "Dahiliye").Count().ToString();
        }

        private void btn_patientDerma_Click(object sender, EventArgs e)
        {
            lbl_patientDermatology.Text = Conn.db.Tbl_Appoinment.Where(x => x.Appointment_Branch == "Dermatoloji").Count().ToString();
        }

      

        private void btn_22NovemberApp_Click(object sender, EventArgs e)
        {
            label9.Text = Conn.db.Tbl_Appoinment.Where(x => x.Appoinment_Date == "22.11.2022").Count().ToString();
        }
    }
}
