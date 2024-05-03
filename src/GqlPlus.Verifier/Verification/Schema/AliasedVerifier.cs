using GqlPlus.Ast.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema;

internal abstract class AliasedVerifier<TAliased>(
   IVerify<TAliased> verifier,
   IMerge<TAliased> merger,
   ILoggerFactory logger
) : GroupedVerifier<TAliased>(merger, logger)
 where TAliased : AstAliased
{
  public override void Verify(TAliased[] item, ITokenMessages errors)
  {
    base.Verify(item, errors);

    foreach (TAliased each in item) {
      verifier.Verify(each, errors);
    }
  }
}
