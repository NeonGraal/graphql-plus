using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputAlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjAlternate(At, Name, Description)
  , IGqlpInputAlternate
{
  public override string Label => "Input";
  internal override string Abbr => "IA";
}
