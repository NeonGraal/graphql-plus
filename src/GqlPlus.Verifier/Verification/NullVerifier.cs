using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;
internal class NullVerifier<TAst>(ILoggerFactory logger)
  : IVerify<TAst>
  where TAst : AstBase
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(NullVerifier<TAst>));

  public ITokenMessages Verify(TAst target)
  {
    _logger.LogInformation("Null verification of {Type} - {Target}", target.GetType().ExpandTypeName(), target);
    return new TokenMessages();
  }
}
