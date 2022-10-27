using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Models
{
    public class Inmueble_Alquilado
    {
#region Constantes
        [NotMapped]
        public const int ESTADO_ACTIVO = 1;
        [NotMapped]
        public const int ESTADO_INACTIVO = 0;
        [NotMapped]
        public const int ESTADO_REMODELACION = 2;
        
#endregion

#region Propiedades
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Persona_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Inmueble_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public DateTime Fecha_Alquiler { get; set; }

        public DateTime Fecha_Fin_Alquiler { get; set; }
        public int Estatus { get; set; }
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }
#endregion

#region Constructores
        public Inmueble_Alquilado()
        {
            this.Id = 0;
            this.Inmueble_Id = 0;
            this.Descripcion = string.Empty;
            this.Fecha_Alquiler = DateTime.Now;
            this.Estatus = ESTADO_ACTIVO;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;
        }
#endregion

#region FK
        public virtual Persona Persona { get; set; }
        public virtual Inmueble Inmueble { get; set; }
#endregion
    }
}