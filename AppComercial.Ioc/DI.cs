using AppComercial.Datos;
using AppComercial.Datos.Interfaces;
using AppComercial.Datos.Repositorios;
using AppComercial.Servicios.Interfaces;
using AppComercial.Servicios.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace AppComercial.Ioc
{
    public static class DI
    {
        public static IServiceProvider ConfigurarDI()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ComercialDbContext>(options =>
            {
                options.UseSqlServer(ConfigurationManager
                    .ConnectionStrings["MiConexion"]
                    .ConnectionString);
            });

            /*
             * Completar con sus interfaces y las respectivas implementaciones
             */

            //Repositorios
            services.AddScoped<IRepositorioMarcas, RepositorioMarcas>();
            services.AddScoped<IRepositorioProductos, RepositorioProductos>();

            //Servicios
            services.AddScoped<IServicioMarcas, ServicioMarcas>();
            services.AddScoped<IServicioProductos, ServicioProductos>();

            return services.BuildServiceProvider();
        }
    }
}
