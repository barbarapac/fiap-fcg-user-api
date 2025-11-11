using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.Fakers;

public class UsuarioFaker
{
    public static List<Usuario> ListaNaoOrdenadaPorId()
    {
        var lista = new AutoFaker<Usuario>()
            .Generate(5);
        return lista.OrderByDescending(u => u.Id).ToList();
    }
}