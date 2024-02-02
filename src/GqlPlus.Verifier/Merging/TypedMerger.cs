using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal abstract class TypedMerger<TBase, TType, TParent>
  : AliasedAllMerger<TBase, TType>
  where TBase : AstAliased
  where TType : AstType<TParent>, TBase
  where TParent : IEquatable<TParent>
{
}
