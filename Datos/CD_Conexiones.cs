using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class CD_Conexiones
    {

        private SqlConnection conexion = new SqlConnection("Server=DESKTOP-1Q2EPSL\\SQLEXPRESS; DataBase= dbPrueba1; Integrated Security= yes");

        public SqlConnection abrirConexion()
        {
            if(conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public SqlConnection cerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }
    }
}
