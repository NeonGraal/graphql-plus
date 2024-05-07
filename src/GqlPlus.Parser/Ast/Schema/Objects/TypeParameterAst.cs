using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class TypeParameterAst(TokenAt At, string Name, string Description)
  : AstDescribed(At, Name, Description)
  , IGqlpTypeParameter
{
  internal override string Abbr => "TP";

  internal TypeParameterAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override IEnumerable<string?> GetFields()
    => [At.ToString(), Description.Quoted("\""), Name.Prefixed("$")];
}
