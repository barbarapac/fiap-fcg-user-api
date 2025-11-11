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
}