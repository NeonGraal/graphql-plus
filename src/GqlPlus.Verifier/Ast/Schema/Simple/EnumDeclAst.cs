using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Simple;

public sealed record class EnumDeclAst(
  TokenAt At,
  string Name,
  string Description,
  EnumMemberAst[] Members
) : AstSimple<EnumMemberAst>(At, Name, Description, Members)
  , IEquatable<EnumDeclAst>
{
  internal override string Abbr => "En";
  public override string Label => "Enum";

  public EnumDeclAst(TokenAt at, string name, EnumMemberAst[] members)
    : this(at, name, "", members) { }

  internal bool HasValue(string value)
    => Members.Any(v => v.Name == value || v.Aliases.Contains(value));
}
