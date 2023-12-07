using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification;

internal class VerifyAllTypesAliased(
  IVerify<AstType> definition,
   IMerge<AstType> merger
) : AliasedVerifier<AstType>(definition, merger)
{
  public override string Label => "Types";

  protected override object GroupKey(AstType item) => item.Name;
}
