using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hospital_Project
{
    internal class sqlbaglantisi
    {
        public SqlConnection connection()
        {
            SqlConnection conn = new SqlConnection("Data Source=302-08;Initial Catalog=HastaneProje;Persist Security Info=True;User ID=WebMobile_302;Password=webmobile.302");
            conn.Open();
            return conn;
        }

    }
}
