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
    public partial class Frm_PatienceUpdate : Form
    {
        public Frm_PatienceUpdate()
        {
            InitializeComponent();
        }
        public string TCno;
        sqlbaglantisi con = new sqlbaglantisi();
        private void Frm_PatienceUpdate_Load(object sender, EventArgs e)
        {
            msk_TC.Text = TCno;
            //SqlCommand cmd = new SqlCommand("Select * from Tbl_Patient where Patient_Tc=@p1", con.connection());
            //cmd.Parameters.AddWithValue("@p1", msk_TC.Text);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    txt_Name.Text = dr[1].ToString();
            //    txt_LastName.Text = dr[2].ToString();
            //    msk_Phone.Text = dr[4].ToString();
            //    txt_Password.Text = dr[5].ToString();
            //    cmb_Gender.Text = dr[6].ToString();              
            //}
            //con.connection().Close();

            var vTC = Conn.db.Tbl_Patient.FirstOrDefault(x => x.Patient_Tc == msk_TC.Text);
            txt_Name.Text= vTC.Patient_Name;
            txt_LastName.Text= vTC.Patient_LastName;
            msk_Phone.Text = vTC.Patient_Phone ;
            txt_Password.Text= vTC.Patient_Password  ;
            cmb_Gender.Text = vTC.Patient_Gender ;

        }

        private void Güncelle_Click(object sender, EventArgs e)
        {
            int iTC = Convert.ToInt32(txt_ID.Text);
            var xUpdate = Conn.db.Tbl_Patient.Find(iTC);

            xUpdate.Patient_Name = txt_Name.Text;
            xUpdate.Patient_LastName = txt_LastName.Text;
            xUpdate.Patient_Phone = msk_Phone.Text;
            xUpdate.Patient_Password = txt_Password.Text;
            xUpdate.Patient_Gender = cmb_Gender.Text;

            Conn.db.SaveChanges();
        }
    }
}
