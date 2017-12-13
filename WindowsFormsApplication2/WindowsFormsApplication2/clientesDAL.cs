using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication2
{
    class clientesDAL
    {
        public static int Agregar(cliente pcliente)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into docentes (ci,nombre)values ('{0}','{1}')",
                pcliente.ci, pcliente.nombre), bdcomun.Obtenerconexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        public static List<cliente> Buscar(int ci, string nombre)
        {
            List<cliente> _lista = new List<cliente>();
            
            MySqlCommand _comando=new MySqlCommand(string.Format(
                "SELECT ci,nombre FROM docentes  where ci='{0}'or nombre='{1}'",ci,nombre),bdcomun.Obtenerconexion());
            
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {cliente pcliente = new cliente();
                pcliente.ci= _reader.GetInt16(0);
                pcliente.nombre= _reader.GetString(1);
            _lista.Add(pcliente);
            }
        return _lista;
        }

        public static cliente obtenercliente(int pci)
        {
        cliente pcliente =new cliente();
        MySqlConnection conexion = bdcomun.Obtenerconexion();

        MySqlCommand _comando = new  MySqlCommand(String.Format("SELECT ci,nombre FROM docentes where ci={0}",pci),conexion);
        MySqlDataReader _reader = _comando.ExecuteReader();
        while (_reader.Read())
        {
            pcliente.ci = _reader.GetInt32(0);
            pcliente.nombre = _reader.GetString(1);
        }
        conexion.Close();
        return pcliente;
    }

        public static int actualizar(cliente pcliente)
        {
            int retorno = 0;
            MySqlConnection conexion = bdcomun.Obtenerconexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update docentes set nombre='{0}' where ci={1}", pcliente.nombre, pcliente.ci), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static int eliminar(int pci)
        {
            int retorno = 0;
            MySqlConnection conexion = bdcomun.Obtenerconexion();

            MySqlCommand comando = new MySqlCommand(string.Format("delete from docentes where ci={0}", pci), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;


        }

    }
}
