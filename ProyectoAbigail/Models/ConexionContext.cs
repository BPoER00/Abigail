using Microsoft.EntityFrameworkCore;

namespace ProyectoAbigail.Models
{
    public class ConexionContext : DbContext
    {
        private DatosConexion dato = new DatosConexion();

        public ConexionContext(DbContextOptions<ConexionContext> options) 
        : base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                (
                    $"Server={dato.Server};" +
                    $"Database={dato.Database};" +
                    $"Persist Security Info=True;" +
                    $"User={dato.Usuario};" +
                    $"Password={dato.Password};" 
                );
            }
        }
    }
}