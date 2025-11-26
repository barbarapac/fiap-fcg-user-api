using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Fiap.FCG.User.Application.Usuarios.Consultar.ComNotificacaoAtiva;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.FCG.User.WebApi.Usuarios.ComNotificacaoAtivada;

[ExcludeFromCodeCoverage]
[ApiController]
[Route("api/usuarios/com-notificacoes")]
[ApiExplorerSettings(GroupName = "Usuário")]
public class ComNotificacaoAtivadaController : ControllerBase
{
    private readonly IConsultaComNotificacaoAtivaQuery _query;

    public ComNotificacaoAtivadaController(IConsultaComNotificacaoAtivaQuery query)
    {
        _query = query;
    }

    [HttpGet]
    public async Task<IActionResult> ObterUsuariosComNotificacoes()
    {
        var usuarios = await _query.ExecuteAsync();
        
        var response = usuarios.Select(u => new
        {
            Id = u.Id,
            Nome = u.Nome,
            Email = u.Email
        });

        return Ok(response);
    }
}