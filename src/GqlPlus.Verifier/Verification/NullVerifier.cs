using GqlPlus.Ast;

namespace GqlPlus.Verification;

#pragma warning disable CA1823 // Avoid unused private fields
internal partial class NullVerifier<TAst>(
  ILoggerFactory logger
) : IVerify<TAst>
  where TAst : AstAbbreviated
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(NullVerifier<TAst>));

  public void Verify(TAst item, ITokenMessages errors)
    => NullVerification(item.GetType().TidyTypeName(), item);

  [LoggerMessage(LogLevel.Information, Message = "Null verification of {Type} - {Item}")]
  private partial void NullVerification(string type, TAst item);
}

internal partial class NullVerifierError<TGqlp>(
  ILoggerFactory logger
) : IVerify<TGqlp>
  where TGqlp : IGqlpError
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(NullVerifierError<TGqlp>));

  public void Verify(TGqlp item, ITokenMessages errors)
    => NullVerification(item.GetType().TidyTypeName(), item);

  [LoggerMessage(LogLevel.Information, Message = "Null verification of {Type} - {Item}")]
  private partial void NullVerification(string type, TGqlp item);
}
