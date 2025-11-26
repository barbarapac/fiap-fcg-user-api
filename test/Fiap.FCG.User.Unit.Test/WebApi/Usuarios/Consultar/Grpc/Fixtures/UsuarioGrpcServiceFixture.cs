using Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Grpc.Mocks;
using Fiap.FCG.User.WebApi.Usuarios.Consultar.Grpc;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Grpc.Fixtures
{
    public class UsuarioGrpcServiceFixture
    {
        protected ConsultaComNotificacaoAtivaQueryMock ConsultaMock { get; }
        protected UsuarioGrpcService Service { get; }

        public UsuarioGrpcServiceFixture()
        {
            ConsultaMock = new ConsultaComNotificacaoAtivaQueryMock();
            Service = new UsuarioGrpcService(ConsultaMock.Object);
        }
    }
}