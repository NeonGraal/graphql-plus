using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

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

    foreach (var each in item) {
      verifier.Verify(each, errors);
    }
  }
}
