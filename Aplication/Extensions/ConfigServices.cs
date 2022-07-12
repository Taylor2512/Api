using Aplication.AppServices;
using Aplication.AppServices.ExtensionCore;
using Aplication.AppServices.Persona;
using Aplication.Interfaces.ICuentaServices;
using Aplication.Interfaces.IExtensions;
using Aplication.Interfaces.IUsuarioServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Extensions
{
    internal static class ConfigServices
    {
        public static IServiceCollection InyectarAppServicios(this IServiceCollection services)
        {
            services.AddScoped<IServiciosCuenta, CuentaServices>();
            services.AddScoped<IServicioUsuarios,UsuarioServices > ();
            services.AddScoped<IExtensionServices, ExtensionServices > ();
            return services;
        }
    }
}
