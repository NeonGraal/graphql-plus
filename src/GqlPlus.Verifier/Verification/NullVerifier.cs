using GqlPlus.Ast;
using GqlPlus.Token;

namespace GqlPlus.Verification;

[SuppressMessage("Performance", "CA1823:Avoid unused private fields")]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
internal partial class NullVerifier<TAst>(
  ILoggerFactory logger
) : IVerify<TAst>
  where TAst : AstAbbreviated
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(NullVerifier<TAst>));

  public void Verify(TAst item, ITokenMessages errors)
    => NullVerification(item.GetType().ExpandTypeName(), item);

  [LoggerMessage(LogLevel.Information, Message = "Null verification of {Type} - {Item}")]
  private partial void NullVerification(string type, TAst item);
}
