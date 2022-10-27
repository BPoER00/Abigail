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
    public const int INVALIDA = 0;
    public const int ENTRADA = 1;
    public const int SALIDA = 2;

#region Propiedades
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public string cui { get; set; }
        public string Matricula  { get; set; }
        public string Destino { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public DateTime Fecha { get; set; }    
    
        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Id_Modalidad_Ingreso { get; set; }    

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Id_Tipo_Persona { get; set; }    

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }

        
#endregion

#region Constructores
        public Entrada_Salida()
        {
            this.Id = 0;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;
            this.Persona = new Persona();
        }
#endregion

#region FK
        public virtual Persona Persona { get; set; }
#endregion    
    }
}