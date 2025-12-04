using Fiap.FCG.User.Application.Usuarios.Consultar.ComNotificacaoAtiva;
using Fiap.FCG.User.Domain.Usuarios;
using Fiap.FCG.User.WebApi.Protos;
using Grpc.Core;
using System.Threading.Tasks;

namespace Fiap.FCG.User.WebApi.Usuarios.Consultar.Grpc;

public class UsuarioGrpcService : UsuarioService.UsuarioServiceBase
{
    private readonly IConsultaComNotificacaoAtivaQuery _query;
    private readonly IUsuarioRepository _usuarioRepository;

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

    public override async Task<ObterUsuarioPorIdResponse> ObterUsuarioPorId(
    ObterUsuarioPorIdRequest request,
    ServerCallContext context)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(request.UsuarioId);

        if (usuario == null)
        {
            return new ObterUsuarioPorIdResponse
            {
                Existe = false
            };
        }

        return new ObterUsuarioPorIdResponse
        {
            Existe = true,
            Usuario = new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            }
        };
    }
}