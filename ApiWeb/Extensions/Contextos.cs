using Aplication.Extensions;
using Domain.Entities;
using Infractructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Extensions
{
    public static class Contextos
    {
        public static void InyectarContext(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Defaultdatabase"));
            });
            Services.AddIdentity<Usuarios,Rol>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
        public static void InyectarServicios(this IServiceCollection Services)
        {
            Services.InyectarAppServicios();
        }
    }
}
