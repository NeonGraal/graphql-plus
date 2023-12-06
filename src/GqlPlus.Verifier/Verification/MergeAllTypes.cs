using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class MergeAllTypes
  : IMerge<AstType>
{
  public bool CanMerge(AstType[] items)
  {
    return true;
  }
}
