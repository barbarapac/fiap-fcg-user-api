using Microsoft.Extensions.Configuration;
using Moq;

namespace Fiap.FCG.User.Unit.Test.Infrastructure.Autenticacao.Mocks;

public class ConfigurationMock : Mock<IConfiguration>
{
    public void ConfigurarValoresPadroesJwt()
    {
        Setup(c => c["JWT_KEY"]).Returns("chave-secreta-super-segura-para-testes");
        Setup(c => c["JWT_ISSUER"]).Returns("Fiap.FCG");
        Setup(c => c["JWT_AUDIENCE"]).Returns("Fiap.FCG");
    }
}