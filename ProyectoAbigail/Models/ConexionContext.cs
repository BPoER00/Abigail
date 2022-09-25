using Microsoft.EntityFrameworkCore;

namespace ProyectoAbigail.Models
{
    public class ConexionContext : DbContext
    {

        public ConexionContext(IConfiguration _Configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connection = "Data Source=localhost; Initial Catalog=ProyectoA; User Id=sa; Password=Password#2022";
            // connect to sql server with connection string from app settings
            options.UseSqlServer(connection);
        }

        public DbSet<Accion> Accion { get; set; } 
        public DbSet<Cabeza_Famila> Cabeza_Famila { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Detalle> Detalle  { get; set; }
        public DbSet<Entrada_Salida> Entrada_Salida  { get; set; }
        public DbSet<Estado_Civil> Estado_Civil  { get; set; }
        public DbSet<Etnia> Etnia  { get; set; }
        public DbSet<Factura> Factura  { get; set; }
        public DbSet<Familia> Familia  { get; set; }
        public DbSet<Genero> Genero  { get; set; }
        public DbSet<Inmueble> Inmueble  { get; set; }
        public DbSet<Inmueble_Alquilado> Inmueble_Alquilados  { get; set; }
        public DbSet<Inquilino> Inquilinos  { get; set; }
        public DbSet<Marca> Marca  { get; set; }
        public DbSet<Modulo> Modulo  { get; set; }
        public DbSet<Permiso> Permiso  { get; set; }
        public DbSet<Persona> Persona  { get; set; }
        public DbSet<Prop_Inmueble> Prop_Inmueble  { get; set; }
        public DbSet<Prop_Vehiculo> Prop_Vehiculo  { get; set; }
        public DbSet<Propietario> Propietario  { get; set; }
        public DbSet<Reporte> Reporte  { get; set; }
        public DbSet<Rol> Rol  { get; set; }
        public DbSet<Rol_Persona> Rol_Persona  { get; set; }
        public DbSet<Sector> Sector  { get; set; }
        public DbSet<Tipo_Inmueble> Tipo_Inmueble  { get; set; }
        public DbSet<Tipo_Reporte> Tipo_Reporte  { get; set; }
        public DbSet<Tipo_Vehiculo> Tipo_Vehiculo  { get; set; }
        public DbSet<Usuario> Usuario  { get; set; }
        public DbSet<Vehiculo> Vehiculo  { get; set; }
    }
}