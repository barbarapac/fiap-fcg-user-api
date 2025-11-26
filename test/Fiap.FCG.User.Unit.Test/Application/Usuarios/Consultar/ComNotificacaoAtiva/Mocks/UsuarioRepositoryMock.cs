using System.Collections.Generic;
using Fiap.FCG.User.Domain.Usuarios;
using Moq;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.ComNotificacaoAtiva.Mocks
{
    public class UsuarioRepositoryMock : Mock<IUsuarioRepository>
    {
        public void ConfigurarUsuariosQueRecebemNotificacoesAsync(List<Usuario> usuarios)
        {
            Setup(x => x.ObterUsuariosQueRecebemNotificacoesAsync())
                .ReturnsAsync(usuarios);
        }

        public void GarantirObterUsuariosQueRecebemNotificacoesAsync()
        {
            Verify(x => x.ObterUsuariosQueRecebemNotificacoesAsync(), Times.Once);
        }
    }
}