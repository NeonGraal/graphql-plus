using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class FieldsMerger<TField, TReference>
  : NamedMerger<TField>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TField item)
    => item.ModifiedType;

  public override bool CanMerge(TField[] items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Type.Description);

  protected override TField MergeGroup(TField[] items)
    => items.First() with { Description = items.MergeDescriptions() };
}
