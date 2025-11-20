using AppComercial.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AppComercial.Datos
{
    public class ComercialDbContext : DbContext
    {
        protected ComercialDbContext()
        {
        }

        public ComercialDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }

    }
}
