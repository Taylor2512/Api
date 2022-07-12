using Aplication.Interfaces.ICuentaServices;
using Domain.Dto.Persona;
using Domain.Entities;
using Domain.Interfaces.Servicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.AppServices
{
    internal class CuentaServices : IServiciosCuenta
    {
        private readonly UserManager<Usuarios> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<Usuarios> signInManager;

        public CuentaServices(UserManager<Usuarios> userManager, IConfiguration configuration, SignInManager<Usuarios> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        public async Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario credencialesUsuario)
        {
            var Claims = new List<Claim>()
            {
                new Claim("email",credencialesUsuario.Email)
            };
            var usuario = await userManager.FindByEmailAsync(credencialesUsuario.Email);
            var ClaimsDb = await userManager.GetClaimsAsync(usuario);
            Claims.AddRange(ClaimsDb);
            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["LlaveJwt"]));
            var cred = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddDays(2);
            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: Claims, expires: expiracion, signingCredentials: cred);
            return new RespuestaAutenticacion
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiracion,
            };
        }    public async Task<Usuarios> obtenerUsuario(EmailDto user)
        {
           
            var usuario = await userManager.FindByEmailAsync(user.Email);
            return usuario;

        }

       
    }
}
