using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Norma.Api.Extensions;
using Norma.Business.Intefaces;
using Norma.Business.Notificacoes;
using Norma.Business.Services;
using Norma.Data.Context;
using Norma.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Norma.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();
            services.AddScoped<INormaExternaRepository, NormaExternaRepository>();
            services.AddScoped<IArquivosRepository, ArquivosRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<INormaExternaService, NormaExternaService>();
            services.AddScoped<IArquivosService, ArquivosService>();
            services.AddTransient<IEmailSender, AuthMessageSender>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}