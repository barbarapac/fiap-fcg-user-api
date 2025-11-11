using Fiap.FCG.User.Application.Usuarios.Cadastrar;
using Fiap.FCG.User.Domain._Shared;
using MediatR;
using Moq;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Cadastrar.Mocks;

public class MediatorMock : Mock<IMediator>
{
    public void ConfigurarCadastroSendParaRetornar(Result<string> result)
    {
        Setup(x => x.Send(It.IsAny<CadastrarUsuarioCommand>(), default))
            .ReturnsAsync(result);
    }

    public void GarantirEnvioDoCadastroCommand()
    {
        Verify(x => x.Send(It.IsAny<CadastrarUsuarioCommand>(), default), Times.Once);
    }
}