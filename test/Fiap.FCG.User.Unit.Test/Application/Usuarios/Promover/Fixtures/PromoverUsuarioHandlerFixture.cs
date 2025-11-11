using Fiap.FCG.User.Application.Usuarios.Promover;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Promover.Mocks;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Promover.Fixtures;

public class PromoverUsuarioHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; private set; }
    protected PromoverUsuarioHandler Handler { get; private set; }

    protected PromoverUsuarioHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        Handler = new PromoverUsuarioHandler(UsuarioRepositoryMock.Object);
    }
}