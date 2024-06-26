using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class EnumMemberAst(
  TokenAt At,
  string Name,
  string Description
) : AstAliased(At, Name, Description)
  , IEquatable<EnumMemberAst>
  , IGqlpEnumItem
{
  public EnumMemberAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "EM";
}
