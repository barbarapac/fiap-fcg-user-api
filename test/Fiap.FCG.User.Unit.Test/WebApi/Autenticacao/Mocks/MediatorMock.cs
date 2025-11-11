using Fiap.FCG.User.Application.Autenticacao;
using MediatR;
using Moq;

namespace Fiap.FCG.User.Unit.Test.WebApi.Autenticacao.Mocks;

public class MediatorMock : Mock<IMediator>
{
    public void ConfigurarLoginComRetorno(LoginResponse response)
    {
        Setup(m => m.Send(It.IsAny<LoginCommand>(), default))
            .ReturnsAsync(response);
    }

    public void ConfigurarLoginComRetornoNulo()
    {
        Setup(m => m.Send(It.IsAny<LoginCommand>(), default))
            .ReturnsAsync((LoginResponse)null!);
    }

    public void GarantirEnvioDeLogin()
    {
        Verify(m => m.Send(It.IsAny<LoginCommand>(), default), Times.Once);
    }
}