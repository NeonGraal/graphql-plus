using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeEnums(
  ILoggerFactory logger,
  IMerge<IGqlpEnumLabel> enumLabels
) : AstSimpleMerger<IGqlpType, IGqlpEnum, IGqlpEnumLabel>(logger, enumLabels)
{
  internal override IGqlpEnum SetItems(IGqlpEnum input, IEnumerable<IGqlpEnumLabel> items)
  {
    EnumDeclAst ast = (EnumDeclAst)input;
    return ast with { Items = items.ArrayOf<EnumLabelAst>() };
  }
}
