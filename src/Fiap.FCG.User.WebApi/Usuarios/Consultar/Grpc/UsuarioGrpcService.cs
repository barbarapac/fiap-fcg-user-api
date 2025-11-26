using System.Threading.Tasks;
using Fiap.FCG.User.Application.Usuarios.Consultar.ComNotificacaoAtiva;
using Fiap.FCG.User.WebApi.Protos;
using Grpc.Core;

namespace Fiap.FCG.User.WebApi.Usuarios.Consultar.Grpc;

public class UsuarioGrpcService : UsuarioService.UsuarioServiceBase
{
    private readonly IConsultaComNotificacaoAtivaQuery _query;

    public UsuarioGrpcService(IConsultaComNotificacaoAtivaQuery query)
    {
        _query = query;
    }

    public override async Task<ObterUsuariosComNotificacoesResponse> ObterUsuariosComNotificacoes(
        ObterUsuariosComNotificacoesRequest request, 
        ServerCallContext context)
    {
        var usuarios = await _query.ExecuteAsync();

        var response = new ObterUsuariosComNotificacoesResponse();
        
        foreach (var usuario in usuarios)
        {
            response.Usuarios.Add(new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            });
        }

        return response;
    }
}