using System.Collections.Generic;
using System.Threading.Tasks;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Application.Usuarios.Consultar.ComNotificacaoAtiva;

public class ConsultaComNotificacaoAtivaQuery : IConsultaComNotificacaoAtivaQuery
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ConsultaComNotificacaoAtivaQuery(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<Usuario>> ExecuteAsync()
    {
        return await _usuarioRepository.ObterUsuariosQueRecebemNotificacoesAsync();
    }
}