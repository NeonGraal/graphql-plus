using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class NullMerger<A> : IMerge<A>
  where A : AstAliased
{
  public bool CanMerge(A[] items) => items.Length == 1;
  public A Merge(A[] items) => items.First();
}
