using Fiap.FCG.User.Application.Usuarios.Consultar.Todos;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Todos.Mocks;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Todos.Fixtures;

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