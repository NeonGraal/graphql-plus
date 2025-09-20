using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputAlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : ObjAlternateAst(At, Name, Description)
{
  public override string Label => "Input";
  internal override string Abbr => "IA";
}
