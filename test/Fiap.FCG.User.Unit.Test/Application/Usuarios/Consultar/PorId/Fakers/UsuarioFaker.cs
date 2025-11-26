using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Unit.Test.Application.Usuarios.Consultar.PorId.Fakers;

public class UsuarioFaker
{
    public static Usuario Valido()
    {
        return new AutoFaker<Usuario>().Generate();
    }
}