using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Domain.Usuarios;
using MediatR;

namespace Fiap.FCG.User.Application.Usuarios.Consultar.PorId;

public class ConsultarUsuarioPorIdQuery : IRequest<Result<Usuario>>
{
    public int Id { get; set; }
}