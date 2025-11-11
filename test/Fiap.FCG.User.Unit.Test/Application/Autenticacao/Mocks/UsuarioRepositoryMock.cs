using Fiap.FCG.User.Domain.Usuarios;
using Moq;

namespace Fiap.FCG.User.Unit.Test.Application.Autenticacao.Mocks;

public class UsuarioRepositoryMock : Mock<IUsuarioRepository>
{
    public void ConfigurarObterPorEmailAsyncRetornar(Usuario usuario)
    {
        Setup(r => r.ObterPorEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(usuario);
    }

    public void GarantirObterPorEmailAsyncChamado()
    {
        Verify(r => r.ObterPorEmailAsync(It.IsAny<string>()), Times.Once);
    }
}