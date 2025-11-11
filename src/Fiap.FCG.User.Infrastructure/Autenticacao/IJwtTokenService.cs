using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Infrastructure.Autenticacao;

public interface IJwtTokenService
{
    string GerarToken(Usuario usuario);
}