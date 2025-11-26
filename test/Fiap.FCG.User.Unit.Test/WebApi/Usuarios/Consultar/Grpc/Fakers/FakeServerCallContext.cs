using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace Fiap.FCG.User.Unit.Test.WebApi.Usuarios.Consultar.Grpc.Fakers
{
    public class FakeServerCallContext : ServerCallContext
    {
        protected override string MethodCore => "fakeMethod";
        protected override string HostCore => "localhost";
        protected override string PeerCore => "fakePeer";
        protected override DateTime DeadlineCore => DateTime.UtcNow.AddMinutes(1);
        protected override Metadata RequestHeadersCore => new();
        protected override CancellationToken CancellationTokenCore => CancellationToken.None;
        protected override Metadata ResponseTrailersCore => new();
        protected override Status StatusCore { get; set; }
        protected override WriteOptions WriteOptionsCore { get; set; }
        protected override AuthContext AuthContextCore => new("fakeAuthContext", new());

        protected override ContextPropagationToken CreatePropagationTokenCore(ContextPropagationOptions options)
            => null;

        protected override Task WriteResponseHeadersAsyncCore(Metadata responseHeaders)
            => Task.CompletedTask;
    }
}