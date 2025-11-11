using System;
using Fiap.FCG.User.Infrastructure._Shared;
using Fiap.FCG.User.Infrastructure.Usuarios;
using Fiap.FCG.User.Unit.Test._Shared;

namespace Fiap.FCG.User.Unit.Test.Infrastructure.Usuarios.Fixtures;

public class UsuarioRepositoryFixture : IDisposable
{
    public UserDbContext Context { get; private set; }
    public UsuarioRepository Repository { get; private set; }

    public UsuarioRepositoryFixture()
    {
        Context    = ContextFactory.Create();
        Repository = new UsuarioRepository(Context);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}