using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeEnums(
  ILoggerFactory logger,
  IMerge<EnumMemberAst> enumMembers
) : AstTypeMerger<IGqlpType, IGqlpEnum, string, EnumMemberAst>(logger, enumMembers)
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(IGqlpEnum item)
    => item.Parent ?? "";

  internal override IEnumerable<EnumMemberAst> GetItems(IGqlpEnum type)
    => type.Items.ArrayOf<EnumMemberAst>();

  internal override IGqlpEnum SetItems(IGqlpEnum input, IEnumerable<EnumMemberAst> items)
  {
    EnumDeclAst ast = (EnumDeclAst)input;
    return ast with { Members = [.. items] };
  }
}
