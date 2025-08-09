using SimpleUser.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddCorsPolicy();  
builder.Services.AddSwaggerServices();  
builder.Services.AddRoutingOptions();  

var app = builder.Build();

app.UseCorsPolicy(); 
app.UseSwaggerConfiguration(); 
app.UseCommonMiddlewares();  

app.Run();
