using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAbigail.Models
{
    public class DatosConexion
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public DatosConexion()
        {
            this.Server = "";
            this.Database = "";
            this.Usuario = "";
            this.Password = "";
        }
    }
}