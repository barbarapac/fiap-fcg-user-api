using Fiap.FCG.User.Application.Usuarios.Consultar;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Mocks;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Fixtures;

public class ConsultarUsuarioPorIdHandlerFixture
{
    protected UsuarioRepositoryMock RepositoryMock { get; private set; }
    protected ConsultarUsuarioPorIdHandler Handler { get; private set; }

    protected ConsultarUsuarioPorIdHandlerFixture()
    {
        RepositoryMock = new UsuarioRepositoryMock();
        Handler = new ConsultarUsuarioPorIdHandler(RepositoryMock.Object);
    }
}