using AutoBogus;
using Fiap.FCG.User.Application.Usuarios.Promover;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Promover.Fakers;

public static class PromoverUsuarioCommandFaker
{
    public static PromoverUsuarioCommand Valido()
    {
        return new AutoFaker<PromoverUsuarioCommand>().Generate();
    }
}