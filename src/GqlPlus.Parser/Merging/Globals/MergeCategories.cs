using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;

namespace GqlPlus.Merging.Globals;

internal class MergeCategories(
  ILoggerFactory logger
) : AstAliasedMerger<IGqlpSchemaCategory>(logger)
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpSchemaCategory> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMergeStruct(item => item.CategoryOption));

  protected override string ItemMatchName => "Output~Modifiers~Option";
  protected override string ItemMatchKey(IGqlpSchemaCategory item)
    => $"{item.Output.Name}~{item.Modifiers.AsString().Joined(",")}~{item.CategoryOption}";
}
