using Fiap.FCG.User.Unit.Test.WebApi.Autenticacao.Mocks;
using Fiap.FCG.User.WebApi.Autenticacao;

namespace Fiap.FCG.User.Unit.Test.WebApi.Autenticacao.Fixtures;

public class LoginControllerFixture
{
    protected MediatorMock MediatorMock { get; private set; }
    protected LoginController Controller { get; private set; }

    protected LoginControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller = new LoginController(MediatorMock.Object);
    }
}