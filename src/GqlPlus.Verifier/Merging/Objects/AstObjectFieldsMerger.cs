using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Merging.Objects;

internal class AstObjectFieldsMerger<TObjField, TObjBase>(
  ILoggerFactory logger
) : AstAliasedMerger<TObjField>(logger)
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  protected override string ItemMatchName => "ModifiedType";
  protected override string ItemMatchKey(TObjField item)
    => item.ModifiedType;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TObjField> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Type.Description));

  protected override TObjField MergeGroup(IEnumerable<TObjField> group)
  {
    TObjField result = base.MergeGroup(group);
    string typeDescription = group.Select(item => item.Type).MergeDescriptions();
    return result with { Type = result.Type with { Description = typeDescription } };
  }
}
