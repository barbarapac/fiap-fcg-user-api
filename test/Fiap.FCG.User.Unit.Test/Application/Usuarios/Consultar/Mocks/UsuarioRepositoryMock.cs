using System.Collections.Generic;
using Fiap.FCG.User.Domain.Usuarios;
using Moq;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Mocks;

public class UsuarioRepositoryMock : Mock<IUsuarioRepository>
{
    public void ConfigurarObterTodos(List<Usuario> usuarios)
    {
        Setup(x => x.ObterTodosAsync()).ReturnsAsync(usuarios);
    }

    public void GarantirObterTodosChamado()
    {
        Verify(x => x.ObterTodosAsync(), Times.Once);
    }
    
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