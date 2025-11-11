using Fiap.FCG.User.Application.Usuarios.Atualizar;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Atualizar.Mocks;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Atualizar.Fixtures;

public class AtualizarHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; private set; }
    protected AtualizarHandler UsuarioHandler { get; private set; }

    public AtualizarHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        UsuarioHandler = new AtualizarHandler(UsuarioRepositoryMock.Object);
    }
}
