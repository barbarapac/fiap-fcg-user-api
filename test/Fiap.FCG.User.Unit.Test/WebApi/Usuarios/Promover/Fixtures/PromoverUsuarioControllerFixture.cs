using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Promover.Mocks;
using Fiap.FCG.User.WebApi.Usuarios.Promover;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Promover.Fixtures;

public abstract class PromoverUsuarioControllerFixture
{
    protected MediatorMock MediatorMock { get; }
    protected PromoverUsuarioController Controller { get; }

    protected PromoverUsuarioControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller = new PromoverUsuarioController(MediatorMock.Object);
    }
}