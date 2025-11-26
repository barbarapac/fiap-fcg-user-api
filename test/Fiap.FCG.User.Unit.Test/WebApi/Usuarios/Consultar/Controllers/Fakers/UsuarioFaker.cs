using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Controllers.Fakers;

public static class UsuarioFaker
{
    public static Usuario Valido()
    {
        var faker = new AutoFaker<UsuarioGeracao>()
            .RuleFor(u => u.Nome, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Senha, f => f.Internet.Password(8, false, "\\w", "!A1"));

        var usuarioGerado = faker.Generate();
        var resultado = Usuario.Criar(usuarioGerado.Nome, usuarioGerado.Email, usuarioGerado.Senha);

        return resultado.Valor!;
    }

    public static Usuario ComPerfil(Perfil perfil)
    {
        var usuario = Valido();
        usuario.AtualizarPerfil(perfil);
        return usuario;
    }

    public static Usuario ComNotificacoes(bool receber)
    {
        var usuario = Valido();
        usuario.Atualizar(usuario.Nome, null, receber);
        return usuario;
    }

    public static List<Usuario> Lista(int quantidade = 3)
    {
        return Enumerable.Range(1, quantidade).Select(_ => Valido()).ToList();
    }

    // DTO auxiliar para criação via AutoBogus
    private class UsuarioGeracao
    {
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}