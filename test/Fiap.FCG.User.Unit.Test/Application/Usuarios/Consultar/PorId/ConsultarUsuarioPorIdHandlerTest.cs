using System.Threading;
using System.Threading.Tasks;
using Fiap.FCG.User.Application.Usuarios.Consultar.PorId;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.PorId.Fakers;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.PorId.Fixtures;
using FluentAssertions;
using Xunit;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.PorId;

public class ConsultarUsuarioPorIdHandlerTest : ConsultarUsuarioPorIdHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoUsuarioExiste_DeveRetornarUsuario()
    {
        // Arrange
        var usuario = UsuarioFaker.Valido();
        var query = new ConsultarUsuarioPorIdQuery { Id = usuario.Id };

        RepositoryMock.ConfigurarObterPorIdParaRetornar(usuario);

        // Act
        var resultado = await Handler.Handle(query, CancellationToken.None);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().BeEquivalentTo(usuario);
        RepositoryMock.GarantirObterPorIdChamado();
    }

    [Fact]
    public async Task Handle_QuandoUsuarioNaoExiste_DeveRetornarFalha()
    {
        // Arrange
        var query = new ConsultarUsuarioPorIdQuery { Id = 999 };

        RepositoryMock.ConfigurarObterPorIdParaRetornarNulo();

        // Act
        var resultado = await Handler.Handle(query, CancellationToken.None);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Usuário não encontrado");
        RepositoryMock.GarantirObterPorIdChamado();
    }
}