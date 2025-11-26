using System.Collections.Generic;
using Fiap.FCG.User.Domain._Shared;
using Fiap.FCG.User.Domain.Usuarios;
using MediatR;

namespace Fiap.FCG.User.Application.Usuarios.Consultar.Todos;

public class ConsultarTodosUsuariosQuery : IRequest<Result<List<Usuario>>> { }