using AutoBogus;
using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.Application.Autenticacao.Fakers;


public static class UsuarioFaker
{
    public static Usuario ComSenha(string senha)
    {
        var senhaHash = SenhaExtension.GerarHash(senha);

        return new AutoFaker<Usuario>()
            .RuleFor(x => x.Senha, senhaHash)
            .Generate();
    }
}