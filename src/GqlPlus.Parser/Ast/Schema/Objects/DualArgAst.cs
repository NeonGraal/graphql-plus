using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class DualArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjArg(At, Name, Description)
{
  public DualArgAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "DR";
  public override string Label => "Dual";
}
