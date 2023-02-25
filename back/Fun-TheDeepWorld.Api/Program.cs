using System.Reflection;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services;
ConfigurationManager config;
WebApplication app;

InitConfig();
InitServices();
InitApp();

void InitConfig()
{
    config = builder.Configuration;
}

void InitServices()
{
    services = builder.Services;

    services.AddSwaggerGen(x =>
    {
        x.SwaggerDoc("v1", new OpenApiInfo { Title = "Fun-TheDeepWorld API", Version = "v1" });
        x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory
            , $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    });
    services.AddControllers();
    services.AddEndpointsApiExplorer();
}

void InitApp()
{
    app = builder.Build();

    //using IServiceScope serviceScope = app.Services.CreateScope();
    //DeepWorldContext context = serviceScope.ServiceProvider.GetRequiredService<DeepWorldContext>();
    //if (context.IsRelational()) context.Migrate();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();
