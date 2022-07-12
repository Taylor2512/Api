using ApiWeb.Extensions;

namespace ApiWeb.Configuration
{
    public static class Startup
    {
        public static WebApplication Inicializar(this string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.ConfigurationServices();
            var app = builder.Build();
  

            app.Configure();
            return app;
        }
        public static void ConfigurationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddNewtonsoftJson(option =>
  option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
  );
            builder.Services.AddControllers().AddNewtonsoftJson(option =>
            option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            //Inyeccion de contextos de la base de datos//
            builder.Services.InyectarContext(builder.Configuration);

            //Inyeccion de dependencias de servicios y repositorios//
            builder.Services.InyectarServicios();
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("Allow", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });



        }
        public static  void Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
               
            }
            app.UseCors("Allow");
            app.UseCustomSwagger();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        } 

    }
}
