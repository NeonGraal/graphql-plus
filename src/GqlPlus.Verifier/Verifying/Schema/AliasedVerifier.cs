using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema;

internal abstract class AliasedVerifier<TAliased>(
   IVerify<TAliased> verifier,
   IMerge<TAliased> merger,
   ILoggerFactory logger
) : GroupedVerifier<TAliased>(merger, logger)
 where TAliased : IGqlpAliased
{
  public override void Verify(TAliased[] item, ITokenMessages errors)
  {
    base.Verify(item, errors);

    foreach (TAliased each in item) {
      verifier.Verify(each, errors);
    }
  }
}
