using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleUser.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        // Define um endpoint GET para retornar o status da API
        [HttpGet]
        public IActionResult Get()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Desconhecido";
            var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var statusResponse = new
            {
                status = "API está no ar!",
                environment = environment,
                serverTime = currentTime,
                message = "A API está funcionando corretamente. Todos os serviços estão operacionais."
            };

            return Ok(statusResponse);
        }
    }
}
