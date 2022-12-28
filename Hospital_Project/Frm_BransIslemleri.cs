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
    public partial class Frm_BransIslemleri : Form
    {
        public Frm_BransIslemleri()
        {
            InitializeComponent();
        }
        private void Clean()
        {
            txt_ID.Clear();
            txt_Name.Clear();
        }
        private void Listing() //CRUD Operations(Listing)
        {

            dataGridView1.DataSource = Conn.db.Tbl_Branch.ToList();

        }
        //CRUD Operations (Deleting)
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int iID = int.Parse(txt_ID.Text);
            var vDelete = Conn.db.Tbl_Branch.Find(iID);

            Conn.db.Tbl_Branch.Remove(vDelete);

            Conn.db.SaveChanges();

            Listing();
            Clean();
        }

        private void Frm_BransIslemleri_Load(object sender, EventArgs e)
        {
            Listing();
        }

        //CRUD Operations Inseting
        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Tbl_Branch add = new Tbl_Branch();
            add.Branch_Name = txt_Name.Text;

            Conn.db.Tbl_Branch.Add(add);
            Conn.db.SaveChanges();

            Listing();

        }

        //CRUD Operations Updating
        private void btn_Update_Click(object sender, EventArgs e)
        {
            int iID = int.Parse(txt_ID.Text);
            var vUpdate = Conn.db.Tbl_Branch.Find(iID);

            vUpdate.Branch_Name = txt_Name.Text;

            Conn.db.SaveChanges();

            Listing();
            Clean();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
