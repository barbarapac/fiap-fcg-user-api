using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Domain.Usuarios;
using MediatR;

namespace Fiap.FCG.User.Application.Usuarios.Consultar;

public class ConsultarTodosUsuariosHandler : IRequestHandler<ConsultarTodosUsuariosQuery, Result<List<Usuario>>>
{
    private readonly IUsuarioRepository _repository;

    public ConsultarTodosUsuariosHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<Usuario>>> Handle(ConsultarTodosUsuariosQuery request,
        CancellationToken cancellationToken)
    {
        var usuarios = await _repository.ObterTodosAsync();
        var usuariosOrdenados = usuarios
            .OrderBy(u => u.Id)
            .ToList();
        return Result.Success(usuariosOrdenados);
    }
}