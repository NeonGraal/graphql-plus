using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class FieldsMerger<TField, TReference>
  : AliasedMerger<TField>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TField item)
    => item.ModifiedType;

  protected override bool CanMergeGroup(IGrouping<string, TField> group)
    => base.CanMergeGroup(group)
      && group.CanMerge(item => item.Type.Description);
}
