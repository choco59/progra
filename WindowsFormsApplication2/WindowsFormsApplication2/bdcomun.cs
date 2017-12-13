using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication2
{
    public class bdcomun
    {
        public static MySqlConnection Obtenerconexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=docentes; Uid=root; pwd=;");
            conectar.Open();
            return conectar;
           
        }
        }
}
