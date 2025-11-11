using AutoBogus;
using Fiap.FCG.User.Application.Autenticacao;

namespace Fiap.FCG.User.Unit.Test.WebApi.Autenticacao.Fakers;

public static class LoginCommandFaker
{
    public static LoginCommand Valido()
    {
        return new AutoFaker<LoginCommand>().Generate();
    }
}