using AppComercial.Ioc;
using AppComercial.Servicios.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AppComercial.Windows
{
    internal static class Program
    {

        public static IServiceProvider ServiceProvider = null!;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceProvider = DI.ConfigurarDI();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPrincipal(ServiceProvider.GetRequiredService<IServicioMarcas>(), ServiceProvider.GetRequiredService<IServicioProductos>()));
        }
    }
}