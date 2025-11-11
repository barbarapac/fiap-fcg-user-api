using AutoBogus;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.Infrastructure.Autenticacao.Fakers;

public static class UsuarioFaker
{
    public static Usuario Valido()
    {
        return new AutoFaker<Usuario>()
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .Generate();
    }
}