using AutoBogus;
using Fiap.FCG.User.Application.Usuarios.Atualizar;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Atualizar.Fakers;

public static class AtualizarCommandFaker
{
    public static AtualizarCommand Valido()
    {
        return new AutoFaker<AtualizarCommand>().Generate();
    }
}