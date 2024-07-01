using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualArgumentAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjArgument(At, Name, Description)
  , IGqlpDualArgument
{
  public DualArgumentAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "DR";
  public override string Label => "Dual";

  string IGqlpDualArgument.Dual => Name;
}
