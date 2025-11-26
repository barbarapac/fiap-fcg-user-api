using System.Collections.Generic;
using AutoBogus;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.ComNotificacaoAtiva.Fakers
{
    public static class UsuarioFaker
    {
        public static List<Usuario> ComNotificacaoAtiva(int quantidade)
        {
            return new AutoFaker<Usuario>()
                .RuleFor(u => u.ReceberNotificacoes, _ => true)
                .Generate(quantidade);
        }
        
        public static List<Usuario> SemNotificacaoAtiva(int quantidade)
        {
            return new AutoFaker<Usuario>()
                .RuleFor(u => u.ReceberNotificacoes, _ => true)
                .Generate(quantidade);
        }
    }
}