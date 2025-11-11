using Fiap.FCG.User.Application.Usuarios.Consultar;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Mocks;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Fixtures;

public abstract class ConsultarTodosUsuariosHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; }
    protected ConsultarTodosUsuariosHandler Handler { get; }

    protected ConsultarTodosUsuariosHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        Handler = new ConsultarTodosUsuariosHandler(UsuarioRepositoryMock.Object);
    }
}