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
    public partial class Frm_RandevuListesi : Form
    {
        public Frm_RandevuListesi()
        {
            InitializeComponent();
        }

        private void Frm_RandevuListesi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Conn.db.Tbl_Appoinment.ToList();

        }
    }
}
