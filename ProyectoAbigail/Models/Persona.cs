using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Models
{
    public class Persona
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
        public String Nombre { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public String Apellido { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public DateTime Fecha_Nacimiento { get; set; }

        public String Telefono { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public String Cui { get; set; }
        
        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Genero_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Estado_Civil_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Etnia_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Usuario_Id { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Rol_Persona_Id { get; set; }

        public int Estatus { get; set; }
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }
#endregion

#region Constructores
        public Persona()
        {
            this.Id = 0;
            this.Nombre = String.Empty;
            this.Apellido = String.Empty;
            this.Telefono = String.Empty;
            this.Cui = String.Empty;
            this.Genero_Id = 0;
            this.Estado_Civil_Id = 0;
            this.Etnia_Id = 0;
            this.Usuario_Id = 0;
            this.Rol_Persona_Id = 0;
            this.Estatus = ESTADO_ACTIVO;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;
            this.Genero = new Genero();
            this.Estado_Civil = new Estado_Civil();
            this.Etnia = new Etnia();
            this.Usuario = new Usuario();
            this.Rol_Persona = new Rol_Persona(); 
        }
#endregion

#region FK
    public virtual Genero Genero { get; set; }
    public virtual Estado_Civil Estado_Civil { get; set; }
    public virtual Etnia Etnia { get; set; }
    public virtual Usuario Usuario { get; set; }
    public virtual Rol_Persona Rol_Persona { get; set; }
#endregion
    }
}