using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeEnums(
  IMergerRepository mergers
) : AstSimpleMerger<IGqlpType, IGqlpEnum, IGqlpEnumLabel>(mergers.LoggerFactory, mergers.MergerFor<IGqlpEnumLabel>())
{
  internal override IGqlpEnum SetItems(IGqlpEnum input, IEnumerable<IGqlpEnumLabel> items)
  {
    EnumDeclAst ast = (EnumDeclAst)input;
    return ast with { Items = items.ArrayOf<EnumLabelAst>() };
  }
}
