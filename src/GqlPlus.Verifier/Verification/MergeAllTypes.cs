using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class MergeAllTypes
  : IMerge<AstType>
{
  public bool CanMerge(AstType[] items) => items.Select(i => i.GetType()).Distinct().Count() < 2;
}
