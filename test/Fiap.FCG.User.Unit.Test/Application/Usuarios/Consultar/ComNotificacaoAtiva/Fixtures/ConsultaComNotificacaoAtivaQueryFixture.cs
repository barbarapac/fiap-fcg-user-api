using Fiap.FCG.User.Application.Usuarios.Consultar.ComNotificacaoAtiva;
using Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.ComNotificacaoAtiva.Mocks;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.ComNotificacaoAtiva.Fixtures
{
    public class ConsultaComNotificacaoAtivaQueryFixture
    {
        protected UsuarioRepositoryMock UsuarioRepositoryMock { get; }
        protected ConsultaComNotificacaoAtivaQuery Consulta { get; }

        public ConsultaComNotificacaoAtivaQueryFixture()
        {
            UsuarioRepositoryMock = new UsuarioRepositoryMock();
            Consulta = new ConsultaComNotificacaoAtivaQuery(UsuarioRepositoryMock.Object);
        }
    }
}