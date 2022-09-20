using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Models
{
    public class Inmueble
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
        public string Numero_Inmueble { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Sector_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Tipo_Inmueble_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public long Precio_Inmueble { get; set; }
        
        public int Estatus { get; set; }
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; } 
#endregion

#region Constructores
        public Inmueble()
        {
            this.Id = 0;
            this.Numero_Inmueble = string.Empty;
            this.Sector_Id = 0;
            this.Tipo_Inmueble_Id = 0;
            this.Precio_Inmueble = 0;
            this.Estatus = ESTADO_ACTIVO;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;
            this.Sector = new Sector();
            this.Tipo_Inmueble = new Tipo_Inmueble();        
        }        
#endregion

#region FK
        public virtual Sector Sector { get; set; }
        public virtual Tipo_Inmueble Tipo_Inmueble { get; set; }
#endregion
    }
}