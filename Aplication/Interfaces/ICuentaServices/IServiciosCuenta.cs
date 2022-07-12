using Aplication.AppServices;
using Domain.Dto.Persona;
using Domain.Entities;
using Domain.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ICuentaServices
{
    public interface IServiciosCuenta: ICuentaServicios<RespuestaAutenticacion, CredencialesUsuario,Usuarios,EmailDto>
    {
        
    }
}
