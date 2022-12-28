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
    public partial class Frm_Annoncument : Form
    {
        public Frm_Annoncument()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frm_Annoncument_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Conn.db.Tbl_Announcement.ToList();
        }
    }
}
