using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ApiWeb.Extensions
{
    public static class SwagerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // Register the swagger generator, definign one or more Swaggger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api",
                    Version = "v1",
                    Description = @"Servicios de API REST FULL",
                    TermsOfService = new Uri("https://www.google.com"),
                    Contact = new OpenApiContact() { Name = "Taylor.info", Email = "jhonmontenegro2512@gmail.com" }
                });
                options.ResolveConflictingActions(apiDescription => apiDescription.First());

                //Get XML comment path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                var xmlModePath = Path.Combine(AppContext.BaseDirectory, "Domain.xml");

                // Set xml path
                options.IncludeXmlComments(xmlPath, true);
                options.IncludeXmlComments(xmlModePath, true);
                options.EnableAnnotations();



                // UseFullTypeNameInSchemaIds replacement for .NET Core
                //options.CustomSchemaIds(x => x.FullName);
                // options.ExampleFilters();

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                options.CustomSchemaIds(currentClass =>
                {
                    if (currentClass.IsGenericType && currentClass.Name.Contains("DomainEntityList"))
                    {
                        string returnedValue = $"{currentClass.GenericTypeArguments.First().Name}List";
                        return returnedValue;
                    }
                    return currentClass.Name;
                });

            });
        }
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseDeveloperExceptionPage();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1/swagger.json", "ApiRest");
            });
        }
    }
}

