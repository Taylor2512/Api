using Aplication.Interfaces.ICuentaServices;
using Aplication.Interfaces.IExtensions;
using Aplication.Interfaces.IUsuarioServices;
using Domain.Dto.Persona;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly IExtensionServices _extensionServices;

        public CuentaController(IExtensionServices extensionServices)
        {
            _extensionServices = extensionServices;
        }

        [HttpGet]
        public async Task<ActionResult<object>> gener()
        {
            
            return Ok("Prueba");
        }

        [HttpPost("Registrar")]//api/cuenta/Registrar
        public async Task<ActionResult<RespuestaAutenticacion>> Registrar(CredencialesUsuario usuario)
        {
            var resultado = await _extensionServices.servicioUsuarios.Registrar(usuario);
            if (resultado.Succeeded)
            {
               var d=  await _extensionServices.serviciosCuenta.ConstruirToken(usuario);
                return null;
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<RespuestaAutenticacion>> Login(CredencialesUsuario credencialesUsuario)
        {
            var resultado = await _extensionServices.servicioUsuarios.Login(credencialesUsuario);
            if (resultado.Succeeded)
            {
                return await _extensionServices.serviciosCuenta.ConstruirToken(credencialesUsuario);
            }
            else
            {
                return BadRequest("Usuario incorrecto");
            }

        }
        [HttpPost("RefreshToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        private async Task<ActionResult<RespuestaAutenticacion>> RefreshToken()
        {
            var email = HttpContext.User.Claims.Where(Claim => Claim.Type == "email").FirstOrDefault();

            CredencialesUsuario CredencialesUsuario = new CredencialesUsuario
            {
                Email = email.Value,
            };
            return await _extensionServices.serviciosCuenta.ConstruirToken(CredencialesUsuario);

        }

        [HttpGet("mostar-user/{id}")]
        public async Task<ActionResult<object>> ListarUsuario(string id)
        {
            EmailDto emailDto = new EmailDto();
            emailDto.Email = id;
            
            var encontrado = await _extensionServices.serviciosCuenta.obtenerUsuario(emailDto);


            return Ok(encontrado);
        }
       /* [HttpPost("Crear-User-Admin")]
        public async Task<ActionResult> ConvertirAdmin(EditarAdminDto entidad)
        {
            var usuario = await userManager.FindByEmailAsync(entidad.Email);
            if (usuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            await userManager.AddClaimAsync(usuario, new Claim("EsAdmin", "1"));
            return NoContent();
        }
       */
    }
}
