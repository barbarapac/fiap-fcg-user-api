using System.Collections.Generic;
using AutoBogus;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Grpc.Fakers
{
    public static class UsuarioFaker
    {
        public static List<Usuario> ComNotificacaoAtiva(int quantidade)
        {
            return new AutoFaker<Usuario>()
                .RuleFor(u => u.ReceberNotificacoes, _ => true)
                .Generate(quantidade);
        }
    }
}