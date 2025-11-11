using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Atualizar.Mocks;
using Fiap.FCG.User.WebApi.Usuarios.Atualizar;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Atualizar.Fixtures;

public abstract class AtualizarUsuarioControllerFixture
{
    protected MediatorMock MediatorMock { get; }
    protected AtualizarUsuarioController Controller { get; }

    protected AtualizarUsuarioControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller = new AtualizarUsuarioController(MediatorMock.Object);
    }
}