using Aplication.Interfaces.IUsuarioServices;
using Domain.Dto.Persona;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.AppServices.Persona
{
    internal class UsuarioServices:IServicioUsuarios
    {
        private readonly UserManager<Usuarios> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<Usuarios> signInManager;

        public UsuarioServices(UserManager<Usuarios> userManager, IConfiguration configuration, SignInManager<Usuarios> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> Registrar(CredencialesUsuario usuario)
        {
            Usuarios usuarioIdentity = new Usuarios
            {
                UserName = usuario.Email,
                Email = usuario.Email,
            };
            var resultado = await userManager.CreateAsync(usuarioIdentity, usuario.Password);

            return resultado;
        }

        public async Task<SignInResult> Login(CredencialesUsuario credencialesUsuario)
        {
            var resultado = await signInManager.PasswordSignInAsync(credencialesUsuario.Email, credencialesUsuario.Password,
                isPersistent: false, lockoutOnFailure: false);
            return resultado;
        }

    }
}
