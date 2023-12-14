using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Verifier.Verification;
internal class NullVerifier<T>(ILoggerFactory logger) : IVerify<T> where T : AstBase
{
  private readonly ILogger _logger = logger.CreateLogger(typeof(T).ExpandTypeName());

  public ITokenMessages Verify(T target)
  {
    _logger.LogInformation("Null verification");
    return new TokenMessages();
  }
}
