using Domain.Dto.Persona;
using Domain.Interfaces.Servicios.Usuario;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IUsuarioServices
{
    public interface IServicioUsuarios: IRegistrar<IdentityResult, CredencialesUsuario>,ILogin<SignInResult,CredencialesUsuario>
    {
    }
}
