using Fiap.FCG.User.WebApi._Shared;
using Microsoft.Extensions.Logging;
using Moq;

namespace Fiap.FCG.User.Unit.Test._Shared.Mocks;

public class LoggerMock : Mock<ILogger<ExceptionMiddleware>> { }