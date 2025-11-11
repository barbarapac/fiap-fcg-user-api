using System.Linq;
using AutoBogus;
using Bogus;
using Fiap.FCG.User.Application.Usuarios.Cadastrar;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Cadastrar.Fakers;

public static class CadastrarCommandFaker
{
    public static CadastrarUsuarioCommand Valido()
    {
        return new AutoFaker<CadastrarUsuarioCommand>()
            .RuleFor(x => x.Nome, f => f.Person.FullName)
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Senha, f => GerarSenhaValida())
            .Generate();
    }

    private static string GerarSenhaValida()
    {
        var faker         = new Faker();
        
        var letra    = faker.Random.String2(1, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
        var numero   = faker.Random.String2(1, "0123456789");
        var especial = faker.Random.String2(1, "!@#$%^&*");
        var restante = faker.Random.String2(5, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");

        var senha = string.Concat(letra, numero, especial, restante)
            .OrderBy(_ => faker.Random.Int())
            .Take(8);

        return new string(senha.ToArray());
    }
}
