using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;

namespace GqlPlus.Merging.Globals;

internal class MergeCategories(
  ILoggerFactory logger
) : AstAliasedMerger<IGqlpSchemaCategory>(logger)
{
  public override ITokenMessages CanMerge(IEnumerable<IGqlpSchemaCategory> items)
    => base.CanMerge(items)
      .Add(items.CanMergeStruct(item => item.CategoryOption));

  protected override string ItemMatchName => "Output~Modifiers~Option";
  protected override string ItemMatchKey(IGqlpSchemaCategory item)
    => $"{item.Output}~{item.Modifiers.AsString()}~{item.CategoryOption}";
}
