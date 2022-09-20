using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Models
{
    public class Entrada_Salida
    {
#region Propiedades
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Persona_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Vehiculo_Id  { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public string Token { get; set; }

        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }
#endregion

#region Constructores
        public Entrada_Salida()
        {
            this.Id = 0;
            this.Persona_Id = 0;
            this.Vehiculo_Id = 0;
            this.Token = string.Empty;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;
            this.Persona = new Persona();
            this.Vehiculo = new Vehiculo();
        }
#endregion

#region FK
        public virtual Persona Persona { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
#endregion    
    }
}