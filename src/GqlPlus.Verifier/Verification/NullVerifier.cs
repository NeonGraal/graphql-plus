using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;
internal class NullVerifier<TAst>(ILoggerFactory logger)
  : IVerify<TAst>
  where TAst : AstAbbreviated
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(NullVerifier<TAst>));

  public void Verify(TAst item, ITokenMessages errors)
    => _logger.LogInformation("Null verification of {Type} - {Item}", item.GetType().ExpandTypeName(), item);
}
