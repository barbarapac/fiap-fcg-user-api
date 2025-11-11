using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Fiap.FCG.User.Application.Usuarios.Cadastrar;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Atualizar.Fakers;

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

    public static List<Usuario> ConverterParaUsuarios()
    {
        return new List<Usuario>
        {
            new AutoFaker<Usuario>(),
            new AutoFaker<Usuario>(),
            new AutoFaker<Usuario>(),
        };
    }
    
    public static List<Usuario> ListaNaoOrdenadaPorId()
    {
        var lista = new AutoFaker<Usuario>()
            .Generate(5);
        return lista.OrderByDescending(u => u.Id).ToList();
    }
}