using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Models
{
    public class Reporte
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
        public int Tipo_Reporte_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]        
        public string Descripcion { get; set; }
        public int Estatus { get; set; }
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }
#endregion

#region Constructores
        public Reporte()
        {
            this.Id = 0;
            this.Persona_Id = 0;
            this.Tipo_Reporte_Id = 0;
            this.Descripcion = string.Empty;
            this.Estatus = ESTADO_ACTIVO;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;  
            this.Persona = new Persona();
            this.Tipo_Reporte = new Tipo_Reporte();          
        }
#endregion

#region FK
        public virtual Persona Persona { get; set; }
        public virtual Tipo_Reporte Tipo_Reporte { get; set; }
#endregion
    }
}