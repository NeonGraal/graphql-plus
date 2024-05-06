﻿using GqlPlus.Ast;
using GqlPlus.Verifying;

namespace GqlPlus.Verification;

internal class NullVerifier<TAst>(
  ILoggerFactory logger
) : IVerify<TAst>
  where TAst : AstAbbreviated
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(NullVerifier<TAst>));

  public void Verify(TAst item, ITokenMessages errors)
    => _logger.NullVerification(item);
}

internal class NullVerifierError<TGqlp>(
  ILoggerFactory logger
) : IVerify<TGqlp>
  where TGqlp : IGqlpError
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(NullVerifierError<TGqlp>));

  public void Verify(TGqlp item, ITokenMessages errors)
    => _logger.NullVerification(item);
}

internal static partial class NullVerifierLogging
{
  internal static void NullVerification(this ILogger logger, object item)
    => logger.NullVerification(item.GetType().TidyTypeName(), item);

  [LoggerMessage(LogLevel.Information, Message = "Null verification of {Type} - {Item}")]
  internal static partial void NullVerification(this ILogger logger, string type, object item);
}
