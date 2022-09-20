using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAbigail.Models
{
    public class Response
    {
#region Propiedades
        [NotMapped]
        public int Resultado { get; set; }
        [NotMapped]
        public object Data { get; set; }
        [NotMapped]
        public string Messages { get; set; }
#endregion

#region Constructores
        public Response()
        {
            this.Resultado = 0;
            this.Data = "";
            this.Messages = "";
        }
#endregion
    }
}