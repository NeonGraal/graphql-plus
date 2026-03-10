using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema;

internal abstract class AliasedVerifier<TAliased>(
   IVerify<TAliased> verifier,
   IMergerRepository mergers
) : GroupedVerifier<TAliased>(mergers)
 where TAliased : IGqlpAliased
{
  public override void Verify(TAliased[] item, IMessages errors)
  {
    base.Verify(item, errors);

    foreach (TAliased each in item) {
      verifier.Verify(each, errors);
    }
  }
}
