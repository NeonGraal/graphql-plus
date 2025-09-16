using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjArg(At, Name, Description)
{
  public OutputArgAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "OR";
  public override string Label => "Output";
}
