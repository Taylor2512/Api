using Aplication.Interfaces.ICuentaServices;
using Aplication.Interfaces.IUsuarioServices;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IExtensions
{
    public interface IExtensionServices
    {
        public IServiciosCuenta serviciosCuenta { get; set; }
        public IServicioUsuarios servicioUsuarios { get; set; }
        public  IConfiguration configuration { set; get; }
    
    }
}
