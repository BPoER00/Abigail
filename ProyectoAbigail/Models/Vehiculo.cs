using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Models
{
    public class Vehiculo
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
        public string Model { get; set; }
        
        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public string anio { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Marca_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Color_Id { get; set; }

        public int Estatus { get; set; }
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }
#endregion

#region Constructores
        public Vehiculo()
        {
            this.Id = 0;
            this.Model = string.Empty;
            this.anio = string.Empty;
            this.Marca_Id = 0;
            this.Color_Id = 0;
            this.Estatus = ESTADO_ACTIVO;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;
            this.Tipo_Vehiculo = new Tipo_Vehiculo();
            this.Marca = new Marca();
            this.Color = new Color();            
        }
#endregion
    
#region FK
        public virtual Tipo_Vehiculo Tipo_Vehiculo { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Color Color { get; set; }
#endregion    
    }
}