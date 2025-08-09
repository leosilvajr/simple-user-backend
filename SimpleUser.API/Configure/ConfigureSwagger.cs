using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace SimpleUser.API.Configurations
{
    public static class ConfigureSwagger
    {
        public static void UseSwaggerConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleUser API v1");
                    c.RoutePrefix = string.Empty; // Swagger na raiz
                });
            }
        }

        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleUser API", Version = "v1" });
            });
        }
    }
}
