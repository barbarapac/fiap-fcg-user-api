using AutoBogus;
using Fiap.FCG.User.Application.Usuarios.Cadastrar;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Cadastrar.Fakers;

public class UsuarioFaker
{
    public static Usuario ConverterParaUsuario(CadastrarUsuarioCommand command)
    {
        return new AutoFaker<Usuario>()
            .RuleFor(x => x.Nome, f => command.Nome)
            .RuleFor(x => x.Email, f => command.Email)
            .RuleFor(x => x.Senha, f => command.Senha)
            .Generate();
    }
}