using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class CD_Usuario
    {

        public CD_Usuario() { }

        private CD_Conexiones conexion = new CD_Conexiones();

        SqlDataReader reader;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable mostrarUsuarios()
        {
            
            comando.Connection = conexion.abrirConexion();
            table.Clear();
            comando.CommandText = "SELECT * FROM usuarios";
            reader = comando.ExecuteReader();
            table.Load(reader);
            conexion.cerrarConexion();
            return table;
        }

        public void insertarUsuario(Usuario usu)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO usuarios VALUES('" + usu.NombreUsuario+ "','" + usu.Clave + "')"; 
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }


        public void actualizarUsuario(Usuario usu, string idUsu)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE usuarios SET nombreUsuario= '"+usu.NombreUsuario+"', clave= '"+usu.Clave+"' WHERE id = '"+idUsu+"' ";
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }

        public void eliminarUsuario(int idUsu)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandType= CommandType.Text;
            comando.CommandText = "DELETE FROM usuarios WHERE id="+idUsu;
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }

        public DataTable mostrarUsuario(string nomUsu)
        {
            comando.Connection = conexion.abrirConexion();
            table.Clear();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM usuarios WHERE nombreUsuario = '" + nomUsu + "'";
            reader = comando.ExecuteReader();
            table.Load(reader);
            conexion.cerrarConexion();
            return table;
        }

    }
}
