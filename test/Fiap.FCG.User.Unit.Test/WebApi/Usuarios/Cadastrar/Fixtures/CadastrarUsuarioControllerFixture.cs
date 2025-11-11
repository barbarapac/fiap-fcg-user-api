using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Cadastrar.Mocks;
using Fiap.FCG.User.WebApi.Usuarios.Cadastrar;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Cadastrar.Fixtures;

public class CadastrarUsuarioControllerFixture
{
    protected MediatorMock MediatorMock { get; private set; }
    protected CadastrarUsuarioController Controller { get; private set; }

    public CadastrarUsuarioControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller = new CadastrarUsuarioController(MediatorMock.Object);
    }
}