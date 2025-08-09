using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace SimpleUser.API.Configurations
{
    public static class ConfigureRouting
    {
        public static void AddRoutingOptions(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        public static void UseRoutingOptions(this WebApplication app)
        {
            app.UseRouting();
        }
    }
}
