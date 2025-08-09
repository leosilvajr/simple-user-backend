using Microsoft.AspNetCore.Builder;

namespace SimpleUser.API.Configurations
{
    public static class ConfigureMiddlewares
    {
        public static void UseCommonMiddlewares(this WebApplication app)
        {
            app.UseHttpsRedirection(); 
            app.MapControllers(); 
        }
    }
}
