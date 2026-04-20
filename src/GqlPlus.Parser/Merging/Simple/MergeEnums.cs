using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeEnums(
  IMergerRepository mergers
) : AstSimpleMerger<IAstType, IAstEnum, IAstEnumLabel>(mergers)
{
  internal override IAstEnum SetItems(IAstEnum input, IEnumerable<IAstEnumLabel> items)
  {
    EnumDeclAst ast = (EnumDeclAst)input;
    return ast with { Items = items.ArrayOf<EnumLabelAst>() };
  }

  internal static MergeEnums Factory(IMergerRepository m) => new(m);
}
