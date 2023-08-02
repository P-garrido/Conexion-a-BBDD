using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private string _nombreUsuario;
        private string _clave;

        public Usuario() { }

        public Usuario(string nomUsu, string clave)
        {
            this._nombreUsuario = nomUsu;
            this._clave = clave;
           
        }

       

        public string Clave
        {
            get => _clave;
            set
            {
                _clave = value;
            }
        }


        public string NombreUsuario
        {
            get => _nombreUsuario;
            set
            {
                _nombreUsuario = value;
            }
        }
    }
}
