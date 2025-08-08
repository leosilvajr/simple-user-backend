using SimpleUser.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SimpleUser.Infrastructure.Repositories;
using SimpleUser.Application.Services;
using SimpleUser.Domain.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o CORS para permitir requisições de qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()      // Permite qualquer origem
              .AllowAnyMethod()      // Permite qualquer método (GET, POST, etc.)
              .AllowAnyHeader();     // Permite qualquer cabeçalho
    });
});

// Configura o Kestrel para usar a porta 8088 com HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(8088); // Configura para ouvir na porta 8088 (somente HTTP)
});

// Adiciona o DbContext e configura a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra o repositório e o serviço
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleUser API", Version = "v1" });
});

// Força as rotas a serem em minúsculas
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();

var app = builder.Build();

// Usar a política CORS antes de qualquer outro middleware
app.UseCors("AllowAll");  // Aplica a política CORS

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleUser API v1");
        c.RoutePrefix = string.Empty; // Swagger na raiz
    });
}

// Redirecionamento HTTP para HTTPS (caso necessário)
app.UseHttpsRedirection();

// Mapeia os controladores da API
app.MapControllers();

app.Run();
