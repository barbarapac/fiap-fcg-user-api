using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Domain.Usuarios;
using Moq;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Promover.Mocks;

public class UsuarioRepositoryMock : Mock<IUsuarioRepository>
{
    public void ConfigurarObterPorIdAsync(Usuario usuario)
    {
        Setup(x => x.ObterPorIdAsync(usuario.Id))
            .ReturnsAsync(usuario);
    }

    public void ConfigurarObterPorIdAsyncComoNull()
    {
        Setup(x => x.ObterPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Usuario)null);
    }

    public void ConfigurarAtualizarAsync(Result<Usuario> resultado)
    {
        Setup(x => x.AtualizarAsync(It.IsAny<Usuario>()))
            .ReturnsAsync(resultado);
    }

    public void GarantirAtualizacaoFoiChamada()
    {
        Verify(x => x.AtualizarAsync(It.IsAny<Usuario>()), Times.Once);
    }
}