using System.Collections.Generic;
using System.Threading.Tasks;
using Fiap.FCG.User.Application.Usuarios.Consultar.PorId;
using Fiap.FCG.User.Application.Usuarios.Consultar.Todos;
using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Domain.Usuarios;
using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Controllers.Fakers;
using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Controllers.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Controllers;

public class ConsultarUsuarioControllerTest : ConsultarUsuarioControllerFixture
{
    [Fact]
    public async Task ConsultarTodos_QuandoSucesso_DeveRetornarOk()
    {
        // Arrange
        var usuarios = UsuarioFaker.Lista(3);
        var resultadoEsperado = Result<List<Usuario>>.Success(usuarios);

        MediatorMock.ConfigurarResultadoPara<ConsultarTodosUsuariosQuery, Result<List<Usuario>>>(resultadoEsperado);

        // Act
        var resultado = await Controller.ConsultarTodos();

        // Assert
        var okResult = resultado.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(usuarios);
        MediatorMock.GarantirEnvioDe<ConsultarTodosUsuariosQuery, Result<List<Usuario>>>();
    }

    [Fact]
    public async Task ConsultarTodos_QuandoFalha_DeveRetornarNotFound()
    {
        // Arrange
        const string erroEsperado = "Falha ao consultar usuários.";
        var resultadoErro = Result<List<Usuario>>.Failure(erroEsperado);

        MediatorMock.ConfigurarResultadoPara<ConsultarTodosUsuariosQuery, Result<List<Usuario>>>(resultadoErro);

        // Act
        var resultado = await Controller.ConsultarTodos();

        // Assert
        var notFound = resultado.Should().BeOfType<NotFoundObjectResult>().Subject;
        notFound.Value.Should().Be(erroEsperado);
        MediatorMock.GarantirEnvioDe<ConsultarTodosUsuariosQuery, Result<List<Usuario>>>();
    }

    [Fact]
    public async Task ConsultarPorId_QuandoSucesso_DeveRetornarOk()
    {
        // Arrange
        var usuario = UsuarioFaker.Valido();
        var resultadoEsperado = Result<Usuario>.Success(usuario);

        MediatorMock.ConfigurarResultadoPara<ConsultarUsuarioPorIdQuery, Result<Usuario>>(resultadoEsperado);

        // Act
        var resultado = await Controller.ConsultarPorId(usuario.Id);

        // Assert
        var okResult = resultado.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(usuario);
        MediatorMock.GarantirEnvioDe<ConsultarUsuarioPorIdQuery, Result<Usuario>>();
    }

    [Fact]
    public async Task ConsultarPorId_QuandoFalha_DeveRetornarNotFound()
    {
        // Arrange
        const string erroEsperado = "Usuário não encontrado.";
        var resultadoErro = Result<Usuario>.Failure(erroEsperado);

        MediatorMock.ConfigurarResultadoPara<ConsultarUsuarioPorIdQuery, Result<Usuario>>(resultadoErro);

        // Act
        var resultado = await Controller.ConsultarPorId(999);

        // Assert
        var notFound = resultado.Should().BeOfType<NotFoundObjectResult>().Subject;
        notFound.Value.Should().Be(erroEsperado);
        MediatorMock.GarantirEnvioDe<ConsultarUsuarioPorIdQuery, Result<Usuario>>();
    }
}
