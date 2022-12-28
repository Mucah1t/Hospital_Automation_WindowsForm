using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hospital_Project
{
    internal class Conn
    {

        public static Hospital_ProjectEntities1 db = new Hospital_ProjectEntities1();
    }
}
