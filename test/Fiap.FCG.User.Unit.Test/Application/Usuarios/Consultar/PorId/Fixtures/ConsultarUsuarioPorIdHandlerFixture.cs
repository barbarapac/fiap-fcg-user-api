using Fiap.FCG.User.Application.Usuarios.Consultar.PorId;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.PorId.Mocks;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.PorId.Fixtures;

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