using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Models.viewModels
{
    public class UsuarioViewModel
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
        public string User { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        [EmailAddress(ErrorMessage = Mensajes.Correo)]
        public string Correo { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Rol_Id { get; set; }
        public int Estatus { get; set; }
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }
        #endregion


        #region FK
        public virtual Rol Rol { get; set; }
        #endregion
    }
}