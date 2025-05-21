using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjArg(At, Name, Description)
  , IGqlpDualArg
{
  public DualArgAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "DR";
  public override string Label => "Dual";

  string IGqlpDualNamed.Dual => Name;
}
