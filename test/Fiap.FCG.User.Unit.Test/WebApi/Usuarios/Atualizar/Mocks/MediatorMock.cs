using Fiap.FCG.User.Application.Usuarios.Atualizar;
using Fiap.FCG.User.Domain._Shared;
using MediatR;
using Moq;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Atualizar.Mocks;

public class MediatorMock : Mock<IMediator>
{
    public void ConfigurarAtualizaSendParaRetornar(Result<string> result)
    {
        Setup(x => x.Send(It.IsAny<AtualizarCommand>(), default))
            .ReturnsAsync(result);
    }

    public void GarantirEnvioDoAtualizaCommand()
    {
        Verify(x => x.Send(It.IsAny<AtualizarCommand>(), default), Times.Once);
    }
}