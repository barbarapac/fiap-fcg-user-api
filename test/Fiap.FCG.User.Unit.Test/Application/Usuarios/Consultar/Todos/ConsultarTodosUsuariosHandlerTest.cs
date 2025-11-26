using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fiap.FCG.User.Application.Usuarios.Consultar.Todos;
using Fiap.FCG.User.Domain.Usuarios;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Todos.Fakers;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Todos.Fixtures;
using FluentAssertions;
using Xunit;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Todos;

public class ConsultarTodosUsuariosHandlerTest : ConsultarTodosUsuariosHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoUsuariosExistem_DeveRetornarListaOrdenada()
    {
        // Arrange
        var usuariosNaoOrdenados = UsuarioFaker.ListaNaoOrdenadaPorId();
        UsuarioRepositoryMock.ConfigurarObterTodos(usuariosNaoOrdenados);

        // Act
        var resultado = await Handler.Handle(new ConsultarTodosUsuariosQuery(), CancellationToken.None);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().BeInAscendingOrder(u => u.Id);
        resultado.Valor.Should().HaveSameCount(usuariosNaoOrdenados);

        UsuarioRepositoryMock.GarantirObterTodosChamado();
    }

    [Fact]
    public async Task Handle_QuandoListaVazia_DeveRetornarListaVazia()
    {
        // Arrange
        UsuarioRepositoryMock.ConfigurarObterTodos(new List<Usuario>());

        // Act
        var resultado = await Handler.Handle(new ConsultarTodosUsuariosQuery(), CancellationToken.None);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().BeEmpty();

        UsuarioRepositoryMock.GarantirObterTodosChamado();
    }
}