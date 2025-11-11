using System.Threading.Tasks;
using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Promover.Fakers;
using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Promover.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Promover;

public class PromoverUsuarioControllerTest : PromoverUsuarioControllerFixture
{
    [Fact]
    public async Task Promover_QuandoSucesso_DeveRetornarOk()
    {
        // Arrange
        var comando = PromoverUsuarioCommandFaker.Valido();
        var resultado = Result.Success("123");
        MediatorMock.ConfigurarPromoveSendParaRetornar(resultado);

        // Act
        var response = await Controller.Promover(comando);

        // Assert
        var ok = response as OkObjectResult;
        ok.Should().NotBeNull();
        ok!.Value.Should().BeEquivalentTo(new
        {
            sucesso = true
        });

        MediatorMock.GarantirEnvioDoPromoveCommand();
    }

    [Fact]
    public async Task Promover_QuandoUsuarioNaoEncontrado_DeveRetornarNotFound()
    {
        // Arrange
        var comando = PromoverUsuarioCommandFaker.Valido();
        var resultado = Result.Failure<string>("Usuário não encontrado.");
        MediatorMock.ConfigurarPromoveSendParaRetornar(resultado);

        // Act
        var response = await Controller.Promover(comando);

        // Assert
        var notFoundObjectResult = response as NotFoundObjectResult;
        notFoundObjectResult.Should().NotBeNull();
        notFoundObjectResult!.Value.Should().BeEquivalentTo(new
        {
            sucesso = false
        });

        MediatorMock.GarantirEnvioDoPromoveCommand();
    }

    [Fact]
    public async Task Promover_QuandoErroGenerico_DeveRetornarBadRequest()
    {
        // Arrange
        var comando = PromoverUsuarioCommandFaker.Valido();
        var resultado = Result.Failure<string>("Permissão inválida.");
        MediatorMock.ConfigurarPromoveSendParaRetornar(resultado);

        // Act
        var response = await Controller.Promover(comando);

        // Assert
        var badRequest = response as BadRequestObjectResult;
        badRequest.Should().NotBeNull();
        badRequest!.Value.Should().BeEquivalentTo(new
        {
            sucesso = false
        });

        MediatorMock.GarantirEnvioDoPromoveCommand();
    }
}
