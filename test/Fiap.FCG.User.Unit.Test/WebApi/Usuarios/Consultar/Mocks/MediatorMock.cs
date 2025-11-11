using System.Collections.Generic;
using Fiap.FCG.User.Domain._Shared;
using MediatR;
using Moq;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Mocks;

public class MediatorMock : Mock<IMediator>
{
    public void ConfigurarResultadoPara<TRequest, TResult>(TResult resultado) where TRequest : IRequest<TResult>
    {
        Setup(m => m.Send(It.IsAny<TRequest>(), default)).ReturnsAsync(resultado);
    }

    public void GarantirEnvioDe<TRequest, TResponse>() where TRequest : IRequest<TResponse>
    {
        Verify(m => m.Send(It.IsAny<TRequest>(), default), Times.Once);
    }
}