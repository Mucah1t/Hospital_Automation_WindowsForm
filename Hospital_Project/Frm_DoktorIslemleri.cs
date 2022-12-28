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
    public partial class Frm_DoktorIslemleri : Form
    {
        public Frm_DoktorIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=302-08;Initial Catalog=Hospital_Project;User ID=WebMobile_302;Password=webmobile.302");
        private void Listing()
        {
            dataGridView1.DataSource = Conn.db.Tbl_Doctor.ToList();

        }

        private void Frm_DoktorIslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Conn.db.Tbl_Doctor.ToList();

            //Filling combobox with the values from SQL
            cmb_Branch.DataSource = Conn.db.Tbl_Branch.ToList();
            cmb_Branch.DisplayMember = "Branch_Name";
            cmb_Branch.Invalidate();

        }

        private void Ben_Insert_Click(object sender, EventArgs e)
        {
            //conn.Open();

            //SqlCommand cmd = new SqlCommand("insert into Tbl_Doctor (Doctor_Name,Doctor_LastName,Doctor_Branch,Doctor_TC,Doctor_Password) values (@p1,@p2,@p3,@p4,@p5)", conn);
            //cmd.Parameters.AddWithValue("@p1", txt_Name.Text);
            //cmd.Parameters.AddWithValue("@p2", txt_LastName.Text);
            //cmd.Parameters.AddWithValue("@p3", cmb_Branch.Text);
            //cmd.Parameters.AddWithValue("@p4", msk_TC.Text);
            //cmd.Parameters.AddWithValue("@p5", txt_Password.Text);
            //cmd.ExecuteNonQuery();

            //conn.Close();

            //CRUD Operaiton inserting

            Tbl_Doctor add = new Tbl_Doctor();
            add.Doctor_Name = txt_Name.Text;
            add.Doctor_LastName = txt_LastName.Text;
            add.Doctor_Branch = cmb_Branch.Text;
            add.Doctor_TC = msk_TC.Text;
            add.Doctor_Password = txt_Password.Text;

            Conn.db.Tbl_Doctor.Add(add);
            Conn.db.SaveChanges();

            MessageBox.Show("Doktor eklenmiştir.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var xDelete = Conn.db.Tbl_Doctor.Find(id);

            Conn.db.Tbl_Doctor.Remove(xDelete);
            Conn.db.SaveChanges();

            //CRUD Operation (Listing)
            Listing();


            //conn.Open();
            //SqlCommand cmd = new SqlCommand("Delete from Tbl_Doctor where Doctor_ID=@id", conn);
            //cmd.Parameters.AddWithValue("@id", textBox1.Text);
            //cmd.ExecuteNonQuery();
            //conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_LastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmb_Branch.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            msk_TC.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_Password.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var xUpdate = Conn.db.Tbl_Doctor.Find(id);

            xUpdate.Doctor_Name = txt_Name.Text;
            xUpdate.Doctor_LastName = txt_LastName.Text;
            xUpdate.Doctor_Branch = cmb_Branch.Text;
            xUpdate.Doctor_TC = msk_TC.Text;
            xUpdate.Doctor_Password = txt_Password.Text;

            Conn.db.SaveChanges();

            MessageBox.Show("Bilgiler güncellenmiştir.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Listing();

            //conn.Open();
            //SqlCommand cmd = new SqlCommand("Update Tbl_Doctor set Doctor_Name=@p1,Doctor_LastName=@p2,Doctor_Branch=@p3,Doctor_Password=@p5 whereDoctor_TC=@p4 ", conn);
            //cmd.Parameters.AddWithValue("@p1", txt_Name.Text);
            //cmd.Parameters.AddWithValue("@p2", txt_LastName.Text);
            //cmd.Parameters.AddWithValue("@p3", cmb_Branch.Text);
            //cmd.Parameters.AddWithValue("@p4", msk_TC.Text);
            //cmd.Parameters.AddWithValue("@p5", txt_Password.Text);

            //cmd.ExecuteNonQuery();
            //conn.Close();

        }
    }
}
