using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiWeb.Extensions
{
    public static class AutenticationConfig
    {
        public static void IyectarAuthentication(IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["LlaveJwt"])),


                    };
                });
            Services.AddAuthorization(options =>
            {
                options.AddPolicy("EsAdmin", politica => politica.RequireClaim("EsAdmin"));
                options.AddPolicy("EsVendedor", politica => politica.RequireClaim("EsVendedor"));
                options.AddPolicy("EsComprador", politica => politica.RequireClaim("EsComprador"));
            });
        }
    }
}
