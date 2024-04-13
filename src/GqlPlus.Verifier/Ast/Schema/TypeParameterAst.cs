using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class TypeParameterAst(TokenAt At, string Name, string Description)
  : AstDescribed(At, Name, Description)
{
  internal override string Abbr => "T";

  internal TypeParameterAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override IEnumerable<string?> GetFields()
    => [At.ToString(), Description.Quoted("\""), Name.Prefixed("$")];
}
