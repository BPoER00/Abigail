using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Models
{
    public class Familia
    {
#region Constantes
        [NotMapped]
        public const int ESTADO_ACTIVO = 1;
        [NotMapped]
        public const int ESTADO_INACTIVO = 0;
#endregion

#region Propiedades
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Persona_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Cabeza_Familia_Id { get; set; }

        public int Estatus { get; set; }
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }
#endregion

#region Constructores
        public Familia()
        {
            this.Id = 0;
            this.Persona_Id = 0;
            this.Cabeza_Familia_Id = 0;
            this.Estatus = ESTADO_ACTIVO;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;
        }
#endregion

#region #FK
        public virtual Persona Persona { get; set; }
        public virtual Cabeza_Famila Cabeza_Familia { get; set; }
#endregion
    }
}