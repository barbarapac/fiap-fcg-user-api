using System.Threading.Tasks;
using Fiap.FCG.User.Application.Usuarios.Promover;
using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Domain.Usuarios;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Promover.Fakers;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Promover.Fixtures;
using FluentAssertions;
using Xunit;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Promover;

public class PromoverUsuarioHandlerTest : PromoverUsuarioHandlerFixture
{
    [Fact]
    public async Task Handle_UsuarioValido_DevePromoverComSucesso()
    {
        // Arrange
        var usuario = UsuarioFaker.Valido();
        UsuarioRepositoryMock.ConfigurarObterPorIdAsync(usuario);
        UsuarioRepositoryMock.ConfigurarAtualizarAsync(Result<Usuario>.Success(usuario));

        var command = new PromoverUsuarioCommand
        {
            Id = usuario.Id,
            NovoPerfil = Perfil.Admin
        };

        // Act
        var resultado = await Handler.Handle(command, default);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().Be("Usuário promovido com sucesso");
        UsuarioRepositoryMock.GarantirAtualizacaoFoiChamada();
    }

    [Fact]
    public async Task Handle_UsuarioInexistente_NaoDevePromover()
    {
        // Arrange
        UsuarioRepositoryMock.ConfigurarObterPorIdAsyncComoNull();

        var command = new PromoverUsuarioCommand
        {
            Id = 9999,
            NovoPerfil = Perfil.Admin
        };

        // Act
        var resultado = await Handler.Handle(command, default);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Usuário não encontrado.");
    }

    [Fact]
    public async Task Handle_PerfilInvalido_NaoDevePromover()
    {
        // Arrange
        var usuario = UsuarioFaker.Valido();
        UsuarioRepositoryMock.ConfigurarObterPorIdAsync(usuario);

        var command = new PromoverUsuarioCommand
        {
            Id = usuario.Id,
            NovoPerfil = (Perfil)999
        };

        // Act
        var resultado = await Handler.Handle(command, default);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Perfil inválido.");
    }
}
