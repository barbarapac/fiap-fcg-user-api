using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Domain.Usuarios;
using Moq;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Atualizar.Mocks;

public class UsuarioRepositoryMock : Mock<IUsuarioRepository>
{
    public void ConfigurarParaObterPorId(Usuario? usuario)
    {
        Setup(r => r.ObterPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync(usuario);
    }
    public void ConfigurarParaAtualizar(Result<Usuario> resultado)
    {
        Setup(r => r.AtualizarAsync(It.IsAny<Usuario>()))
            .ReturnsAsync(resultado);
    }
}