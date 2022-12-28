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
    public partial class Frm_PatientControl : Form
    {
        public Frm_PatientControl()
        {
            InitializeComponent();
        }
        public string tc;
        SqlConnection conn = new SqlConnection("Data Source=302-08;Initial Catalog=Hospital_Project;User ID=WebMobile_302;Password=webmobile.302");
        private void Frm_PatientControl_Load(object sender, EventArgs e)
        {
            //Ad-Soyad çekme
            lbl_TC.Text = tc;

            var vTC = Conn.db.Tbl_Patient.FirstOrDefault(x => x.Patient_Tc==lbl_TC.Text);
            lbl_Name.Text = vTC.Patient_Name +" "+ vTC.Patient_LastName;

            //CRUD Listing Operation of Appointment Table
            //dataGridView1.DataSource = Conn.db.Tbl_Appoinment.ToList();
            var query = from item in Conn.db.Tbl_Appoinment.Where(x => x.Patient_TC == tc)
                        select new
                        {
                            item.Appointment_Time,
                            item.Appoinment_Date,
                            item.Appointment_Doctor,
                            item.Appointment_Statu,
                            item.Patient_TC
                        };
            dataGridView1.DataSource = query.ToList();


            //combobox porpety
            cmb_Branch.DataSource = Conn.db.Tbl_Branch.ToList();
            cmb_Branch.DisplayMember = "Branch_Name";
            cmb_Branch.Invalidate();

   

        }

        private void cmb_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_Doctor.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select Doctor_Name,Doctor_LastName from Tbl_Doctor where Doctor_Branch=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", cmb_Branch.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_Doctor.Items.Add(dr[0] + " " + dr[1]);
            }
            conn.Close();


        }

        private void cmb_Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Appoinment where Appointment_Branch='" + cmb_Branch.Text + "'", conn);
            //da.Fill(dt);
            //dataGridView2.DataSource = dt;

            //Listing Appointments with respect to their branches
            var query = from item in Conn.db.Tbl_Appoinment.Where(x=>x.Appointment_Branch == cmb_Branch.Text & x.Appointment_Statu == false)
                select new
                {
                    item.Appointment_ID,
                    item.Appointment_Time,
                    item.Appoinment_Date,
                    item.Appointment_Doctor,
                    item.Appointment_Statu,
                    
                };
            dataGridView2.DataSource = query.ToList();
        }

        private void lnk_edit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_PatienceUpdate fr = new Frm_PatienceUpdate();
            fr.TCno = lbl_TC.Text;
            fr.Show();

        }

        private void btn_RandevuAl_Click(object sender, EventArgs e)
        {
            int iID = int.Parse(txt_ID.Text);
            var vUpdate = Conn.db.Tbl_Appoinment.Find(iID);

            vUpdate.Appointment_Statu = true;
            vUpdate.Patient_TC = lbl_TC.Text;
            vUpdate.Patient_Symptom = rtxtbox_Symptom.Text;

            Conn.db.SaveChanges();

            MessageBox.Show("Randevunuz kaydedilmiştir.Randevu saatinden 15 dakika önce hastanade olunuz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            rtxtbox_Symptom.Clear();

        }

      

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
