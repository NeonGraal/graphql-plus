using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputAlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjAlternate<IGqlpInputArg>(At, Name, Description)
  , IGqlpInputAlternate
{
  public override string Label => "Input";
  internal override string Abbr => "IA";

  IGqlpDualBase IGqlpToDual<IGqlpDualBase>.ToDual => ToDual();
  IGqlpDualAlternate IGqlpToDual<IGqlpDualAlternate>.ToDual => ToDual();

  public DualAlternateAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
      BaseArgs = [.. BaseArgs.Select(a => a.ToDual)],
      Modifiers = [.. Modifiers],
    };
}
