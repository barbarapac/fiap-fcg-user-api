using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Controllers.Mocks;
using Fiap.FCG.User.WebApi.Usuarios.Consultar.Controllers;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Controllers.Fixtures;

public class ConsultarUsuarioControllerFixture
{
    protected MediatorMock MediatorMock { get; private set; }
    protected ConsultarUsuarioController Controller { get; private set; }

    protected ConsultarUsuarioControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller = new ConsultarUsuarioController(MediatorMock.Object);
    }
}