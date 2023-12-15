using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal abstract class AliasedVerifier<TAliased>(
   IVerify<TAliased> verifier,
   IMerge<TAliased> merger,
   ILoggerFactory logger
) : GroupedVerifier<TAliased>(merger, logger)
 where TAliased : AstAliased
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(AliasedVerifier<TAliased>));

  public override ITokenMessages Verify(TAliased[] item)
  {
    var errors = new TokenMessages();

    errors.AddRange(base.Verify(item));
    errors.AddRange(item.SelectMany(verifier.Verify));

    return errors;
  }
}
