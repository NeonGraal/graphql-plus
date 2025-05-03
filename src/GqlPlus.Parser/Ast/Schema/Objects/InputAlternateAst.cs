using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputAlternateAst(
  ITokenAt At,
  string Input,
  string Description
) : AstObjAlternate<IGqlpInputArg>(At, Input, Description)
  , IEquatable<InputAlternateAst>
  , IGqlpInputAlternate
{
  public override string Label => "Input";
  internal override string Abbr => "IA";

  IGqlpDualAlternate IGqlpToDual<IGqlpDualAlternate>.ToDual => ToDual();

  public DualAlternateAst ToDual()
    => new(At, Input, Description) {
      IsTypeParam = IsTypeParam,
      BaseArgs = [.. BaseArgs.Select(a => a.ToDual)],
      Modifiers = [.. Modifiers],
    };
}
