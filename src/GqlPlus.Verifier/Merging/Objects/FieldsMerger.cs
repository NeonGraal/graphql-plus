using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Objects;

internal class FieldsMerger<TField, TRef>(
  ILoggerFactory logger
) : AstAliasedMerger<TField>(logger)
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
{
  protected override string ItemMatchName => "ModifiedType";
  protected override string ItemMatchKey(TField item)
    => item.ModifiedType;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TField> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Type.Description));

  protected override TField MergeGroup(IEnumerable<TField> group)
  {
    var result = base.MergeGroup(group);
    var typeDescription = group.Select(item => item.Type).MergeDescriptions();
    return result with { Type = result.Type with { Description = typeDescription } };
  }
}
