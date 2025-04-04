using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputAlternateAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjAlternate<IGqlpInputArg>(At, Name, Description)
  , IEquatable<InputAlternateAst>
  , IGqlpInputAlternate
{
  public override string Label => "Input";
  internal override string Abbr => "IA";
  public string Input => Name;

  IGqlpDualAlternate IGqlpToDual<IGqlpDualAlternate>.ToDual => ToDual();

  public DualAlternateAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
      BaseArgs = [.. BaseArgs.Select(a => a.ToDual)],
      Modifiers = [.. Modifiers],
    };
}
