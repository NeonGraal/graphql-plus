using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class NullMerger<A> : IMerge<A>
  where A : AstAliased
{
  public bool CanMerge(A[] items) => items.Length < 2;
}
