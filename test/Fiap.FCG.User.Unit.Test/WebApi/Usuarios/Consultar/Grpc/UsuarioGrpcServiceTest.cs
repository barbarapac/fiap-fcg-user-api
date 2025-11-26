using System.Collections.Generic;
using System.Threading.Tasks;
using Fiap.FCG.User.Domain.Usuarios;
using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Grpc.Fakers;
using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Grpc.Fixtures;
using Fiap.FCG.User.WebApi.Protos;
using FluentAssertions;
using Xunit;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Grpc
{
    public class UsuarioGrpcServiceTest : UsuarioGrpcServiceFixture
    {
        [Fact]
        public async Task ObterUsuariosComNotificacoes_QuandoChamado_DeveRetornarUsuariosConvertidos()
        {
            // Arrange
            var usuariosEsperados = UsuarioFaker.ComNotificacaoAtiva(2);
            ConsultaMock.ConfigurarRetorno(usuariosEsperados);

            var request = new ObterUsuariosComNotificacoesRequest();
            var context = new FakeServerCallContext();

            // Act
            var resultado = await Service.ObterUsuariosComNotificacoes(request, context);

            // Assert
            resultado.Usuarios.Should().HaveCount(2);
            resultado.Usuarios[0].Id.Should().Be(usuariosEsperados[0].Id);
            resultado.Usuarios[0].Nome.Should().Be(usuariosEsperados[0].Nome);
            resultado.Usuarios[0].Email.Should().Be(usuariosEsperados[0].Email);

            ConsultaMock.GarantirExecucao();
        }
        
        [Fact]
        public async Task ObterUsuariosComNotificacoes_QuandoNaoHouverUsuarios_DeveRetornarListaVazia()
        {
            // Arrange
            var usuariosVazios = new List<Usuario>();
            ConsultaMock.ConfigurarRetorno(usuariosVazios);

            var request = new ObterUsuariosComNotificacoesRequest();
            var context = new FakeServerCallContext();

            // Act
            var resultado = await Service.ObterUsuariosComNotificacoes(request, context);

            // Assert
            resultado.Usuarios.Should().BeEmpty();
            ConsultaMock.GarantirExecucao();
        }

    }
}