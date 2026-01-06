using System.Diagnostics.CodeAnalysis;
using Fiap.FCG.User.Application.Usuarios.Consultar.ComNotificacaoAtiva;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Fiap.FCG.User.Application;

[ExcludeFromCodeCoverage]
public static class Module
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining(typeof(Module)));
                
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Observability.LoggingBehavior<,>));
        services.AddScoped<IConsultaComNotificacaoAtivaQuery, ConsultaComNotificacaoAtivaQuery>();
    }
}