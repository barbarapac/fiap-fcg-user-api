using System.ComponentModel.DataAnnotations;
using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Domain.Usuarios;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Fiap.FCG.User.Application.Usuarios.Promover;

public class PromoverUsuarioCommand : IRequest<Result<string>>
{
    [Required]
    [SwaggerSchema("Id do usuário a ser promovido")]
    public int Id { get; set; }

    [Required]
    [SwaggerSchema("Novo perfil do usuário")]
    public Perfil NovoPerfil { get; set; }
}
