namespace ProyectoAbigail.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Resources;

    public class Usuario
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
        [Required(ErrorMessage = Mensajes.Password)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = Mensajes.ConfirmPassword)]
        [NotMapped]
        public string ConfirmarPass { get; set; }
        [Required(ErrorMessage = Mensajes.Obligatorio)]
        [EmailAddress(ErrorMessage = Mensajes.Correo)]
        public string Correo { get; set; }

        [Required(ErrorMessage = Mensajes.Obligatorio)]
        public int Rol_Id { get; set; }
        public string Sal { get; set; }
        public int Estatus { get; set; }
        public DateTime Fecha_commit { get; set; }
        public DateTime Hora_commit { get; set; }
        #endregion

        #region Constructores
        public Usuario()
        {
            this.Id = 0;
            this.User = string.Empty;
            this.Correo = string.Empty;
            this.Rol_Id = 0;
            this.Estatus = ESTADO_ACTIVO;
            this.Fecha_commit = DateTime.Now;
            this.Hora_commit = DateTime.Now;
            this.Rol = new Rol();
        }
        #endregion

        #region FK
        public virtual Rol Rol { get; set; }
        #endregion
    }
}