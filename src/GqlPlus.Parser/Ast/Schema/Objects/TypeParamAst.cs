using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class TypeParamAst(
  ITokenAt At,
  string Name,
  string Description,
  string Constraint
) : AstNamed(At, Name, Description)
  , IGqlpTypeParam
{
  internal override string Abbr => "TP";

  internal TypeParamAst(TokenAt at, string name, string constraint)
    : this(at, name, "", constraint) { }

  internal override IEnumerable<string?> GetFields()
    => DescriptionAt
      .Append(Name.Prefixed("$"))
      .Append(Constraint.Prefixed(":"));
}
