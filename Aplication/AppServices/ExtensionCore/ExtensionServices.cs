using Aplication.Interfaces.ICuentaServices;
using Aplication.Interfaces.IExtensions;
using Aplication.Interfaces.IUsuarioServices;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.AppServices.ExtensionCore
{
    public class ExtensionServices: IExtensionServices
    {
        public IServiciosCuenta serviciosCuenta { get; set; }
        public IServicioUsuarios servicioUsuarios { get; set; }
        public IConfiguration configuration { set; get; }

        public ExtensionServices(IServiciosCuenta serviciosCuenta, IServicioUsuarios servicioUsuarios)
        {
            this.serviciosCuenta = serviciosCuenta;
            this.servicioUsuarios = servicioUsuarios;
        }


        
    }
}
