using System.Threading.Tasks;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.ComNotificacaoAtiva.Fakers;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.ComNotificacaoAtiva.Fixtures;
using FluentAssertions;
using Xunit;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.ComNotificacaoAtiva
{
    public class ConsultaComNotificacaoAtivaQueryTest : ConsultaComNotificacaoAtivaQueryFixture
    {
        [Fact]
        public async Task ExecuteAsync_QuandoChamado_DeveRetornarUsuariosComNotificacaoAtiva()
        {
            // Arrange
            var usuariosEsperados = UsuarioFaker.ComNotificacaoAtiva(3);
            UsuarioRepositoryMock.ConfigurarUsuariosQueRecebemNotificacoesAsync(usuariosEsperados);

            // Act
            var resultado = await Consulta.ExecuteAsync();

            // Assert
            resultado.Should().BeEquivalentTo(usuariosEsperados);
            UsuarioRepositoryMock.GarantirObterUsuariosQueRecebemNotificacoesAsync();
        }
    }
}