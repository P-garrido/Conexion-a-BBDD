using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class CN_Usuario
    {
        public CN_Usuario() { }

        private CD_Usuario CDUsuario = new CD_Usuario();

        public DataTable mostrarUsuarios()
        {
            return CDUsuario.mostrarUsuarios(); ;
        }

        public void insertarUsuario(string nom, string clave)
        {
            Usuario usu = new Usuario(nom, clave);
            CDUsuario.insertarUsuario(usu);
        }

        public void actualizarUsuario(string nom, string clave, string idUsu)
        {
            Usuario usu = new Usuario(nom, clave);
            CDUsuario.actualizarUsuario(usu, idUsu);
        }

        public void eliminarUsuario(string idUsu)
        {
            CDUsuario.eliminarUsuario(int.Parse(idUsu));
        }

        public DataTable mostrarUsuario(string nomUsu)
        {
            return CDUsuario.mostrarUsuario(nomUsu);
        }
    }
}
