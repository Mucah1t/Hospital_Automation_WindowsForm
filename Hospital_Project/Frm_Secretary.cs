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
    public partial class Frm_Secretary : Form
    {
        public Frm_Secretary()
        {
            InitializeComponent();
        }
        public string sTC;
        SqlConnection conn = new SqlConnection("Data Source=302-08;Initial Catalog=Hospital_Project;User ID=WebMobile_302;Password=webmobile.302");

        private void Frm_Secretary_Load(object sender, EventArgs e)
        {
            //Assigning ID Number from pervious form
            lbl_TC.Text = sTC;

            //Getting Name and Lastname from sql when the form is loaded
            var vTC = Conn.db.Tbl_Secretary.FirstOrDefault(x => x.Secretary_TC == lbl_TC.Text);
            lbl_Name.Text = vTC.Secretary_Name_LastName+" " ;

            //CRUD Listing Operation of Branch Table
            //dataGridView1.DataSource = Conn.db.Tbl_Branch.ToList();
            var query = from item in Conn.db.Tbl_Branch
                        select new { Branşlar = item.Branch_Name };
            dataGridView1.DataSource = query.ToList();

            //CRUD Listing Operation of Doctor Table
            //dataGridView2.DataSource = Conn.db.Tbl_Doctor.ToList();

            //CRUD Listing Operation of Doctor Table via LinQ
            var query2 = from item in Conn.db.Tbl_Doctor
                        select new { item.Doctor_Name, item.Doctor_LastName, item.Doctor_Branch };
            dataGridView2.DataSource = query2.ToList();

            //combobox porpety
            
            //cmb_Branch.DataSource = Conn.db.Tbl_Branch.ToList();
            //cmb_Branch.DisplayMember = "Branch_Name";
            //cmb_Branch.Invalidate();

            //Combobox Value Member, Display Memeber Property
            using (Hospital_ProjectEntities1 db = new Hospital_ProjectEntities1())
            {
                cmb_Branch.DataSource = db.Tbl_Branch.ToList();
                cmb_Branch.ValueMember = "Branch_ID";
                cmb_Branch.DisplayMember = "Branch_Name";
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tbl_Appoinment add = new Tbl_Appoinment();
            add.Appoinment_Date = msk_Date.Text;
            add.Appointment_Time = (msk_Time.Text);
            add.Appointment_Branch = cmb_Branch.Text;
            add.Appointment_Doctor = cmb_Doctor.Text;

            Conn.db.Tbl_Appoinment.Add(add);

            Conn.db.SaveChanges();

            MessageBox.Show("Randevu oluşturulmuştur", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            msk_Date.Clear();
            msk_Time.Clear();
            

        }

        private void cmb_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Listing Doctor Name according to it's Branches
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

        private void button1_Click(object sender, EventArgs e)
        {
            //CRUD Operaiton inserting
            Tbl_Announcement Ekle = new Tbl_Announcement();
            //Ekle.Announcement_ID = 99;
            Ekle.Announcement = richTextBox1.Text;

            Conn.db.Tbl_Announcement.Add(Ekle);
            Conn.db.SaveChanges();

            MessageBox.Show("Duyuru oluşturulmuştur.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            richTextBox1.Clear();


            //conn.Open();
            //SqlCommand cmd = new SqlCommand("Insert into Tbl_Announcement (Announcement) values (@p1)", conn);
            //cmd.Parameters.AddWithValue("@p1", richTextBox1.Text);
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_DoktorIslemleri fr = new Frm_DoktorIslemleri();
            fr.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm_RandevuListesi fr = new Frm_RandevuListesi();
            fr.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_BransIslemleri fr = new Frm_BransIslemleri();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_Annoncument fr = new Frm_Annoncument();
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Reports fr = new Reports();
            fr.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
