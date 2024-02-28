using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal partial class NullVerifier<TAst>(ILoggerFactory logger)
  : IVerify<TAst>
  where TAst : AstAbbreviated
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(NullVerifier<TAst>));

  public void Verify(TAst item, ITokenMessages errors)
    => NullVerification(item.GetType().ExpandTypeName(), item);

  [LoggerMessage(LogLevel.Information, Message = "Null verification of {Type} - {Item}")]
  private partial void NullVerification(string type, TAst item);
}
