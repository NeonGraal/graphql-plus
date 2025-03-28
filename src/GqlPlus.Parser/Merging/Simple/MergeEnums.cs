using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeEnums(
  ILoggerFactory logger,
  IMerge<IGqlpEnumLabel> enumLabels
) : AstTypeMerger<IGqlpType, IGqlpEnum, string, IGqlpEnumLabel>(logger, enumLabels)
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(IGqlpEnum item)
    => item.Parent ?? "";

  internal override IEnumerable<IGqlpEnumLabel> GetItems(IGqlpEnum type)
    => type.Items.ArrayOf<IGqlpEnumLabel>();

  internal override IGqlpEnum SetItems(IGqlpEnum input, IEnumerable<IGqlpEnumLabel> items)
  {
    EnumDeclAst ast = (EnumDeclAst)input;
    return ast with { Items = items.ArrayOf<EnumLabelAst>() };
  }
}
