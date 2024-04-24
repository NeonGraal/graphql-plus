using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Simple;

public sealed record class UnionDeclAst(
  TokenAt At,
  string Name,
  string Description,
  UnionMemberAst[] Members
) : AstSimple<UnionMemberAst>(At, Name, Description, Members)
  , IEquatable<UnionDeclAst>
{
  internal override string Abbr => "Un";
  public override string Label => "Union";

  public UnionDeclAst(TokenAt at, string name, UnionMemberAst[] members)
    : this(at, name, "", members) { }

  internal bool HasValue(string value)
    => Members.Select(a => a.Name).Contains(value);
}
