using Fiap.FCG.User.Application.Autenticacao;
using Fiap.FCG.User.Unit.Test.Application.Autenticacao.Mocks;

namespace Fiap.FCG.User.Unit.Test.Application.Autenticacao.Fixtures;

public class LoginCommandHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; private set; }
    protected JwtTokenServiceMock JwtTokenServiceMock { get; private set; }

    protected LoginCommandHandler Handler { get; private set; }

    protected LoginCommandHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        JwtTokenServiceMock = new JwtTokenServiceMock();

        Handler = new LoginCommandHandler(
            UsuarioRepositoryMock.Object,
            JwtTokenServiceMock.Object
        );
    }
}