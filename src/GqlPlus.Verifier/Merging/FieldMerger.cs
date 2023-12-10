using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class FieldMerger<TField, TReference>
  : DescribedMerger<TField>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  public override bool CanMerge(TField[] items)
    => base.CanMerge(items) && items.CanMerge(item => item.ModifiedType);
}
