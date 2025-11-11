using System;
using Fiap.FCG.User.Infrastructure._Shared;
using Microsoft.EntityFrameworkCore;

namespace Fiap.FCG.User.Unit.Test._Shared;

public static class ContextFactory
{
    public static UserDbContext Create()
    {
        var options = new DbContextOptionsBuilder<UserDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) 
            .Options;

        return new UserDbContext(options);
    }
}