using Fiap.FCG.User.Domain.Usuarios;
using Moq;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.PorId.Mocks;

public class UsuarioRepositoryMock : Mock<IUsuarioRepository>
{
    public void ConfigurarObterPorIdParaRetornar(Usuario usuario)
    {
        Setup(r => r.ObterPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync(usuario);
    }

    public void ConfigurarObterPorIdParaRetornarNulo()
    {
        Setup(r => r.ObterPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Usuario)null);
    }

    public void GarantirObterPorIdChamado()
    {
        Verify(r => r.ObterPorIdAsync(It.IsAny<int>()), Times.Once);
    }
}