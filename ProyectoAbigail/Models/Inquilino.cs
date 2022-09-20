using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Models
{
    public class Inquilino
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
        public string Descripcion { get; set; }
        
        public int Estatus { get; set; }
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }
#endregion

#region Constructores
        public Inquilino()
        {
            this.Id = 0;
            this.Persona_Id = 0;
            this.Descripcion = string.Empty;
            this.Estatus = ESTADO_ACTIVO;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;            
        }
#endregion
    }
}