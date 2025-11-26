using System.Diagnostics.CodeAnalysis;
using Fiap.FCG.User.Application.Usuarios.Consultar.ComNotificacaoAtiva;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.FCG.User.Application;

[ExcludeFromCodeCoverage]
public static class Module
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining(typeof(Module)));
        
        services.AddScoped<IConsultaComNotificacaoAtivaQuery, ConsultaComNotificacaoAtivaQuery>();
    }
}