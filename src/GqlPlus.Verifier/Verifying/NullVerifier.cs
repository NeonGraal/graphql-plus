using GqlPlus.Ast;

namespace GqlPlus.Verifying;

internal class NullVerifierError<TError>
  : IVerify<TError>
  where TError : IAstError
{
  private readonly ILogger _logger;

  public NullVerifierError(IVerifierRepository verifiers)
    => _logger = verifiers.LoggerFactory.CreateTypedLogger(this);

  public void Verify(TError item, IMessages errors)
    => _logger.NullVerification(item);

  internal static NullVerifierError<TError> Factory(IVerifierRepository v) => new(v);
}

internal static partial class NullVerifierLogging
{
  internal static void NullVerification(this ILogger logger, object item)
    => logger.NullVerification(item.GetType().TidyTypeName(), item);

  [LoggerMessage(LogLevel.Information, Message = "Null verification of {Type} - {Item}")]
  internal static partial void NullVerification(this ILogger logger, string type, object item);
}
