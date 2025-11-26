using System.Collections.Generic;
using Fiap.FCG.User.Application.Usuarios.Consultar.ComNotificacaoAtiva;
using Fiap.FCG.User.Domain.Usuarios;
using Moq;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Grpc.Mocks
{
    public class ConsultaComNotificacaoAtivaQueryMock : Mock<IConsultaComNotificacaoAtivaQuery>
    {
        public void ConfigurarRetorno(List<Usuario> usuarios)
        {
            Setup(x => x.ExecuteAsync()).ReturnsAsync(usuarios);
        }

        public void GarantirExecucao()
        {
            Verify(x => x.ExecuteAsync(), Times.Once);
        }
    }
}