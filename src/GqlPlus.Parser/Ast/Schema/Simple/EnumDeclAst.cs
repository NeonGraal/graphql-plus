using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class EnumDeclAst(
  TokenAt At,
  string Name,
  string Description,
  EnumMemberAst[] Members
) : AstSimple<EnumMemberAst>(At, Name, Description, Members)
  , IEquatable<EnumDeclAst>
  , IGqlpEnum
{
  internal override string Abbr => "En";
  public override string Label => "Enum";

  IEnumerable<IGqlpEnumItem> IGqlpSimple<IGqlpEnumItem>.Items => Members;

  public EnumDeclAst(TokenAt at, string name, EnumMemberAst[] members)
    : this(at, name, "", members) { }

  public bool HasValue(string value)
    => Members.Any(v => v.Name == value || v.Aliases.Contains(value));
}
