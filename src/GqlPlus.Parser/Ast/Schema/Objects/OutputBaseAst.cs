using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputBaseAst(
  ITokenAt At,
  string Name,
  string Description
) : ObjBaseAst(At, Name, Description)
{
  public OutputBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "OR";
  public override string Label => "Output";
}
