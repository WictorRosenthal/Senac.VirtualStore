using System.Reflection;
using Microsoft.OpenApi.Models;

namespace VirtualStoreAPI.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(S => {
                S.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "VirtualStore API",
                    Description = "Esta API é feita como parte do curso de Prgramador de Sistema do SENAC",
                    Contact = new OpenApiContact()
                    {
                        Name = "Senac",
                        Email = "contato@go.senac.br"
                    }
                });
            });
        }
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            });
        }

    }
}
