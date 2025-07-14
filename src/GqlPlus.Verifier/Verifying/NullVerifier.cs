namespace GqlPlus.Verifying;

internal class NullVerifierError<TGqlp>(
  ILoggerFactory logger
) : IVerify<TGqlp>
  where TGqlp : IGqlpError
{
  private readonly ILogger _logger = logger.CreateTypedLogger<NullVerifierError<TGqlp>>();

  public void Verify(TGqlp item, IMessages errors)
    => _logger.NullVerification(item);
}

internal static partial class NullVerifierLogging
{
  internal static void NullVerification(this ILogger logger, object item)
    => logger.NullVerification(item.GetType().TidyTypeName(), item);

  [LoggerMessage(LogLevel.Information, Message = "Null verification of {Type} - {Item}")]
  internal static partial void NullVerification(this ILogger logger, string type, object item);
}
