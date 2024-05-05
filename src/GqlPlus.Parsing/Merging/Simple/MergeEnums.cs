using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeEnums(
  ILoggerFactory logger,
  IMerge<EnumMemberAst> enumMembers
) : AstTypeMerger<IGqlpType, EnumDeclAst, string, EnumMemberAst>(logger, enumMembers)
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(EnumDeclAst item)
    => item.Parent ?? "";

  internal override IEnumerable<EnumMemberAst> GetItems(EnumDeclAst type)
    => type.Members;

  internal override EnumDeclAst SetItems(EnumDeclAst input, IEnumerable<EnumMemberAst> items)
    => input with { Members = [.. items] };
}
