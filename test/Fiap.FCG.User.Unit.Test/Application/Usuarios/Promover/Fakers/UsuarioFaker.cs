using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Promover.Fakers;

public static class UsuarioFaker
{
    public static Usuario Valido()
    {
        return Usuario.Criar("Joao da Silva", "teste@email.com", "Abc@12345").Valor;
    }
}