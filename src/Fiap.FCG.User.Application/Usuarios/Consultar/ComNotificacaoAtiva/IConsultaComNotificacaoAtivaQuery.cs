using System.Collections.Generic;
using System.Threading.Tasks;
using Fiap.FCG.User.Domain.Usuarios;

namespace Fiap.FCG.User.Application.Usuarios.Consultar.ComNotificacaoAtiva;

public interface IConsultaComNotificacaoAtivaQuery
{
    Task<List<Usuario>> ExecuteAsync();
}