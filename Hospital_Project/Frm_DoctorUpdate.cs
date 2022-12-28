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
    public partial class Frm_DoctorUpdate : Form
    {
        public Frm_DoctorUpdate()
        {
            InitializeComponent();
        }
        public string sTC;
        private void Frm_DoctorUpdate_Load(object sender, EventArgs e)
        {
            msk_TC.Text = sTC;

            var query = from item in Conn.db.Tbl_Doctor.Where(x => x.Doctor_TC == msk_TC.Text)
                        select new
                        {
                            item.Doctor_ID,
                            item.Doctor_Name,
                            item.Doctor_LastName,
                            item.Doctor_Branch,
                            item.Doctor_Password

                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_LastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmb_Branch.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_Password.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void btn_Uptade_Click(object sender, EventArgs e)
        {
            int iID =int.Parse( txt_ID.Text);
            var vUpdate = Conn.db.Tbl_Doctor.Find(iID);

            vUpdate.Doctor_Name= txt_Name.Text;
            vUpdate.Doctor_LastName= txt_LastName.Text;
            vUpdate.Doctor_TC = msk_TC.Text;
            vUpdate.Doctor_Branch = cmb_Branch.Text;
            vUpdate.Doctor_Password = txt_Password.Text;

            Conn.db.SaveChanges();

        }
    }
}
