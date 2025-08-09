using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SimpleUser.Infrastructure;
using SimpleUser.Infrastructure.Repositories;
using SimpleUser.Application.Services;
using SimpleUser.Domain.Interfaces;

namespace SimpleUser.API.Configurations
{
    public static class ConfigureServices
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // Registra o repositório e o serviço
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<UsuarioService>();


            // Força as rotas a serem em minúsculas
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers(); // Garantir que os controladores sejam registrados
        }


    }
}
