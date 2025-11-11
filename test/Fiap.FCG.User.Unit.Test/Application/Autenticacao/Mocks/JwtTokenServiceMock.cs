using Fiap.FCG.User.Domain.Usuarios;
using Fiap.FCG.User.Infrastructure.Autenticacao;
using Moq;

namespace Fiap.FCG.User.Unit.Test.Application.Autenticacao.Mocks;

public class JwtTokenServiceMock : Mock<IJwtTokenService>
{
    public void ConfigurarGerarTokenRetornar(string token)
    {
        Setup(s => s.GerarToken(It.IsAny<Usuario>()))
            .Returns(token);
    }

    public void GarantirGerarTokenChamado()
    {
        Verify(s => s.GerarToken(It.IsAny<Usuario>()), Times.Once);
    }
}