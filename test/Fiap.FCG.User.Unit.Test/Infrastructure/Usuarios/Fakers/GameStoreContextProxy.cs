using System;
using System.Threading;
using System.Threading.Tasks;
using Fiap.FCG.User.Infrastructure._Shared;
using Microsoft.EntityFrameworkCore;

namespace Fiap.FCG.User.Unit.Test.Infrastructure.Usuarios.Fakers;

public class GameStoreContextProxy : UserDbContext
{
    public GameStoreContextProxy(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new Exception("Simulação de falha no banco");
    }
}