using Fiap.FCG.User.Application.Usuarios.Promover;
using Fiap.FCG.User.Domain._Shared;
using MediatR;
using Moq;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Promover.Mocks;

public class MediatorMock : Mock<IMediator>
{
    public void ConfigurarPromoveSendParaRetornar(Result<string> result)
    {
        Setup(x => x.Send(It.IsAny<PromoverUsuarioCommand>(), default))
            .ReturnsAsync(result);
    }

    public void GarantirEnvioDoPromoveCommand()
    {
        Verify(x => x.Send(It.IsAny<PromoverUsuarioCommand>(), default), Times.Once);
    }
}