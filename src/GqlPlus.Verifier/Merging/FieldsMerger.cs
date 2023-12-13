using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class FieldsMerger<TField, TReference>
  : DescribedsMerger<TField>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TField item)
    => item.ModifiedType;
  public override bool CanMerge(TField[] items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Type.Description);
}
