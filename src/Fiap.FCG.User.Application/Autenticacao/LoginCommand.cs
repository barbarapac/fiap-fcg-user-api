using MediatR;

namespace Fiap.FCG.User.Application.Autenticacao;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
}