using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

public sealed record class EnumMemberAst(TokenAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<EnumMemberAst>
{
  public EnumMemberAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "EM";
}
