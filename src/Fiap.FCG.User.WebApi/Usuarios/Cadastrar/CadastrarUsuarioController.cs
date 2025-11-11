using System.Threading.Tasks;
using Fiap.FCG.User.Application.Usuarios.Cadastrar;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Fiap.FCG.User.WebApi.Usuarios.Cadastrar;

[ApiController]
[Route("api/usuarios")]
[ApiExplorerSettings(GroupName = "Usuário")]
public class CadastrarUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public CadastrarUsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("cadastrar")]
    [SwaggerOperation(
        Summary = "Cadastra um novo usuário",
        Description = "Realiza o cadastro de um usuário informando nome, email e senha."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarUsuarioCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new
        {
            sucesso  = result.Sucesso,
            mensagem = result.Sucesso ? "Usuário cadastrado com sucesso." : result.Erro,
            valor    = result.Sucesso ? result.Valor : null
        };

        return result.Sucesso ? Ok(response) : BadRequest(response);
    }
}